using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace IRSA
{
    public partial class frm_shape : Form
    {
        public frm_shape()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择多光谱影像";
            openFileDialog.Filter = "(*.tif,*.tiff)|*.tif;*.tiff|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                textBox1.Text = openFileDialog.FileName;
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
            FileStream fs =File.Open( "sharpen.txt", FileMode.Truncate,FileAccess.ReadWrite, FileShare.Read);
            StreamWriter sr = new StreamWriter(fs);
            sr.WriteLine(textBox1.Text );//开始写入值
            sr.WriteLine(textBox3.Text);
            sr.WriteLine(comboBox1.SelectedIndex);
            sr.WriteLine(textBox3.Text);
            sr.Close();
            fs.Close();
            MessageBox.Show("文件写入成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            try
            {
                COM_IDL_connectLib.ICOM_IDL_connect oCom = new COM_IDL_connectLib.COM_IDL_connect();
                oCom.CreateObject(0, 0, 0);
                //oCom.ExecuteString(".compile '" + Application.StartupPath.ToString() + "\\mytext.pro'");
                

                string temp = "cal_sharpen1,'" ;
                oCom.ExecuteString(".compile '" + Application.StartupPath.ToString() + "\\cal_sharpen1.pro'");
                oCom.ExecuteString(temp);
                MessageBox.Show("运行成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                
                
                
                textBox1.Text = "";
                textBox3.Text = "";
                //comboBox1.Text = "";
                //oCom.ExecuteString(".compile '" + Application.StartupPath.ToString() + "\\cal_sharpen1.pro'");
                //string temp = "cal_sharpen1,'" + textBox1.Text + "'," + textBox3.Text + "'";
                // oCom.ExecuteString(temp);
                //MessageBox.Show("运行成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //textBox1.Text = "";
                //textBox3.Text = "";
                //comboBox1.Text = "";
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frm_shape_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择多光谱影像";
            openFileDialog.Filter = "(*.tif,*.tiff)|*.tif;*.tiff|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = openFileDialog.FileName;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
