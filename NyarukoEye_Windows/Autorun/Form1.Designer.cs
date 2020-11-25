
namespace Autorun
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.radioUser = new System.Windows.Forms.RadioButton();
            this.radioSys = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.ComboBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOn = new System.Windows.Forms.Button();
            this.btnOff = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // radioUser
            // 
            this.radioUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioUser.Checked = true;
            this.radioUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioUser.Location = new System.Drawing.Point(89, 344);
            this.radioUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioUser.Name = "radioUser";
            this.radioUser.Size = new System.Drawing.Size(859, 26);
            this.radioUser.TabIndex = 0;
            this.radioUser.TabStop = true;
            this.radioUser.Text = "为当前用户设置开机启动 (&U)";
            this.radioUser.UseVisualStyleBackColor = true;
            // 
            // radioSys
            // 
            this.radioSys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioSys.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioSys.Location = new System.Drawing.Point(89, 376);
            this.radioSys.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioSys.Name = "radioSys";
            this.radioSys.Size = new System.Drawing.Size(859, 24);
            this.radioSys.TabIndex = 1;
            this.radioSys.Text = "为当前计算机的所有用户设置开机启动 (&S)";
            this.radioSys.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(38, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "1";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(85, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(863, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "选择可执行文件";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(85, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(877, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "设置应用范围";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(38, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 46);
            this.label4.TabIndex = 4;
            this.label4.Text = "3";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.FormattingEnabled = true;
            this.txtPath.Location = new System.Drawing.Point(89, 102);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(859, 28);
            this.txtPath.TabIndex = 6;
            this.txtPath.SelectedIndexChanged += new System.EventHandler(this.txtPath_SelectedIndexChanged);
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // btnPath
            // 
            this.btnPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPath.Location = new System.Drawing.Point(706, 44);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(242, 46);
            this.btnPath.TabIndex = 7;
            this.btnPath.Text = "浏览 (&B) ...";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(85, 446);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(863, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "执行操作";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(38, 425);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 46);
            this.label6.TabIndex = 8;
            this.label6.Text = "4";
            // 
            // btnOn
            // 
            this.btnOn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOn.Enabled = false;
            this.btnOn.Location = new System.Drawing.Point(89, 485);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(242, 46);
            this.btnOn.TabIndex = 10;
            this.btnOn.Text = "设置开机启动 (&Y)";
            this.btnOn.UseVisualStyleBackColor = true;
            this.btnOn.Click += new System.EventHandler(this.btnOn_Click);
            // 
            // btnOff
            // 
            this.btnOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOff.Enabled = false;
            this.btnOff.Location = new System.Drawing.Point(337, 485);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(242, 46);
            this.btnOff.TabIndex = 11;
            this.btnOff.Text = "取消开机启动 (&N)";
            this.btnOff.UseVisualStyleBackColor = true;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(706, 485);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(242, 46);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "退出 (&E)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(85, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(877, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "设置应用名称（建议只有字母）";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(38, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 46);
            this.label8.TabIndex = 13;
            this.label8.Text = "2";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.FormattingEnabled = true;
            this.txtName.Location = new System.Drawing.Point(89, 222);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(859, 28);
            this.txtName.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 578);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOff);
            this.Controls.Add(this.btnOn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioSys);
            this.Controls.Add(this.radioUser);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置开机启动";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioUser;
        private System.Windows.Forms.RadioButton radioSys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox txtPath;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOn;
        private System.Windows.Forms.Button btnOff;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox txtName;
    }
}

