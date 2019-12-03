namespace CVR100A_U_DSDK_Demo
{
    partial class importInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(importInfo));
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_Config = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbKaochang = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.btn_Import = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(599, 123);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(123, 43);
            this.btn_clear.TabIndex = 23;
            this.btn_clear.Text = "清空考场准考证号";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_Config
            // 
            this.btn_Config.Location = new System.Drawing.Point(599, 54);
            this.btn_Config.Name = "btn_Config";
            this.btn_Config.Size = new System.Drawing.Size(121, 43);
            this.btn_Config.TabIndex = 24;
            this.btn_Config.Text = "配置准考证号";
            this.btn_Config.UseVisualStyleBackColor = true;
            this.btn_Config.Click += new System.EventHandler(this.btn_Config_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbKaochang);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.txtFileName);
            this.groupBox3.Controls.Add(this.save);
            this.groupBox3.Controls.Add(this.btn_Import);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(557, 192);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "导入考生信息";
            // 
            // cmbKaochang
            // 
            this.cmbKaochang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKaochang.FormattingEnabled = true;
            this.cmbKaochang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbKaochang.Location = new System.Drawing.Point(107, 54);
            this.cmbKaochang.Name = "cmbKaochang";
            this.cmbKaochang.Size = new System.Drawing.Size(115, 20);
            this.cmbKaochang.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(27, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 1;
            this.label13.Text = "分配考场：";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(447, 136);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 34);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "清除数据";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Enabled = false;
            this.txtFileName.Location = new System.Drawing.Point(29, 111);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(250, 21);
            this.txtFileName.TabIndex = 16;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(447, 25);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(93, 76);
            this.save.TabIndex = 2;
            this.save.Text = "执  行";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // btn_Import
            // 
            this.btn_Import.Location = new System.Drawing.Point(303, 109);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(75, 23);
            this.btn_Import.TabIndex = 15;
            this.btn_Import.Text = "导入文件";
            this.btn_Import.UseVisualStyleBackColor = true;
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click);
            // 
            // importInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 219);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_Config);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "importInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入考生信息";
            this.Load += new System.EventHandler(this.importInfo_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_Config;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbKaochang;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button btn_Import;
    }
}