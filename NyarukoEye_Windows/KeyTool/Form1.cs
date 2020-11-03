using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NyarukoEye_Windows
{
    public partial class Form1 : Form
    {
        private UInt64 threadID = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "正在新建密钥对...";
            panel1.Enabled = false;
            ThreadStart screenshotRef = new ThreadStart(newKeysThreadRun);
            Thread screenshotThread = new Thread(screenshotRef);
            screenshotThread.Name = "screenshotThread" + (threadID++).ToString();
            screenshotThread.Start();
        }
        private void newKeysThreadRun()
        {
            Action<String, String, String, String> txtKeyDelegate = delegate (string returnPublicXML, string returnPrivateXML, string returnPublicPEM, string returnPrivatePEM)
            {
                txtPublicXML.Text = returnPublicXML;
                txtPrivateXML.Text = returnPrivateXML;
                txtPublicPEM.Text = returnPublicPEM;
                txtPrivatePEM.Text = returnPrivatePEM;
                toolStripStatusLabel1.Text = "新建密钥对完成。";
                panel1.Enabled = true;
            };
            string strPublicXML = RsaTool.newPublicKey("");
            string strPrivateXML = RsaTool.newPrivateKey("");
            string strPublicPEM = RsaTool.publicKeyXml2Pem(strPublicXML);
            string strPrivatePEM = RsaTool.privateKeyXml2Pem(strPrivateXML);
            Invoke(txtKeyDelegate, new object[] { strPublicXML, strPrivateXML, strPublicPEM, strPrivatePEM });
        }
        private string extName(string fileName)
        {
            string[] strs = fileName.Split('.');
            if (strs.Length < 2) return "";
            return strs.Last();
        }
        private void saveText(string fName, string text)
        {
            if (text.Length == 0)
            {
                if (MessageBox.Show("目前没有载入任何信息，将会保存一个空白文件。确定吗？", "创建空白文件？", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(fName))
                {
                    sw.Write(text);
                }
                toolStripStatusLabel1.Text = "文件已保存: " + fName;
            }
            catch (Exception err)
            {
                toolStripStatusLabel1.Text = "保存失败: " + err.Message;
                MessageBox.Show(err.Message, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void btnInpPub_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "请选择要导入的公钥";
            openFileDialog1.FileName = "PublicKey";
            openFileDialog1.Filter = "XML 公钥|*.xml|PEM 公钥|*.pub|所有文件|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fName = openFileDialog1.FileName;
                if (!File.Exists(fName))
                {
                    toolStripStatusLabel1.Text = "找不到文件 " + fName + " ,请确认输入的文件名是否存在";
                    MessageBox.Show(toolStripStatusLabel1.Text, "找不到文件", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string eName = extName(fName);
                try
                {
                    if (eName.Equals("xml", StringComparison.OrdinalIgnoreCase))
                    {
                        RsaTool.loadXmlPublicKey(fName);
                    }
                    else
                    {
                        RsaTool.loadPemPublicKey(fName);
                    }
                    txtPublicXML.Text = RsaTool.RSACSPublic.ToXmlString(checkBox1.Checked);
                    txtPublicPEM.Text = RsaTool.publicKeyXml2Pem(txtPublicXML.Text);
                }
                catch (Exception err)
                {
                    toolStripStatusLabel1.Text = err.Message;
                    MessageBox.Show(toolStripStatusLabel1.Text, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExpPub_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "指定公钥保存位置";
            saveFileDialog1.FileName = "PublicKey";
            saveFileDialog1.Filter = "XML 公钥|*.xml|PEM 公钥|*.pub";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fName = saveFileDialog1.FileName;
                string eName = extName(fName);
                string cerStr = txtPublicXML.Text;
                if (eName.Equals("xml", StringComparison.OrdinalIgnoreCase))
                {
                    cerStr = txtPublicXML.Text;
                }
                else if (eName.Equals("pub", StringComparison.OrdinalIgnoreCase))
                {
                    cerStr = txtPublicPEM.Text;
                }
                else
                {
                    MessageBox.Show("请指定一个存储类型", "未知的存储类型", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                saveText(fName, cerStr);
            }
        }

        private void btnInpPri_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "请选择要导入的私钥";
            openFileDialog1.FileName = "PrivateKey";
            openFileDialog1.Filter = "XML 私钥|*.xml|PEM 私钥|*.pem|所有文件|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fName = openFileDialog1.FileName;
                if (!File.Exists(fName))
                {
                    toolStripStatusLabel1.Text = "找不到文件 " + fName + " ,请确认输入的文件名是否存在";
                    if (!File.Exists(fName)) MessageBox.Show(toolStripStatusLabel1.Text, "找不到文件", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string eName = extName(fName);
                try
                {
                    if (eName.Equals("xml", StringComparison.OrdinalIgnoreCase))
                    {
                        RsaTool.loadXmlPrivateKey(fName);
                    }
                    else
                    {
                        RsaTool.loadPemPrivateKey(fName);
                    }
                    txtPrivateXML.Text = RsaTool.RSACSPrivate.ToXmlString(checkBox1.Checked);
                    txtPrivatePEM.Text = RsaTool.privateKeyXml2Pem(txtPrivateXML.Text);
                }
                catch (Exception err)
                {
                    toolStripStatusLabel1.Text = err.Message;
                    MessageBox.Show(toolStripStatusLabel1.Text, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExpPri_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "指定私钥保存位置";
            saveFileDialog1.FileName = "PrivateKey";
            saveFileDialog1.Filter = "XML 私钥|*.xml|PEM 私钥|*.pem";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fName = saveFileDialog1.FileName;
                string eName = extName(fName);
                string cerStr = "";
                if (eName.Equals("xml", StringComparison.OrdinalIgnoreCase))
                {
                    cerStr = txtPrivateXML.Text;
                }
                else if (eName.Equals("pub", StringComparison.OrdinalIgnoreCase))
                {
                    cerStr = txtPrivatePEM.Text;
                }
                else
                {
                    MessageBox.Show("请指定一个存储类型", "未知的存储类型", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                saveText(fName, cerStr);
            }
        }
    }
}
