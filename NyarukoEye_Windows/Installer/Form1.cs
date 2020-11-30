using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Installer
{
    public partial class Form1 : Form
    {
        string[] dlls = { "Enc.dll", "INI.dll", "NetUL.dll", "RestSharp.dll", "Shot.dll" };
        string[] exes = { "nyarukoeyesev.exe", "NELauncher.exe", "scrchk.exe", "ConfigEditer.exe", "ConfigEditerServer.exe", "Autorun.exe", "KeyTool.exe", "NetTool.exe" };

        private List<string> stat = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string dir = folderBrowserDialog1.SelectedPath + "\\";
                if (Directory.Exists(dir))
                {
                    textBox1.Text = dir;
                    button1.Visible = button3.Visible = true;
                }
                else
                {
                    button1.Visible = button3.Visible = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stat.Clear();
            try
            {
                installFile(0, "nyarukoeyesev.exe");
                installFile(1, "NELauncher.exe");
                installFile(1, "scrchk.exe");
                installFile(2, "ConfigEditer.exe");
                installFile(3, "ConfigEditerServer.exe");
                installFile(4, "Autorun.exe");
                installFile(5, "KeyTool.exe");
                installFile(6, "NetTool.exe");
                installDll();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "安装失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(string.Join("\n", stat.ToArray()), "安装完毕", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void installFile(int listIndex, string tmpFile, bool isDel = false)
        {
            if (checkedListBox1.GetItemCheckState(listIndex) == CheckState.Checked)
            {
                string toFile = textBox1.Text + tmpFile;
                if (!isDel)
                {
                    if (File.Exists(toFile)) File.Delete(toFile);
                    File.Copy(tmpFile, toFile);
                    stat.Add("已复制：" + toFile);
                }
                else if (File.Exists(toFile))
                {
                    File.Delete(toFile);
                    stat.Add("已删除：" + toFile);
                }
            }
        }

        private void installDll(bool isDel = false)
        {
            bool isInstall = false;
            if (!isDel)
            {
                for (int i = 1; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                    {
                        isInstall = true;
                        break;
                    }
                }
            }
            for (int i = 0; i < dlls.Length; i++)
            {
                string toPath = textBox1.Text + dlls[i];
                if (isInstall)
                {
                    if (File.Exists(toPath)) File.Delete(toPath);
                    File.Copy(dlls[i], toPath);
                    stat.Add("已复制：" + toPath);
                }
                else if (File.Exists(toPath))
                {
                    File.Delete(toPath);
                    stat.Add("已删除：" + toPath);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stat.Clear();
            try
            {
                installFile(0, "nyarukoeyesev.exe", true);
                installFile(1, "NELauncher.exe", true);
                installFile(1, "scrchk.exe", true);
                installFile(2, "ConfigEditer.exe", true);
                installFile(3, "ConfigEditerServer.exe", true);
                installFile(4, "Autorun.exe", true);
                installFile(5, "KeyTool.exe", true);
                installFile(6, "NetTool.exe", true);
                installDll(true);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(string.Join("\n", stat.ToArray()), "删除完毕", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                for (int i = 0; i < dlls.Length; i++)
                {
                    if (File.Exists(dlls[i])) File.Delete(dlls[i]);
                }
                for (int i = 0; i < exes.Length; i++)
                {
                    if (File.Exists(exes[i])) File.Delete(exes[i]);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "临时文件清除失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
