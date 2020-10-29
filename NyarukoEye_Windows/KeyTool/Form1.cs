using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                panel1.Enabled = true;
            };
            toolStripStatusLabel1.Text = "正在生成公钥...";
            string strPublicXML = RsaTool.newPublicKey("");
            toolStripStatusLabel1.Text = "正在生成私钥...";
            string strPrivateXML = RsaTool.newPrivateKey("");
            toolStripStatusLabel1.Text = "正在转换公钥为 PEM ...";
            string strPublicPEM = RsaTool.publicKeyXml2Pem(strPublicXML);
            toolStripStatusLabel1.Text = "正在转换私钥为 PEM ...";
            string strPrivatePEM = RsaTool.privateKeyXml2Pem(strPrivateXML);
            Invoke(txtKeyDelegate, new object[] { strPublicXML, strPrivateXML, strPublicPEM, strPrivatePEM });
            toolStripStatusLabel1.Text = "新建密钥对完成。";
        }
    }
}
