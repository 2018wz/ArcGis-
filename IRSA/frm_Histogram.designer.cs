namespace IRSA
{
    partial class frm_Histogram
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelMax = new System.Windows.Forms.Label();
            this.labelMean = new System.Windows.Forms.Label();
            this.labelStd = new System.Windows.Forms.Label();
            this.labelEntropy = new System.Windows.Forms.Label();
            this.labelMeanTiDu = new System.Windows.Forms.Label();
            this.labelArticulation = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxBand = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // zg1
            // 
            this.zg1.Dock = System.Windows.Forms.DockStyle.Top;
            this.zg1.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.zg1.Location = new System.Drawing.Point(0, 0);
            this.zg1.Name = "zg1";
            this.zg1.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zg1.ScrollGrace = 0D;
            this.zg1.ScrollMaxX = 0D;
            this.zg1.ScrollMaxY = 0D;
            this.zg1.ScrollMaxY2 = 0D;
            this.zg1.ScrollMinX = 0D;
            this.zg1.ScrollMinY = 0D;
            this.zg1.ScrollMinY2 = 0D;
            this.zg1.Size = new System.Drawing.Size(417, 271);
            this.zg1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "最小值:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "最大值:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "平均值:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "标准差:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(139, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "信息熵:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(263, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "平均梯度:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "清晰度:";
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(60, 34);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(35, 12);
            this.labelMin.TabIndex = 18;
            this.labelMin.Text = "     ";
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(192, 34);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(35, 12);
            this.labelMax.TabIndex = 18;
            this.labelMax.Text = "     ";
            // 
            // labelMean
            // 
            this.labelMean.AutoSize = true;
            this.labelMean.Location = new System.Drawing.Point(320, 34);
            this.labelMean.Name = "labelMean";
            this.labelMean.Size = new System.Drawing.Size(35, 12);
            this.labelMean.TabIndex = 18;
            this.labelMean.Text = "     ";
            // 
            // labelStd
            // 
            this.labelStd.AutoSize = true;
            this.labelStd.Location = new System.Drawing.Point(60, 65);
            this.labelStd.Name = "labelStd";
            this.labelStd.Size = new System.Drawing.Size(35, 12);
            this.labelStd.TabIndex = 18;
            this.labelStd.Text = "     ";
            // 
            // labelEntropy
            // 
            this.labelEntropy.AutoSize = true;
            this.labelEntropy.Location = new System.Drawing.Point(192, 65);
            this.labelEntropy.Name = "labelEntropy";
            this.labelEntropy.Size = new System.Drawing.Size(35, 12);
            this.labelEntropy.TabIndex = 18;
            this.labelEntropy.Text = "     ";
            // 
            // labelMeanTiDu
            // 
            this.labelMeanTiDu.AutoSize = true;
            this.labelMeanTiDu.Location = new System.Drawing.Point(328, 65);
            this.labelMeanTiDu.Name = "labelMeanTiDu";
            this.labelMeanTiDu.Size = new System.Drawing.Size(35, 12);
            this.labelMeanTiDu.TabIndex = 18;
            this.labelMeanTiDu.Text = "     ";
            // 
            // labelArticulation
            // 
            this.labelArticulation.AutoSize = true;
            this.labelArticulation.Location = new System.Drawing.Point(60, 97);
            this.labelArticulation.Name = "labelArticulation";
            this.labelArticulation.Size = new System.Drawing.Size(35, 12);
            this.labelArticulation.TabIndex = 18;
            this.labelArticulation.Text = "     ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "选择波段:";
            // 
            // comboBoxBand
            // 
            this.comboBoxBand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBand.FormattingEnabled = true;
            this.comboBoxBand.Location = new System.Drawing.Point(77, 288);
            this.comboBoxBand.Name = "comboBoxBand";
            this.comboBoxBand.Size = new System.Drawing.Size(121, 20);
            this.comboBoxBand.TabIndex = 20;
            this.comboBoxBand.SelectedIndexChanged += new System.EventHandler(this.comboBoxBand_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labelMeanTiDu);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.labelMean);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labelEntropy);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labelMax);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.labelArticulation);
            this.groupBox1.Controls.Add(this.labelMin);
            this.groupBox1.Controls.Add(this.labelStd);
            this.groupBox1.Location = new System.Drawing.Point(12, 324);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 135);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图像信息";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.Location = new System.Drawing.Point(11, 465);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(394, 120);
            this.dataGridView1.TabIndex = 22;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.Width = 54;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "DN值";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 54;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "数量";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 54;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "数量小计";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 78;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "百分比";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 66;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "百分比小计";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 90;
            // 
            // frm_Histogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 601);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxBand);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.zg1);
            this.Name = "frm_Histogram";
            this.Text = "直方图";
            this.Load += new System.EventHandler(this.frm_Histogram_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Label labelMean;
        private System.Windows.Forms.Label labelStd;
        private System.Windows.Forms.Label labelEntropy;
        private System.Windows.Forms.Label labelMeanTiDu;
        private System.Windows.Forms.Label labelArticulation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxBand;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;

    }
}