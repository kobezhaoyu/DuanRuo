namespace CVR100A_U_DSDK_Demo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.个人信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询已签到考生信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加异常考生ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询未签到考生信息ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.考场设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入考生信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置考试名称ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置考场ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置考号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.密码修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.个人信息ToolStripMenuItem,
            this.全部信息ToolStripMenuItem,
            this.考场设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(897, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 个人信息ToolStripMenuItem
            // 
            this.个人信息ToolStripMenuItem.Name = "个人信息ToolStripMenuItem";
            this.个人信息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.个人信息ToolStripMenuItem.Text = "个人信息";
            this.个人信息ToolStripMenuItem.Click += new System.EventHandler(this.个人信息ToolStripMenuItem_Click);
            // 
            // 全部信息ToolStripMenuItem
            // 
            this.全部信息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询已签到考生信息ToolStripMenuItem,
            this.添加异常考生ToolStripMenuItem,
            this.查询未签到考生信息ToolStripMenuItem1});
            this.全部信息ToolStripMenuItem.Name = "全部信息ToolStripMenuItem";
            this.全部信息ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.全部信息ToolStripMenuItem.Text = "考生信息管理";
            // 
            // 查询已签到考生信息ToolStripMenuItem
            // 
            this.查询已签到考生信息ToolStripMenuItem.Name = "查询已签到考生信息ToolStripMenuItem";
            this.查询已签到考生信息ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.查询已签到考生信息ToolStripMenuItem.Text = "查询签到考生信息";
            this.查询已签到考生信息ToolStripMenuItem.Click += new System.EventHandler(this.查询考生信息ToolStripMenuItem_Click);
            // 
            // 添加异常考生ToolStripMenuItem
            // 
            this.添加异常考生ToolStripMenuItem.Name = "添加异常考生ToolStripMenuItem";
            this.添加异常考生ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.添加异常考生ToolStripMenuItem.Text = "添加异常考生";
            this.添加异常考生ToolStripMenuItem.Click += new System.EventHandler(this.添加异常考生ToolStripMenuItem_Click);
            // 
            // 查询未签到考生信息ToolStripMenuItem1
            // 
            this.查询未签到考生信息ToolStripMenuItem1.Name = "查询未签到考生信息ToolStripMenuItem1";
            this.查询未签到考生信息ToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.查询未签到考生信息ToolStripMenuItem1.Text = "查询未签到考生信息";
            this.查询未签到考生信息ToolStripMenuItem1.Click += new System.EventHandler(this.查询未签到考生信息ToolStripMenuItem1_Click);
            // 
            // 考场设置ToolStripMenuItem
            // 
            this.考场设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入考生信息ToolStripMenuItem,
            this.设置考试名称ToolStripMenuItem,
            this.配置考场ToolStripMenuItem,
            this.设置考号ToolStripMenuItem,
            this.密码修改ToolStripMenuItem});
            this.考场设置ToolStripMenuItem.Name = "考场设置ToolStripMenuItem";
            this.考场设置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.考场设置ToolStripMenuItem.Text = "系统设置";
            // 
            // 导入考生信息ToolStripMenuItem
            // 
            this.导入考生信息ToolStripMenuItem.Name = "导入考生信息ToolStripMenuItem";
            this.导入考生信息ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.导入考生信息ToolStripMenuItem.Text = "导入考生信息";
            this.导入考生信息ToolStripMenuItem.Click += new System.EventHandler(this.导入考生信息ToolStripMenuItem_Click);
            // 
            // 设置考试名称ToolStripMenuItem
            // 
            this.设置考试名称ToolStripMenuItem.Name = "设置考试名称ToolStripMenuItem";
            this.设置考试名称ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设置考试名称ToolStripMenuItem.Text = "设置考试名称";
            this.设置考试名称ToolStripMenuItem.Visible = false;
            this.设置考试名称ToolStripMenuItem.Click += new System.EventHandler(this.设置考试名称ToolStripMenuItem_Click);
            // 
            // 配置考场ToolStripMenuItem
            // 
            this.配置考场ToolStripMenuItem.Name = "配置考场ToolStripMenuItem";
            this.配置考场ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.配置考场ToolStripMenuItem.Text = "设置考场";
            this.配置考场ToolStripMenuItem.Click += new System.EventHandler(this.设置考场ToolStripMenuItem_Click);
            // 
            // 设置考号ToolStripMenuItem
            // 
            this.设置考号ToolStripMenuItem.Name = "设置考号ToolStripMenuItem";
            this.设置考号ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设置考号ToolStripMenuItem.Text = "设置考号";
            this.设置考号ToolStripMenuItem.Click += new System.EventHandler(this.设置考号ToolStripMenuItem_Click);
            // 
            // 密码修改ToolStripMenuItem
            // 
            this.密码修改ToolStripMenuItem.Name = "密码修改ToolStripMenuItem";
            this.密码修改ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.密码修改ToolStripMenuItem.Text = "密码修改";
            this.密码修改ToolStripMenuItem.Click += new System.EventHandler(this.密码修改ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 507);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(897, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(135, 21);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(612, 21);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Right | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(135, 21);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(897, 533);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主界面";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 个人信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 考场设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入考生信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置考号ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置考场ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置考试名称ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询已签到考生信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加异常考生ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 密码修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询未签到考生信息ToolStripMenuItem1;
    }
}