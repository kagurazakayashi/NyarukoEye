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

namespace NyarukoEye_Windows
{
    public partial class Form1 : Form
    {
        private string systemTempDir = "";
        private string nowOpenINI = "";
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

        private void openini(string iniPath = "")
        {
            if (iniPath.Length == 0) iniPath = nowOpenINI;
            INI ini = new INI(iniPath);
            string v = ini.IniReadValue("User", "Prefix");
            if (v.Length > 0) cPrefix.Text = v;
            v = ini.IniReadValue("User", "Name");
            if (v.Length > 0) cName.Text = v;
            v = ini.IniReadValue("File", "Type");
            if (v.Length > 0) cType.Text = v;
            v = ini.IniReadValue("Work", "Sleep");
            if (v.Length > 0)
            {
                int vi = int.Parse(v);
                if (vi >= cSleep.Minimum && vi <= cSleep.Maximum) cSleep.Value = vi;
            }
            v = ini.IniReadValue("Work", "TempDir");
            if (v.Length > 0) cTempDir.Text = v;
            v = ini.IniReadValue("Work", "WorkSleep");
            if (v.Length > 0)
            {
                int vi = int.Parse(v);
                if (vi >= cWorkSleep.Minimum && vi <= cWorkSleep.Maximum) cWorkSleep.Value = vi;
            }
            v = ini.IniReadValue("Encrypt", "Symmetric");
            if (v.Length > 0) cSymmetric.Text = v;
            v = ini.IniReadValue("Encrypt", "AESLength");
            if (v.Length > 0) cAESLength.Text = v;
            v = ini.IniReadValue("Encrypt", "PublicKey");
            if (v.Length > 0) cPublicKey.Text = v;
            v = ini.IniReadValue("File", "KeyType");
            if (v.Length > 0) cKeyType.Text = v;
            v = ini.IniReadValue("File", "EncType");
            if (v.Length > 0) cEncType.Text = v;
            v = ini.IniReadValue("File", "EncKeyType");
            if (v.Length > 0) cEncKeyType.Text = v;
            v = ini.IniReadValue("Network", "UploadURL");
            if (v.Length > 0) cUploadURL.Text = v;
            v = ini.IniReadValue("User", "Username");
            if (v.Length > 0) cUsername.Text = v;
            v = ini.IniReadValue("User", "Password");
            if (v.Length > 0) cPassword.Text = v;
        }

        private void saveini(string iniPath = "")
        {
            if (iniPath.Length == 0) iniPath = nowOpenINI;
            INI ini = new INI(iniPath);
            ini.IniWriteValue("User", "Prefix", cPrefix.Text);
            ini.IniWriteValue("User", "Name", cName.Text);
            ini.IniWriteValue("File", "Type", cType.Text);
            ini.IniWriteValue("Work", "Sleep", cSleep.Value.ToString());
            ini.IniWriteValue("Work", "TempDir", cTempDir.Text);
            ini.IniWriteValue("Work", "WorkSleep", cWorkSleep.Value.ToString());
            ini.IniWriteValue("Encrypt", "Symmetric", cSymmetric.Text);
            ini.IniWriteValue("Encrypt", "AESLength", cAESLength.Text);
            ini.IniWriteValue("Encrypt", "PublicKey", cPublicKey.Text);
            ini.IniWriteValue("File", "KeyType", cKeyType.Text);
            ini.IniWriteValue("File", "EncType", cEncType.Text);
            ini.IniWriteValue("File", "EncKeyType", cEncKeyType.Text);
            ini.IniWriteValue("Network", "UploadURL", cUploadURL.Text);
            ini.IniWriteValue("User", "Username", cUsername.Text);
            ini.IniWriteValue("User", "Password", cPassword.Text);
        }

        private void chgLevel()
        {
            int level = tLevel.Value;
            cPasswordB.Enabled = cPassword.Enabled = cUsername.Enabled = cUploadURL.Enabled = cPublicKeyB.Enabled = cSymmetric.Enabled = cAESLength.Enabled = cPublicKey.Enabled = true;
            if (level <= 2)
            {
                cPassword.Text = cUsername.Text = cUploadURL.Text = "";
                cPasswordB.Enabled = cPassword.Enabled = cUsername.Enabled = cUploadURL.Enabled = false;
            }
            if (level == 1)
            {
                cSymmetric.Text = cAESLength.Text = cPublicKey.Text = "";
                cPublicKeyB.Enabled = cSymmetric.Enabled = cAESLength.Enabled = cPublicKey.Enabled = false;
            }
        }

        private void tLevel_Scroll(object sender, EventArgs e)
        {
            tLevelA.Enabled = true;
        }

        private void tLevelA_Click(object sender, EventArgs e)
        {
            tLevelA.Enabled = false;
            chgLevel();
        }

        private void 打开INI配置文件ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "INI 配置文件|*.ini|所有文件|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog1.FileName))
            {
                nowOpenINI = openFileDialog1.FileName;
                Text = "客户端配置编辑器 - " + nowOpenINI;
                openini();
                保存INI配置文件ToolStripMenuItem.Enabled = true;
            }
        }

        private void 保存INI配置文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nowOpenINI.Length > 0)
            {
                saveini();
            }
            else
            {
                另存为PToolStripMenuItem_Click(sender, e);
            }
        }

        private void 另存为PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "INI 配置文件|*.ini|所有文件|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                nowOpenINI = saveFileDialog1.FileName;
                Text = "配置编辑器 - " + nowOpenINI;
                saveini();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("> 读取非明文配置文件\n- 保存明文配置文件\n- 读入明文配置文件", "接下来的操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "非明文配置文件|*.ine|所有文件|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("+ 读取非明文配置文件\n> 保存明文配置文件\n- 读入明文配置文件", "接下来的操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                saveFileDialog1.FileName = "";
                saveFileDialog1.Filter = "INI 配置文件|*.ini|所有文件|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    nowOpenINI = "";
                    try
                    {
                        string txt = File.ReadAllText(openFileDialog1.FileName);
                        txt = StringAES.Decrypt(txt, cConfPwd.Text);
                        File.WriteAllText(saveFileDialog1.FileName, txt);
                        nowOpenINI = saveFileDialog1.FileName;
                        Text = "配置编辑器 - " + nowOpenINI;
                        openini();
                        保存INI配置文件ToolStripMenuItem.Enabled = true;
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "导入失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void 导出为加密配置文件IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("需要先保存文件才能进行导出，要现在保存吗？", "需要先保存文件", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                保存INI配置文件ToolStripMenuItem_Click(sender, e);
                if (nowOpenINI.Length > 0)
                {
                    MessageBox.Show("+ 保存明文配置文件\n> 保存非明文配置文件", "接下来的操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    saveFileDialog1.FileName = "";
                    saveFileDialog1.Filter = "非明文配置文件|*.ine|所有文件|*.*";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            string txt = File.ReadAllText(nowOpenINI);
                            txt = StringAES.Encrypt(txt, cConfPwd.Text);
                            File.WriteAllText(saveFileDialog1.FileName, txt);
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message, "导出失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("要先保存文件吗？", "正在退出", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                保存INI配置文件ToolStripMenuItem_Click(sender, e);
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void 退出QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
