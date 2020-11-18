using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ConfigEditer
{
    public partial class Form1 : Form
    {
        private string systemTempDir = "";
        public Form1()
        {
            InitializeComponent();
            string temp = Environment.GetEnvironmentVariable("TEMP");
            DirectoryInfo info = new DirectoryInfo(temp);
            systemTempDir = info.FullName + "\\";
            cTempDir.Text = systemTempDir + cPrefix.Text;
            cTempDir.Items.Add(cTempDir.Text);
            cName.Text = GetNumberAlpha(Environment.MachineName + Environment.UserDomainName + Environment.UserName);
            string fileDir = Environment.CurrentDirectory;
            DirectoryInfo folder = new DirectoryInfo(fileDir);
            FileInfo[] files = folder.GetFiles("*.pub");
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo nowFile = files[i];
                string nowFilePath = nowFile.Name;
                if (i == 0) cPublicKey.Text = nowFilePath;
                cPublicKey.Items.Add(nowFilePath);
            }
            cPublicKeyG.Enabled = File.Exists(fileDir + "\\KeyTool.exe");
        }

        private static string GetNumberAlpha(string source)
        {
            string pattern = "[A-Za-z0-9]";
            string strRet = "";
            MatchCollection results = Regex.Matches(source, pattern);
            foreach (var v in results)
            {
                strRet += v.ToString();
            }
            return strRet;
        }

        private void cPrefix_TextChanged(object sender, EventArgs e)
        {
            string newPath = systemTempDir + cPrefix.Text;
            if (cTempDir.Text.Equals((string)cTempDir.Items[0])) cTempDir.Text = newPath;
            cTempDir.Items.Clear();
            cTempDir.Items.Add(systemTempDir + cPrefix.Text);
        }

        private void cTempDirB_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = cTempDir.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK && Directory.Exists(folderBrowserDialog1.SelectedPath))
            {
                string path = folderBrowserDialog1.SelectedPath;
                if (path[path.Length - 1].Equals("\\")) path = path.Substring(0, path.Length - 1);
                cTempDir.Text = path;
            }
        }

        private void cPublicKeyG_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = "KeyTool.exe";
                myProcess.StartInfo.CreateNoWindow = false;
                myProcess.Start();
            }
            catch (Exception err)
            {
                cPublicKeyG.Enabled = false;
            }
        }

        private void cPublicKeyB_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = cPublicKey.Text;
            openFileDialog1.Filter = "公钥文件|*.pub|公钥文件|*.pem|所有文件|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog1.FileName)) cPublicKey.Text = openFileDialog1.FileName;
        }

        private void cPasswordB_CheckedChanged(object sender, EventArgs e)
        {
            if (cPasswordB.Checked)
            {
                cPassword.PasswordChar = '\0';
            }
            else
            {
                cPassword.PasswordChar = '*';
            }
        }
    }
}
