namespace CVR100A_U_DSDK_Demo
{
    partial class examNameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(examNameForm));
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_Modify = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckListBoxName = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btn_Del
            // 
            this.btn_Del.Location = new System.Drawing.Point(242, 71);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(53, 23);
            this.btn_Del.TabIndex = 15;
            this.btn_Del.Text = "删 除";
            this.btn_Del.UseVisualStyleBackColor = true;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // btn_Modify
            // 
            this.btn_Modify.Location = new System.Drawing.Point(242, 42);
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Size = new System.Drawing.Size(53, 23);
            this.btn_Modify.TabIndex = 14;
            this.btn_Modify.Text = "修 改";
            this.btn_Modify.UseVisualStyleBackColor = true;
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(242, 13);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(53, 23);
            this.btn_Save.TabIndex = 13;
            this.btn_Save.Text = "新 增";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(86, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(140, 21);
            this.txtName.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "考试名称：";
            // 
            // ckListBoxName
            // 
            this.ckListBoxName.FormattingEnabled = true;
            this.ckListBoxName.Location = new System.Drawing.Point(22, 101);
            this.ckListBoxName.Name = "ckListBoxName";
            this.ckListBoxName.Size = new System.Drawing.Size(267, 244);
            this.ckListBoxName.TabIndex = 16;
            this.ckListBoxName.SelectedIndexChanged += new System.EventHandler(this.ckListBoxCydw_SelectedIndexChanged);
            // 
            // examNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 364);
            this.Controls.Add(this.btn_Del);
            this.Controls.Add(this.btn_Modify);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckListBoxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "examNameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置考试名称";
            this.Load += new System.EventHandler(this.examNameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Del;
        private System.Windows.Forms.Button btn_Modify;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox ckListBoxName;

    }
}