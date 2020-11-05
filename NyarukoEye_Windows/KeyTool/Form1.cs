using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NyarukoEye_Windows
{
    public partial class Form1 : Form
    {
        private UInt64 threadID = 0;
        private string workDic = Environment.CurrentDirectory;
        private string tempDic = Environment.GetEnvironmentVariable("TEMP");
        private string tempPrivateKeyFile;
        private string tempPublicKeyFile;

        public Form1()
        {
            InitializeComponent();
            tempPrivateKeyFile = tempDic+"\\NyaEye_Tools_Pri_" + GetTimeStamp();
            tempPublicKeyFile = tempDic+"\\NyaEye_Tools_Pub_" + GetTimeStamp();
            string[] opensslPaths = Enc.getOpensslPaths();
            if (opensslPaths.Length == 0)
            {
                MessageBox.Show("没有在程序目录和环境变量中找到 openssl.exe ，程序将立即退出。", "需要 OpenSSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Thread thread = new Thread(() =>
                {
                    Thread.Sleep(100);
                    Application.Exit();
                });
                thread.IsBackground = true;
                thread.Start();
                return;
            }
            foreach (string opensslPath in opensslPaths)
            {
                comboBox1.Items.Add(opensslPath);
            }
            comboBox1.Text = comboBox1.Items[0].ToString();
            Enc.opensslPath = comboBox1.Text;
        }

        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "正在新建密钥对...";
            btnNewPriKey_Click(sender, e);
            btnNewPubKey_Click(sender, e);
            tabControl1.SelectedIndex = 0;
            toolStripStatusLabel1.Text = "新建密钥对完成。";
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
            openFileDialog1.FileName = "PublicKey.pub";
            openFileDialog1.Filter = "PEM 公钥|*.pub|所有文件|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    txtPublicPEM.Text = File.ReadAllText(openFileDialog1.FileName);
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
            saveFileDialog1.FileName = "PublicKey.pub";
            saveFileDialog1.Filter = "PEM 公钥|*.pub|所有文件|*.*";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fName = saveFileDialog1.FileName;
                try
                {
                    File.WriteAllText(fName, txtPublicPEM.Text);
                }
                catch (Exception err)
                {
                    toolStripStatusLabel1.Text = err.Message;
                    MessageBox.Show(toolStripStatusLabel1.Text, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnInpPri_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "请选择要导入的私钥";
            openFileDialog1.FileName = "PrivateKey.pem";
            openFileDialog1.Filter = "PEM 私钥|*.pem|所有文件|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    txtPrivatePEM.Text = File.ReadAllText(openFileDialog1.FileName);
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
            saveFileDialog1.FileName = "PrivateKey.pem";
            saveFileDialog1.Filter = "PEM 私钥|*.pem|所有文件|*.*";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fName = saveFileDialog1.FileName;
                try
                {
                    File.WriteAllText(fName, txtPublicPEM.Text);
                }
                catch (Exception err)
                {
                    toolStripStatusLabel1.Text = err.Message;
                    MessageBox.Show(toolStripStatusLabel1.Text, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEncTxt_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    txtText.Text=RsaTool.rsaEncrypt(txtText.Text);
            //}
            //catch (Exception err)
            //{
            //    toolStripStatusLabel1.Text = err.Message;
            //    MessageBox.Show(toolStripStatusLabel1.Text, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnDecTxt_Click(object sender, EventArgs e)
        {
            //txtText.Text = RsaTool.rsaDecrypt(txtText.Text);
            //try
            //{
            //    txtText.Text=RsaTool.rsaDecrypt(txtText.Text);
            //}
            //catch (Exception err)
            //{
            //    toolStripStatusLabel1.Text = err.Message;
            //    MessageBox.Show(toolStripStatusLabel1.Text, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enc.opensslPath = comboBox1.Text;
        }

        private void btnNewPriKey_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "正在创建私钥...";
            txtPrivatePEM.Text = Enc.genPrivateKey(int.Parse(txtKeyLength.Text));
            tabControl1.SelectedIndex = 0;
            toolStripStatusLabel1.Text = "创建私钥完成。";
        }

        private void btnNewPubKey_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "正在提取公钥...";
            txtPublicPEM.Text = Enc.getPublicKey(txtPrivatePEM.Text);
            tabControl1.SelectedIndex = 1;
            toolStripStatusLabel1.Text = "提取公钥完成。";
        }

        private void txtPrivatePEM_TextChanged(object sender, EventArgs e)
        {
            bool btnenable = false;
            if (txtPrivatePEM.Text.Length > 0)
            {
                btnenable = true;
            }
            btnExpPri.Enabled = btnenable;
            btnNewPubKey.Enabled = btnenable;
            btnDecTxt.Enabled = btnenable;
            try
            {
                File.WriteAllText(tempPrivateKeyFile, txtPublicPEM.Text);
            }
            catch (Exception err)
            {
                toolStripStatusLabel1.Text = err.Message;
                MessageBox.Show(toolStripStatusLabel1.Text, "临时文件保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPublicPEM_TextChanged(object sender, EventArgs e)
        {
            bool btnenable = false;
            if (txtPublicPEM.Text.Length > 0)
            {
                btnenable = true;
            }
            btnExpPub.Enabled = btnenable;
            btnEncTxt.Enabled = btnenable;
            try
            {
                File.WriteAllText(tempPublicKeyFile, txtPublicPEM.Text);
            }
            catch (Exception err)
            {
                toolStripStatusLabel1.Text = err.Message;
                MessageBox.Show(toolStripStatusLabel1.Text, "临时文件保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ~Form1()
        {
            if (File.Exists(tempPrivateKeyFile)) File.Delete(tempPrivateKeyFile);
            if (File.Exists(tempPublicKeyFile)) File.Delete(tempPublicKeyFile);
        }
    }
}
