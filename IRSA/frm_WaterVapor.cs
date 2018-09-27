using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace IRSA
{
    public partial class frm_WaterVapor : Form
    {
        public frm_WaterVapor()
        {
            InitializeComponent();
        }

        List<string> list_B1 = new List<string>();//存放B1文件列表
        List<string> list_B2 = new List<string>();//存放B2文件列表
        Dictionary<string, string> dic_BandList = new Dictionary<string, string>();//存放对应关系列表
        List<string> list_Param;//存放参数列表
        public delegate void BandOperate(TextBox txtBox, List<string> list);

        private void btnInputB1_Click(object sender, EventArgs e)
        {
            BandOperate bo = new BandOperate(getFileName);
            bo(textBand1, list_B1);
        }

        private void btnInputB2_Click(object sender, EventArgs e)
        {
            BandOperate bo = new BandOperate(getFileName);
            bo(textBand2, list_B2);
        }

        public void getFileName(TextBox txtBox, List<string> list_Band)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string FolderPath = fbd.SelectedPath;
                txtBox.Text = FolderPath;
                DirectoryInfo dir = new DirectoryInfo(FolderPath);
                FileInfo[] files = dir.GetFiles("*.tiff");
                for (int i = 0; i < files.Length; i++)
                {
                    list_Band.Add(txtBox.Text + "\\" + files[i].Name);
                }
                list_Band.Sort();
            }
        }


        /// <summary>
        /// 大气模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbAtmosphere_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSurface.SelectedItem != null)
            {
                if (cmbAtmosphere.SelectedItem != null)
                {
                    list_Param = getABValue(cmbSurface.SelectedItem.ToString(), cmbAtmosphere.SelectedItem.ToString());
                    labelα.Text = list_Param[0].ToString();
                    labelb0.Text = list_Param[1].ToString();
                    labelb1.Text = list_Param[2].ToString();
                    labelb2.Text = list_Param[3].ToString();
                    labelb3.Text = list_Param[4].ToString();
                    labelb4.Text = list_Param[5].ToString();
                }
            }
        }
        /// <summary>
        /// 地表模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSurface_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtSaveFile.Text = fbd.SelectedPath;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (textBand1.Text == "" || textBand2.Text == "" || txtHeight.Text == "" || txtAngle.Text == "" || txtSaveFile.Text == "")
            {
                MessageBox.Show("请检查输入、输出以及参数设置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (list_B1.Count != 0 && list_B1.Count != 0)
            {
                //for (int i = 0; i < list_B1.Count; i++)
                //{
                //    dic_BandList.Add(list_B1[i], list_B2[i]);
                //}


                //开始水汽计算程序
                try
                {
                    COM_IDL_connectLib.ICOM_IDL_connect oCom = new COM_IDL_connectLib.COM_IDL_connect();
                    oCom.CreateObject(0, 0, 0);

                    Object[] inputArray1 = list_B1.ToArray();
                    Object[] inputArray2 = list_B2.ToArray();

                    oCom.SetIDLVariable("inputarray1", inputArray1);
                    oCom.SetIDLVariable("inputarray2", inputArray2);
                    oCom.SetIDLVariable("height", Convert.ToDouble(txtHeight.Text));
                    oCom.SetIDLVariable("degree", Convert.ToDouble(txtAngle.Text));

                    oCom.SetIDLVariable("a", Convert.ToDouble(labelα.Text));
                    oCom.SetIDLVariable("b0", Convert.ToDouble(labelb0.Text));
                    oCom.SetIDLVariable("b1", Convert.ToDouble(labelb1.Text));
                    oCom.SetIDLVariable("b2", Convert.ToDouble(labelb2.Text));
                    oCom.SetIDLVariable("b3", Convert.ToDouble(labelb3.Text));
                    oCom.SetIDLVariable("b4", Convert.ToDouble(labelb4.Text));

                    oCom.SetIDLVariable("outputdir", txtSaveFile.Text);

                    //string tmp = "WaterVaporContent20141225,'" + inputArray1 + "','" + inputArray2 + "'," + txtHeight.Text + "," + txtAngle.Text + "," + labelα.Text + "," + labelb0.Text + "," + labelb1.Text + "," + labelb2.Text + "," + labelb3.Text + "," + labelb4.Text + ",'" + txtSaveFile.Text.ToString()+"'";

                    oCom.ExecuteString(".compile '" + Application.StartupPath.ToString() + "\\WaterVaporContent20141225.pro'");
                    //oCom.ExecuteString(tmp);
                    oCom.ExecuteString("WaterVaporContent20141225,inputarray1,inputarray2,height,degree,a,b0,b1,b2,b3,b4,outputdir");

                    MessageBox.Show("运行成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("未找到 *.tiff 文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public  List<string> getABValue(string SurferName, string Atmosphere)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.StartupPath + "\\WaterConfig.xml");
            List<string> list = new List<string>();
            XmlNodeList nodelist = doc.GetElementsByTagName(SurferName);//地表模式
            XmlNodeList childlist = nodelist[0].ChildNodes;//大气模式
            for (int i = 0; i < childlist.Count; i++)
            {
                XmlNode childnode = childlist[i];//某个大气模式
                if (childnode.Name == Atmosphere)
                {
                    XmlElement childchildnode = (XmlElement)childnode;//属性
                    list.Add(childchildnode.GetAttribute("α"));
                    list.Add(childchildnode.GetAttribute("b0"));
                    list.Add(childchildnode.GetAttribute("b1"));
                    list.Add(childchildnode.GetAttribute("b2"));
                    list.Add(childchildnode.GetAttribute("b3"));
                    list.Add(childchildnode.GetAttribute("b4"));
                }
            }
            return list;
        }
    }
}
