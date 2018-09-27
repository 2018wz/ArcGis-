namespace IRSA
{
    partial class frm_Stretch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Stretch));
            this.txt_out_max = new System.Windows.Forms.TextBox();
            this.txt_out_min = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_in_min = new System.Windows.Forms.TextBox();
            this.txt_in_max = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_method = new System.Windows.Forms.ComboBox();
            this.btn_output = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbLayerBand = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancle = new System.Windows.Forms.Button();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_out_max
            // 
            this.txt_out_max.Location = new System.Drawing.Point(333, 320);
            this.txt_out_max.Name = "txt_out_max";
            this.txt_out_max.Size = new System.Drawing.Size(32, 21);
            this.txt_out_max.TabIndex = 0;
            this.txt_out_max.Text = "255";
            // 
            // txt_out_min
            // 
            this.txt_out_min.Location = new System.Drawing.Point(283, 320);
            this.txt_out_min.Name = "txt_out_min";
            this.txt_out_min.Size = new System.Drawing.Size(32, 21);
            this.txt_out_min.TabIndex = 0;
            this.txt_out_min.Text = "0";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(95, 441);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(68, 25);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "拉伸";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(232, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "拉伸到:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.Location = new System.Drawing.Point(32, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "像素范围:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "-";
            // 
            // txt_in_min
            // 
            this.txt_in_min.Location = new System.Drawing.Point(95, 320);
            this.txt_in_min.Name = "txt_in_min";
            this.txt_in_min.Size = new System.Drawing.Size(32, 21);
            this.txt_in_min.TabIndex = 6;
            // 
            // txt_in_max
            // 
            this.txt_in_max.Location = new System.Drawing.Point(146, 320);
            this.txt_in_max.Name = "txt_in_max";
            this.txt_in_max.Size = new System.Drawing.Size(32, 21);
            this.txt_in_max.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F);
            this.label5.Location = new System.Drawing.Point(32, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "拉伸方法：";
            // 
            // cmb_method
            // 
            this.cmb_method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_method.FormattingEnabled = true;
            this.cmb_method.Items.AddRange(new object[] {
            "Linear",
            "Equalize",
            "Gaussian",
            "Square root"});
            this.cmb_method.Location = new System.Drawing.Point(95, 362);
            this.cmb_method.Name = "cmb_method";
            this.cmb_method.Size = new System.Drawing.Size(88, 20);
            this.cmb_method.TabIndex = 9;
            // 
            // btn_output
            // 
            this.btn_output.Image = ((System.Drawing.Image)(resources.GetObject("btn_output.Image")));
            this.btn_output.Location = new System.Drawing.Point(307, 393);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(28, 28);
            this.btn_output.TabIndex = 14;
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.btn_output_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(95, 398);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(200, 21);
            this.txtOutput.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.Location = new System.Drawing.Point(32, 401);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "输出路径:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F);
            this.label8.Location = new System.Drawing.Point(32, 288);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "选择波段：";
            // 
            // cmbLayerBand
            // 
            this.cmbLayerBand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayerBand.FormattingEnabled = true;
            this.cmbLayerBand.Location = new System.Drawing.Point(95, 285);
            this.cmbLayerBand.Name = "cmbLayerBand";
            this.cmbLayerBand.Size = new System.Drawing.Size(88, 20);
            this.cmbLayerBand.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(336, 401);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "(可选择输出)";
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(234, 441);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(68, 25);
            this.btnCancle.TabIndex = 1;
            this.btnCancle.Text = "关闭";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Location = new System.Drawing.Point(13, 13);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(392, 256);
            this.axMapControl1.TabIndex = 17;
            // 
            // frm_Stretch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(417, 484);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_output);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.cmbLayerBand);
            this.Controls.Add(this.cmb_method);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_in_min);
            this.Controls.Add(this.txt_in_max);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txt_out_min);
            this.Controls.Add(this.txt_out_max);
            this.Name = "frm_Stretch";
            this.Text = "图像拉伸";
            this.Load += new System.EventHandler(this.frm_Stretch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_out_max;
        private System.Windows.Forms.TextBox txt_out_min;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_in_min;
        private System.Windows.Forms.TextBox txt_in_max;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_method;
        private System.Windows.Forms.Button btn_output;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbLayerBand;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancle;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;

    }
}