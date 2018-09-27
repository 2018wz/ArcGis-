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
    public partial class frm_RadiometricCalibrationIntegration : Form
    {
        public frm_RadiometricCalibrationIntegration()
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

        private void btnInputPZ_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择电流数字量文件(PZ)文件";
            openFileDialog.Filter = "(*.tif,*.tiff)|*.tif;*.tiff|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtInputPZ.Text = openFileDialog.FileName;
            }
        }

        private void btnInputZY_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择增益系数文件(ZY)文件";
            openFileDialog.Filter = "(*.tif,*.tiff)|*.tif;*.tiff|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtInputZY.Text = openFileDialog.FileName;
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
            if (txtInputDirectory.Text == "" || txtInputPZ.Text == "" || txtInputZY.Text == "")
            {
                MessageBox.Show("输入为空，请输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (radioButton2.Checked == true && txtOutputNamePlus.Text == "")
            {
                MessageBox.Show("输出的文件名后缀为空，请输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtOuputDirectory.Text == "")
            {
                MessageBox.Show("输出目录为空，请输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                COM_IDL_connectLib.COM_IDL_connect oCom = new COM_IDL_connectLib.COM_IDL_connect();
                oCom.CreateObject(0, 0, 0);
                oCom.ExecuteString(".RESET_SESSION");

                if (radioButton1.Checked == true)
                    txtOutputNamePlus.Text = "";
                string temp = "RADIOMETRIC_CALIBRATION_INTEGRATION,'" + txtInputDirectory.Text + "','" + txtInputPZ.Text + "','" + txtInputZY.Text + "','" + txtOuputDirectory.Text + "\\" + "','" + txtOutputNamePlus.Text + "'";
                oCom.ExecuteString(".compile '" + Application.StartupPath.ToString() + "\\RADIOMETRIC_CALIBRATION_INTEGRATION.pro'");
                oCom.ExecuteString(temp);
                oCom.DestroyObject();

                MessageBox.Show("运行成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //this.Close();
                txtOutputNamePlus.Visible = false;
                txtInputDirectory.Text = "";
                txtInputPZ.Text = "";
                txtInputZY.Text = "";
                txtOuputDirectory.Text = "";
                txtOutputNamePlus.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //string tmp3 = "image_stretching," + "\"" + input + "\"," + pos + "," + in_min + "," + in_max + "," + out_min + "," + out_max + ",\"" + out_name + "\"," + method + "," + ValueOrPercent;
            //oCom.ExecuteString(".compile '" + Application.StartupPath.ToString() + "\\image_stretching.pro'");
            //oCom.ExecuteString(tmp3);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtInputDirectory_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
