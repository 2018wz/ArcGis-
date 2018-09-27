namespace IRSA
{
    partial class ins
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOutputNamePlus = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnOutputDirectory = new System.Windows.Forms.Button();
            this.btnInputDir = new System.Windows.Forms.Button();
            this.txtOuputDirectory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInputDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(269, 218);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 23);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(116, 218);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(55, 23);
            this.btnOK.TabIndex = 28;
            this.btnOK.Text = "运行";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOutputNamePlus);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(13, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 74);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "是否添加后缀";
            // 
            // txtOutputNamePlus
            // 
            this.txtOutputNamePlus.Location = new System.Drawing.Point(266, 35);
            this.txtOutputNamePlus.Name = "txtOutputNamePlus";
            this.txtOutputNamePlus.Size = new System.Drawing.Size(100, 21);
            this.txtOutputNamePlus.TabIndex = 1;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(211, 36);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.Text = "添加：";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(48, 36);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "不添加";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btnOutputDirectory
            // 
            this.btnOutputDirectory.Location = new System.Drawing.Point(385, 170);
            this.btnOutputDirectory.Name = "btnOutputDirectory";
            this.btnOutputDirectory.Size = new System.Drawing.Size(52, 23);
            this.btnOutputDirectory.TabIndex = 25;
            this.btnOutputDirectory.Text = "浏览";
            this.btnOutputDirectory.UseVisualStyleBackColor = true;
            this.btnOutputDirectory.Click += new System.EventHandler(this.btnOutputDirectory_Click);
            // 
            // btnInputDir
            // 
            this.btnInputDir.Location = new System.Drawing.Point(385, 22);
            this.btnInputDir.Name = "btnInputDir";
            this.btnInputDir.Size = new System.Drawing.Size(52, 23);
            this.btnInputDir.TabIndex = 24;
            this.btnInputDir.Text = "浏览";
            this.btnInputDir.UseVisualStyleBackColor = true;
            this.btnInputDir.Click += new System.EventHandler(this.btnInputDir_Click);
            // 
            // txtOuputDirectory
            // 
            this.txtOuputDirectory.Location = new System.Drawing.Point(116, 172);
            this.txtOuputDirectory.Name = "txtOuputDirectory";
            this.txtOuputDirectory.Size = new System.Drawing.Size(263, 21);
            this.txtOuputDirectory.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "选择输出目录：";
            // 
            // txtInputDirectory
            // 
            this.txtInputDirectory.Location = new System.Drawing.Point(116, 24);
            this.txtInputDirectory.Name = "txtInputDirectory";
            this.txtInputDirectory.Size = new System.Drawing.Size(263, 21);
            this.txtInputDirectory.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "选择输入目录：";
            // 
            // frm_RadiometricCorrectionRalative
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 267);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOutputDirectory);
            this.Controls.Add(this.btnInputDir);
            this.Controls.Add(this.txtOuputDirectory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInputDirectory);
            this.Controls.Add(this.label1);
            this.Name = "frm_RadiometricCorrectionRalative";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "相对辐射校正";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtOutputNamePlus;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btnOutputDirectory;
        private System.Windows.Forms.Button btnInputDir;
        private System.Windows.Forms.TextBox txtOuputDirectory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInputDirectory;
        private System.Windows.Forms.Label label1;
    }
}