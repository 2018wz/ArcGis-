using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace IRSA
{
    public partial class Frm_Params : Form
    {
        //Dictionary<int, List<string>> allListFiles = new Dictionary<int, List<string>>();
        List<string> allListFiles = new List<string>();
        public Frm_Params()
        {
            InitializeComponent();
        }

        public Frm_Params(List<string> allListFile)
        {
            InitializeComponent();
            allListFiles = allListFile;
        }

        private void Frm_Params_Load(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Sun = cmbSunZenith.SelectedItem.ToString();
            string longitude = cmbProfile.SelectedItem.ToString();
            List<string> list = XmlOperate.getNodeValue(Sun, longitude);
            txtaVegetation.Text = list[0];
            txtbVegetation.Text = list[1];
            txtaSoil.Text = list[2];
            txtbSoil.Text = list[3];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Sun = cmbSunZenith.SelectedItem.ToString();
            string longitude = cmbProfile.SelectedItem.ToString();
            List<string> list_veget = new List<string>();
            list_veget.Add(txtaVegetation.Text);
            list_veget.Add(txtbVegetation.Text);
            List<string> list_soil = new List<string>();
            list_soil.Add(txtaSoil.Text);
            list_soil.Add(txtbSoil.Text);
            try
            {
                XmlOperate.setNodeValue(Sun, longitude, list_veget, list_soil);
                MessageBox.Show("保存成功！");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            string Sun = cmbSunZenith.SelectedItem.ToString();
            if (cmbProfile.SelectedItem!=null)
            {
                string longitude = cmbProfile.SelectedItem.ToString();
                List<string> list = XmlOperate.getNodeValue(Sun, longitude);
                txtaVegetation.Text = list[0];
                txtbVegetation.Text = list[1];
                txtaSoil.Text = list[2];
                txtbSoil.Text = list[3];
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            //if (NumberMatch.Regex(textBox1.Text))
            //{
            //    textBox1.Text = null;
            //    //textBox1.Focus();
            //}
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            //if (NumberMatch.Regex(textBox5.Text))
            //{
            //    textBox5.Text = null;
            //    //textBox5.Focus();
            //}
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            //if (NumberMatch.Regex(textBox7.Text))
            //{
            //    textBox7.Text = null;
            //    //textBox7.Focus();
            //}
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            //if (NumberMatch.Regex(textBox9.Text))
            //{
            //    textBox9.Text = null;
            //    //textBox9.Focus();
            //}
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            //if (NumberMatch.Regex(textBox8.Text))
            //{
            //    textBox8.Text = null;
            //    //textBox8.Focus();
            //}
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            //if (NumberMatch.RegexSW(0, textBox1.Text, textBox2.Text))
            //{
            //    textBox2.Text = null;
            //    //textBox2.Focus();
            //}
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            //if (NumberMatch.RegexSW(0, textBox2.Text, textBox3.Text))
            //{
            //    textBox3.Text = null;
            //    //textBox3.Focus();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 数据合法性验证

            if (NumberMatch.Regex(txtNDVIv.Text))
            {
                label18.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label18.ForeColor = System.Drawing.Color.Black;
            }
            if (NumberMatch.Regex(txtNDVIs.Text))
            {
                label19.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label19.ForeColor = System.Drawing.Color.Black;
            }
            if (NumberMatch.Regex(txtNDVIw.Text))
            {
                label20.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label20.ForeColor = System.Drawing.Color.Black;
            }

            if (NumberMatch.Regex(txtF.Text))
            {
                label21.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label21.ForeColor = System.Drawing.Color.Black;
            }
            if (NumberMatch.Regex(txtEmissVegetation.Text))
            {
                label22.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label22.ForeColor = System.Drawing.Color.Black;
            }
            if (NumberMatch.Regex(txtEmissSoil4.Text))
            {
                label24.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label24.ForeColor = System.Drawing.Color.Black;
            }
            if (NumberMatch.Regex(txtEmissSoil3.Text))
            {
                label23.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label23.ForeColor = System.Drawing.Color.Black;
            }
            if ((NumberMatch.RegexSW(0, txtNDVIs.Text, txtNDVIv.Text)) || (NumberMatch.RegexSW(-1, txtNDVIw.Text, txtNDVIs.Text)))
            {
                MessageBox.Show("请注意，必须满足 NDVIw < NDVIs < NDVIv 条件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (NumberMatch.Regex(txtC1.Text)&&radioC1.Checked==true)
            {
                label25.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label25.ForeColor = System.Drawing.Color.Black;
            }
            #endregion

            //a,b,输出路径判断
            if (txtaVegetation == null || txtaSoil == null || txtbSoil == null || txtbVegetation == null)
            {
                MessageBox.Show("植被或者土壤的 α 或者 β 为空，请输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtOuput.Text == "")
            {
                MessageBox.Show("输出目录为空，请输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //开始温度反演
            try
            {
                COM_IDL_connectLib.COM_IDL_connect oCom = new COM_IDL_connectLib.COM_IDL_connect();
                oCom.CreateObject(0, 0, 0);
                //oCom.ExecuteString(".RESET_SESSION");

                int Cindex = 0;
                if (radioC1.Checked == true && txtC1.Text != "")
                {
                    Cindex = 0;
                }
                else
                {
                    Cindex = 1;
                }
                
                Object[] inputStringArray = allListFiles.ToArray();
                //object[] inputStringArray1 = { @"E:\temp-IRSA\2501\B1.tif", @"E:\temp-IRSA\2501\B2.tif", @"E:\temp-IRSA\2501\B3.tif", @"E:\temp-IRSA\2501\B4.tif", @"E:\temp-IRSA\2501\green.tif", @"E:\temp-IRSA\2501\red.tif", @"E:\temp-IRSA\2501\NIR.tif", @"E:\temp-IRSA\2501\SensorZenith.tif" };
                //string temp = "CAL_TEMPRETURE20140618," + inputStringArray + "," + txtNDVIv.Text + "," + txtNDVIs.Text + "," + txtNDVIw.Text + "," + txtF.Text + "," + txtEmissVegetation.Text + "," + txtEmissWater.Text + "," + txtEmissSoil3.Text + "," + txtEmissSoil4.Text + "," + Cindex + "," + txtC1.Text + "," + txtaVegetation.Text + "," + txtbVegetation.Text + "," + txtaSoil.Text + "," + txtbSoil.Text + ",'" + txtOuput.Text + "\\" + "'";

                #region 文件目录放在桌面上运行成功
                oCom.SetIDLVariable("inputArray", inputStringArray);
                oCom.SetIDLVariable("NDVIv", Convert.ToDouble(txtNDVIv.Text));
                oCom.SetIDLVariable("NDVIs", Convert.ToDouble(txtNDVIs.Text));
                oCom.SetIDLVariable("NDVIw", Convert.ToDouble(txtNDVIw.Text));
                oCom.SetIDLVariable("F", Convert.ToDouble(txtF.Text));
                oCom.SetIDLVariable("Ev", Convert.ToDouble(txtEmissVegetation.Text));
                oCom.SetIDLVariable("Ew", Convert.ToDouble(txtEmissWater.Text));
                oCom.SetIDLVariable("Es3", Convert.ToDouble(txtEmissSoil3.Text));
                oCom.SetIDLVariable("Es4", Convert.ToDouble(txtEmissSoil4.Text));
                oCom.SetIDLVariable("Cindex", Cindex);
                oCom.SetIDLVariable("C", Convert.ToDouble(txtC1.Text));
                oCom.SetIDLVariable("av", Convert.ToDouble(txtaVegetation.Text));
                oCom.SetIDLVariable("bv", Convert.ToDouble(txtbVegetation.Text));
                oCom.SetIDLVariable("as", Convert.ToDouble(txtaSoil.Text));
                oCom.SetIDLVariable("bs", Convert.ToDouble(txtbSoil.Text));
                object output = txtOuput.Text + "\\";
                oCom.SetIDLVariable("outputdirct", output);

                oCom.ExecuteString(".compile '" + Application.StartupPath.ToString() + "\\cal_tempreture20140618.pro'");
                //oCom.ExecuteString(temp);
                oCom.ExecuteString("CAL_TEMPRETURE20140618,inputArray,NDVIv,NDVIs,NDVIw,F,Ev,Ew,Es3,Es4,Cindex,C,av,bv,as,bs,outputdirct");
                MessageBox.Show("运行成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close(); 
                #endregion

                //string[] inputStringArray1 = allListFiles.ToArray();
                //object output = txtOuput.Text + "\\";
                //string temp = "CAL_TEMPRETURE20140618,'" + inputStringArray1 + "'," + txtNDVIv.Text + "," + txtNDVIs.Text + "," + txtNDVIw.Text + "," + txtF.Text + "," + txtEmissVegetation.Text + "," + txtEmissWater.Text + "," + txtEmissSoil3.Text + "," + txtEmissSoil4.Text + "," + Cindex + "," + txtC1.Text + "," + txtaVegetation.Text + "," + txtbVegetation.Text + "," + txtaSoil.Text + "," + txtbSoil.Text + ",'" + txtOuput.Text + "\\" + "'";
                //oCom.ExecuteString(".compile '" + Application.StartupPath.ToString() + "\\cal_tempreture20140618.pro'");
                //oCom.ExecuteString(temp);
                //MessageBox.Show("运行成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //this.Close();
            }
            catch (Exception ex)
            {
                string[] files = Directory.GetFiles(txtOuput.Text);
                if (files.Length != 0)
                {
                    MessageBox.Show("运行成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectOuput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.Description = "选择输出文件的目录";
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                txtOuput.Text = folderDialog.SelectedPath;
            }
        }
       
    }
}
