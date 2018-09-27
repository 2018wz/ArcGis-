using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;

namespace IRSA
{
    public partial class frm_Rotate : Form
    {
        IActiveView frmRotate_active;
        public static int flag = 0;
        public frm_Rotate(IActiveView actview)
        {
            InitializeComponent();
            this.frmRotate_active = actview;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            IDisplayTransformation trans = frmRotate_active.ScreenDisplay.DisplayTransformation;
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                trans.Rotation = Convert.ToDouble(comboBox1.Text);
                frmRotate_active.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            IScreenDisplay display = frmRotate_active.ScreenDisplay;
            display.TrackRotate();
            IDisplayTransformation trans = display.DisplayTransformation;
            comboBox1.Text =Math.Round(trans.Rotation,2).ToString();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            radioButton2.Checked = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                flag = 1;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                flag = 0;
            }
        }

        private void frm_Rotate_FormClosing(object sender, FormClosingEventArgs e)
        {
            flag = 0;
        }

        private void frm_Rotate_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "0"; 
        }


    }
}
