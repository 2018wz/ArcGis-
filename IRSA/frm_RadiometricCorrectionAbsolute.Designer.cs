namespace IRSA
{
    partial class frm_RadiometricCorrectionAbsolute
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtInputDirectory = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxBias = new System.Windows.Forms.TextBox();
            this.txtBoxGain = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(275, 245);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(137, 245);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(57, 23);
            this.btnOK.TabIndex = 41;
            this.btnOK.Text = "运行";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOutputNamePlus);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(23, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 74);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "是否添加后缀";
            // 
            // txtOutputNamePlus
            // 
            this.txtOutputNamePlus.Location = new System.Drawing.Point(283, 34);
            this.txtOutputNamePlus.Name = "txtOutputNamePlus";
            this.txtOutputNamePlus.Size = new System.Drawing.Size(73, 21);
            this.txtOutputNamePlus.TabIndex = 1;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(218, 36);
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
            this.radioButton1.Location = new System.Drawing.Point(76, 35);
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
            this.btnOutputDirectory.Location = new System.Drawing.Point(390, 198);
            this.btnOutputDirectory.Name = "btnOutputDirectory";
            this.btnOutputDirectory.Size = new System.Drawing.Size(52, 23);
            this.btnOutputDirectory.TabIndex = 38;
            this.btnOutputDirectory.Text = "浏览";
            this.btnOutputDirectory.UseVisualStyleBackColor = true;
            this.btnOutputDirectory.Click += new System.EventHandler(this.btnOutputDirectory_Click);
            // 
            // btnInputDir
            // 
            this.btnInputDir.Location = new System.Drawing.Point(390, 18);
            this.btnInputDir.Name = "btnInputDir";
            this.btnInputDir.Size = new System.Drawing.Size(52, 23);
            this.btnInputDir.TabIndex = 37;
            this.btnInputDir.Text = "浏览";
            this.btnInputDir.UseVisualStyleBackColor = true;
            this.btnInputDir.Click += new System.EventHandler(this.btnInputDir_Click);
            // 
            // txtOuputDirectory
            // 
            this.txtOuputDirectory.Location = new System.Drawing.Point(116, 200);
            this.txtOuputDirectory.Name = "txtOuputDirectory";
            this.txtOuputDirectory.Size = new System.Drawing.Size(263, 21);
            this.txtOuputDirectory.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 33;
            this.label5.Text = "选择输出目录：";
            // 
            // txtInputDirectory
            // 
            this.txtInputDirectory.Location = new System.Drawing.Point(116, 20);
            this.txtInputDirectory.Name = "txtInputDirectory";
            this.txtInputDirectory.Size = new System.Drawing.Size(263, 21);
            this.txtInputDirectory.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 34;
            this.label6.Text = "选择输入目录：";
            // 
            // txtBoxBias
            // 
            this.txtBoxBias.Location = new System.Drawing.Point(306, 66);
            this.txtBoxBias.Name = "txtBoxBias";
            this.txtBoxBias.Size = new System.Drawing.Size(73, 21);
            this.txtBoxBias.TabIndex = 31;
            this.txtBoxBias.Text = "10";
            // 
            // txtBoxGain
            // 
            this.txtBoxGain.Location = new System.Drawing.Point(116, 66);
            this.txtBoxGain.Name = "txtBoxGain";
            this.txtBoxGain.Size = new System.Drawing.Size(73, 21);
            this.txtBoxGain.TabIndex = 32;
            this.txtBoxGain.Text = "0.5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "偏置：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "增益：";
            // 
            // frm_RadiometricCorrectionAbsolute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 287);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOutputDirectory);
            this.Controls.Add(this.btnInputDir);
            this.Controls.Add(this.txtOuputDirectory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtInputDirectory);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBoxBias);
            this.Controls.Add(this.txtBoxGain);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "frm_RadiometricCorrectionAbsolute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "绝对辐射校正";
            this.Load += new System.EventHandler(this.frm_RadiometricCorrectionAbsolute_Load);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInputDirectory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxBias;
        private System.Windows.Forms.TextBox txtBoxGain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}