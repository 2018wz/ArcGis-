using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IRSA
{
    public partial class frm_EdgeEnhance : Form
    {
        public frm_EdgeEnhance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "选择输入文件夹";
            if (DialogResult.OK == dialog.ShowDialog())
            {
                textBox1.Text = dialog.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "选择输出文件夹";
            if (DialogResult.OK == dialog.ShowDialog())
            {
                textBox2.Text = dialog.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                COM_IDL_connectLib.ICOM_IDL_connect oCom = new COM_IDL_connectLib.COM_IDL_connect();
                oCom.CreateObject(0, 0, 0);
                string temp = "edgeEnhance20141217,'" + textBox1.Text + "'," + comboBox1.SelectedIndex + ",'" + textBox2.Text + "'";
                //oCom.SetIDLVariable("inputfolder", textBox1.Text.ToString().Trim());
                //oCom.SetIDLVariable("method", comboBox1.SelectedIndex);
                //oCom.SetIDLVariable("outputfolder", textBox2.Text.ToString().Trim());

                oCom.ExecuteString(".compile '" + Application.StartupPath.ToString() + "\\edgeEnhance20141217.pro'");
                oCom.ExecuteString(temp);
                //oCom.ExecuteString("edgeEnhance20141217,inputfolder,method,outputfolder");
                MessageBox.Show("运行成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //this.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
