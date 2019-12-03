namespace CVR100A_U_DSDK_Demo
{
    partial class kaochangForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kaochangForm));
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_Modify = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txtKCMC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckListBoxCydw = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btn_Del
            // 
            this.btn_Del.Location = new System.Drawing.Point(200, 70);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(53, 23);
            this.btn_Del.TabIndex = 9;
            this.btn_Del.Text = "删 除";
            this.btn_Del.UseVisualStyleBackColor = true;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // btn_Modify
            // 
            this.btn_Modify.Location = new System.Drawing.Point(200, 41);
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Size = new System.Drawing.Size(53, 23);
            this.btn_Modify.TabIndex = 8;
            this.btn_Modify.Text = "修 改";
            this.btn_Modify.UseVisualStyleBackColor = true;
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(200, 12);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(53, 23);
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "新 增";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txtKCMC
            // 
            this.txtKCMC.Location = new System.Drawing.Point(82, 24);
            this.txtKCMC.Name = "txtKCMC";
            this.txtKCMC.Size = new System.Drawing.Size(104, 21);
            this.txtKCMC.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "考场名称：";
            // 
            // ckListBoxCydw
            // 
            this.ckListBoxCydw.FormattingEnabled = true;
            this.ckListBoxCydw.Location = new System.Drawing.Point(21, 100);
            this.ckListBoxCydw.Name = "ckListBoxCydw";
            this.ckListBoxCydw.Size = new System.Drawing.Size(238, 244);
            this.ckListBoxCydw.TabIndex = 10;
            this.ckListBoxCydw.SelectedIndexChanged += new System.EventHandler(this.ckListBoxCydw_SelectedIndexChanged);
            // 
            // kaochangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(282, 360);
            this.Controls.Add(this.btn_Del);
            this.Controls.Add(this.btn_Modify);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txtKCMC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckListBoxCydw);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "kaochangForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置考场";
            this.Load += new System.EventHandler(this.kaochangForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Del;
        private System.Windows.Forms.Button btn_Modify;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txtKCMC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox ckListBoxCydw;
    }
}