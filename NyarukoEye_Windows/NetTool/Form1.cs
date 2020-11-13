using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Collections.Specialized;

namespace NyarukoEye_Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "请选择要上载的文件";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "所有文件|*.*";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog1.FileNames)
                {
                    if (File.Exists(fileName))
                    {
                        listFile.Items.Add(fileName);
                    }
                }
                btnStart.Enabled = btnRemove.Enabled = listFile.Items.Count > 0;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listFile.SelectedIndex >= 0) listFile.Items.RemoveAt(listFile.SelectedIndex);
            btnStart.Enabled = btnRemove.Enabled = listFile.Items.Count > 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string[] filelist = new string[listFile.Items.Count];
            for (UInt16 i = 0; i < listFile.Items.Count; i++)
            {
                filelist[i] = ((string)listFile.Items[i]);
            }
            Dictionary<string, string> stringDict = new Dictionary<string, string>();
            stringDict.Add("userName", txtName.Text);
            stringDict.Add("password", txtPassword.Text);
            string[] result = NetUL.httpUploadFile(txtURL.Text, filelist, stringDict);
            string resultErr = result[0];
            string resultInfo = result[1];
            if (resultErr.Length > 0)
            {
                MessageBox.Show(resultErr, "网络通信失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            switch (resultInfo)
            {
                case "100":
                    MessageBox.Show("上传成功", resultInfo, MessageBoxButtons.OK, MessageBoxIcon.Information); break;
                case "101":
                    MessageBox.Show("上传成功，原文件删除失败", resultInfo, MessageBoxButtons.OK, MessageBoxIcon.Information); break;
                case "200":
                    MessageBox.Show("用户名或密码不正确", resultInfo, MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                case "202":
                    MessageBox.Show("创建文件失败", resultInfo, MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                case "203":
                    MessageBox.Show("保存文件失败", resultInfo, MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                case "204":
                    MessageBox.Show("解密失败", resultInfo, MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                default:
                    MessageBox.Show(resultInfo, "返回信息", MessageBoxButtons.OK, MessageBoxIcon.Information); break;
            }
        }
    }
}
