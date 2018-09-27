namespace IRSA
{
    partial class ddd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ddd));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_feature = new System.Windows.Forms.Button();
            this.cmbInputFeature = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btn_output = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_raster = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbInputRaster = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择矢量：";
            // 
            // btn_OK
            // 
            this.btn_OK.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OK.Location = new System.Drawing.Point(106, 158);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(53, 23);
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_feature
            // 
            this.btn_feature.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_feature.Image = ((System.Drawing.Image)(resources.GetObject("btn_feature.Image")));
            this.btn_feature.Location = new System.Drawing.Point(345, 64);
            this.btn_feature.Name = "btn_feature";
            this.btn_feature.Size = new System.Drawing.Size(28, 28);
            this.btn_feature.TabIndex = 7;
            this.btn_feature.UseVisualStyleBackColor = true;
            this.btn_feature.Click += new System.EventHandler(this.btn_feature_Click);
            // 
            // cmbInputFeature
            // 
            this.cmbInputFeature.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbInputFeature.FormattingEnabled = true;
            this.cmbInputFeature.Location = new System.Drawing.Point(95, 69);
            this.cmbInputFeature.Name = "cmbInputFeature";
            this.cmbInputFeature.Size = new System.Drawing.Size(244, 20);
            this.cmbInputFeature.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "输出影像：";
            // 
            // txtOutput
            // 
            this.txtOutput.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOutput.Location = new System.Drawing.Point(95, 116);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(244, 21);
            this.txtOutput.TabIndex = 11;
            // 
            // btn_output
            // 
            this.btn_output.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_output.Image = ((System.Drawing.Image)(resources.GetObject("btn_output.Image")));
            this.btn_output.Location = new System.Drawing.Point(345, 111);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(28, 28);
            this.btn_output.TabIndex = 12;
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.btn_output_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.Location = new System.Drawing.Point(257, 158);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(53, 23);
            this.btn_Cancel.TabIndex = 13;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_raster
            // 
            this.btn_raster.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_raster.Image = ((System.Drawing.Image)(resources.GetObject("btn_raster.Image")));
            this.btn_raster.Location = new System.Drawing.Point(345, 20);
            this.btn_raster.Name = "btn_raster";
            this.btn_raster.Size = new System.Drawing.Size(28, 28);
            this.btn_raster.TabIndex = 4;
            this.btn_raster.UseVisualStyleBackColor = true;
            this.btn_raster.Click += new System.EventHandler(this.btn_raster_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "选择影像：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cmbInputRaster
            // 
            this.cmbInputRaster.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbInputRaster.FormattingEnabled = true;
            this.cmbInputRaster.Location = new System.Drawing.Point(95, 25);
            this.cmbInputRaster.Name = "cmbInputRaster";
            this.cmbInputRaster.Size = new System.Drawing.Size(244, 20);
            this.cmbInputRaster.TabIndex = 8;
            // 
            // ddd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 205);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_output);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbInputFeature);
            this.Controls.Add(this.cmbInputRaster);
            this.Controls.Add(this.btn_feature);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_raster);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ddd";
            this.Text = "影像裁切";
            this.Load += new System.EventHandler(this.ddd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_feature;
        private System.Windows.Forms.ComboBox cmbInputFeature;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btn_output;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_raster;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbInputRaster;
    }
}