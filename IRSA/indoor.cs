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
    public partial class indoor : Form
    {
        public indoor()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtOutputNamePlus.Visible = false;
        }

        private void btnInputDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.Description = "选择输入文件的目录";
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                txtInputDirectory.Text = folderDialog.SelectedPath;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                //txtOutputNamePlus.Text = "";
                txtOutputNamePlus.Visible = true;
            }
            else
            {
                txtOutputNamePlus.Visible = false;
            }
        }

        private void btnOutputDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.Description = "选择输出文件的目录";
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                txtOuputDirectory.Text = folderDialog.SelectedPath;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //COM_IDL_connectLib.COM_IDL_connect oCom = new COM_IDL_connectLib.COM_IDL_connect();
                COM_IDL_connectLib.COM_IDL_connect oCom = new COM_IDL_connectLib.COM_IDL_connect();
                oCom.CreateObject(0, 0, 0);
                //oCom.ExecuteString(".RESET_SESSION");
                string temp = "TOAbrightnessTemperature,'";
                oCom.ExecuteString(".compile '" + Application.StartupPath.ToString() + "\\TOAbrightnessTemperature.pro'");
                oCom.ExecuteString(temp);

                MessageBox.Show("运行成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("运行失败或者部分文件运行失败，请查看运行结果！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            //string tmp3 = "image_stretching," + "\"" + input + "\"," + pos + "," + in_min + "," + in_max + "," + out_min + "," + out_max + ",\"" + out_name + "\"," + method + "," + ValueOrPercent;
            //oCom.ExecuteString(".compile '" + Application.StartupPath.ToString() + "\\image_stretching.pro'");
            //oCom.ExecuteString(tmp3);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
