namespace IRSA
{
    partial class Frm_input
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_input));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenGroupSet = new System.Windows.Forms.Button();
            this.btnSaveGroupSet = new System.Windows.Forms.Button();
            this.lstBxGroup = new System.Windows.Forms.ListBox();
            this.btnGroupDelete = new System.Windows.Forms.Button();
            this.btnGroupAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveGroupData = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSelectData = new System.Windows.Forms.Button();
            this.lstBx1 = new System.Windows.Forms.ListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(393, 386);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNextStep
            // 
            this.btnNextStep.Location = new System.Drawing.Point(159, 386);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(75, 23);
            this.btnNextStep.TabIndex = 4;
            this.btnNextStep.Text = "下一步";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenGroupSet);
            this.groupBox1.Controls.Add(this.btnSaveGroupSet);
            this.groupBox1.Controls.Add(this.lstBxGroup);
            this.groupBox1.Controls.Add(this.btnGroupDelete);
            this.groupBox1.Controls.Add(this.btnGroupAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 350);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "分组";
            // 
            // btnOpenGroupSet
            // 
            this.btnOpenGroupSet.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenGroupSet.Image")));
            this.btnOpenGroupSet.Location = new System.Drawing.Point(83, 312);
            this.btnOpenGroupSet.Name = "btnOpenGroupSet";
            this.btnOpenGroupSet.Size = new System.Drawing.Size(25, 25);
            this.btnOpenGroupSet.TabIndex = 24;
            this.toolTip1.SetToolTip(this.btnOpenGroupSet, "打开组配置文件");
            this.btnOpenGroupSet.UseVisualStyleBackColor = true;
            this.btnOpenGroupSet.Click += new System.EventHandler(this.btnOpenGroupSet_Click);
            // 
            // btnSaveGroupSet
            // 
            this.btnSaveGroupSet.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveGroupSet.Image")));
            this.btnSaveGroupSet.Location = new System.Drawing.Point(114, 312);
            this.btnSaveGroupSet.Name = "btnSaveGroupSet";
            this.btnSaveGroupSet.Size = new System.Drawing.Size(25, 25);
            this.btnSaveGroupSet.TabIndex = 23;
            this.toolTip1.SetToolTip(this.btnSaveGroupSet, "保存组配置文件");
            this.btnSaveGroupSet.UseVisualStyleBackColor = true;
            this.btnSaveGroupSet.Click += new System.EventHandler(this.btnSaveGroupSet_Click);
            // 
            // lstBxGroup
            // 
            this.lstBxGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstBxGroup.Font = new System.Drawing.Font("宋体", 9F);
            this.lstBxGroup.ItemHeight = 20;
            this.lstBxGroup.Items.AddRange(new object[] {
            "第 1 组"});
            this.lstBxGroup.Location = new System.Drawing.Point(19, 23);
            this.lstBxGroup.Name = "lstBxGroup";
            this.lstBxGroup.Size = new System.Drawing.Size(120, 272);
            this.lstBxGroup.TabIndex = 0;
            this.lstBxGroup.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstBxGroup_DrawItem);
            this.lstBxGroup.SelectedIndexChanged += new System.EventHandler(this.lstBxGroup_SelectedIndexChanged);
            // 
            // btnGroupDelete
            // 
            this.btnGroupDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnGroupDelete.Image")));
            this.btnGroupDelete.Location = new System.Drawing.Point(47, 314);
            this.btnGroupDelete.Name = "btnGroupDelete";
            this.btnGroupDelete.Size = new System.Drawing.Size(20, 20);
            this.btnGroupDelete.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnGroupDelete, "删除组");
            this.btnGroupDelete.UseVisualStyleBackColor = true;
            this.btnGroupDelete.Click += new System.EventHandler(this.btnGroupDelete_Click);
            // 
            // btnGroupAdd
            // 
            this.btnGroupAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnGroupAdd.Image")));
            this.btnGroupAdd.Location = new System.Drawing.Point(19, 314);
            this.btnGroupAdd.Name = "btnGroupAdd";
            this.btnGroupAdd.Size = new System.Drawing.Size(20, 20);
            this.btnGroupAdd.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnGroupAdd, "添加组");
            this.btnGroupAdd.UseVisualStyleBackColor = true;
            this.btnGroupAdd.Click += new System.EventHandler(this.btnGroupAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSaveGroupData);
            this.groupBox2.Controls.Add(this.btnUp);
            this.groupBox2.Controls.Add(this.btnDown);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnSelectData);
            this.groupBox2.Controls.Add(this.lstBx1);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(183, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 350);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "第 1 组";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "传感器高度角影像:";
            // 
            // btnSaveGroupData
            // 
            this.btnSaveGroupData.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveGroupData.Image")));
            this.btnSaveGroupData.Location = new System.Drawing.Point(386, 312);
            this.btnSaveGroupData.Name = "btnSaveGroupData";
            this.btnSaveGroupData.Size = new System.Drawing.Size(25, 25);
            this.btnSaveGroupData.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btnSaveGroupData, "保存该组数据");
            this.btnSaveGroupData.UseVisualStyleBackColor = true;
            this.btnSaveGroupData.Click += new System.EventHandler(this.btnSaveGroupData_Click);
            // 
            // btnUp
            // 
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(238, 314);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(20, 20);
            this.btnUp.TabIndex = 17;
            this.toolTip1.SetToolTip(this.btnUp, "上移");
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(277, 314);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(20, 20);
            this.btnDown.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btnDown, "下移");
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(316, 314);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(20, 20);
            this.btnDelete.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btnDelete, "删除选中文件");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(196, 314);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(20, 20);
            this.btnAdd.TabIndex = 19;
            this.toolTip1.SetToolTip(this.btnAdd, "添加单个文件");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSelectData
            // 
            this.btnSelectData.Location = new System.Drawing.Point(22, 313);
            this.btnSelectData.Name = "btnSelectData";
            this.btnSelectData.Size = new System.Drawing.Size(105, 23);
            this.btnSelectData.TabIndex = 16;
            this.btnSelectData.Text = "添加该组数据";
            this.btnSelectData.UseVisualStyleBackColor = true;
            this.btnSelectData.Click += new System.EventHandler(this.btnSelectData_Click);
            // 
            // lstBx1
            // 
            this.lstBx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstBx1.Font = new System.Drawing.Font("宋体", 9F);
            this.lstBx1.FormattingEnabled = true;
            this.lstBx1.HorizontalExtent = 1000;
            this.lstBx1.HorizontalScrollbar = true;
            this.lstBx1.ItemHeight = 30;
            this.lstBx1.Location = new System.Drawing.Point(151, 35);
            this.lstBx1.Name = "lstBx1";
            this.lstBx1.Size = new System.Drawing.Size(278, 261);
            this.lstBx1.TabIndex = 15;
            this.lstBx1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstBx1_DrawItem);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(74, 194);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 12);
            this.label17.TabIndex = 14;
            this.label17.Text = "近红外波段:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(86, 166);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 12);
            this.label16.TabIndex = 13;
            this.label16.Text = "绿光波段:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(86, 224);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 12;
            this.label15.Text = "红光波段:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 136);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 12);
            this.label14.TabIndex = 11;
            this.label14.Text = "热红外劈窗波段2(B4):";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 105);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(125, 12);
            this.label13.TabIndex = 10;
            this.label13.Text = "热红外劈窗波段1(B3):";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(38, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 12);
            this.label12.TabIndex = 9;
            this.label12.Text = "水汽吸收波段(B2):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "水汽窗口波段(B1):";
            // 
            // Frm_input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 421);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNextStep);
            this.Name = "Frm_input";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输入设置";
            this.toolTip1.SetToolTip(this, "保存到组配置文件");
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstBxGroup;
        private System.Windows.Forms.Button btnGroupDelete;
        private System.Windows.Forms.Button btnGroupAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSelectData;
        private System.Windows.Forms.ListBox lstBx1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSaveGroupData;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveGroupSet;
        private System.Windows.Forms.Button btnOpenGroupSet;
    }
}

