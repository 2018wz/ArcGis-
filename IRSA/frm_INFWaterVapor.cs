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
using COM_IDL_connectLib;

namespace IRSA
{
    public partial class frm_INFWaterVapor : Form
    {
        public frm_INFWaterVapor()
        {
            InitializeComponent();
        }

        //List<string> list_B1 = new List<string>();//存放B1文件列表
        //List<string> list_B2 = new List<string>();//存放B2文件列表
        //Dictionary<string, string> dic_BandList = new Dictionary<string, string>();//存放对应关系列表
        //public delegate void BandOperate(TextBox txtBox, List<string> list);
        //
        //热红外劈窗通道图像1:
        //
        private void btnInputB1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择影像";
            openFileDialog.Filter = "(*.tif,*.tiff)|*.tif;*.tiff|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                textBand1.Text = openFileDialog.FileName;
            }
        }

        public void getFileName(TextBox txtBox, List<string> list_Band)
        {
            /*FolderBrowserDialog fbd = new FolderBrowserDialog();
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
            }*/
        }


        /// <summary>
        /// 大气模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbAtmosphere_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        /// 输出路径
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
            if (textBand1.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == ""
                || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" 
                || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" 
                || txtHeight.Text == "" || txtSaveFile.Text == "")
            {
                MessageBox.Show("请检查输入、输出以及参数设置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {

                //开始水汽计算程序
                try
                {
                    COM_IDL_connectLib.COM_IDL_connect oCom = new COM_IDL_connectLib.COM_IDL_connect();
                    oCom.CreateObject(0, 0, 0);

                    //oCom.ExecuteString("window,1,title='C#call IDL'");
                    //oCom.ExecuteString("plot,sin(findgen(200)/20)");
                    //oCom.DestroyObject();

                    oCom.SetIDLVariable("imagePath1", textBand1.Text);//热红外劈窗通道图像1
                    oCom.SetIDLVariable("imagePath2", textBox1.Text);//热红外劈窗通道图像2
                    oCom.SetIDLVariable("imagePath3", textBox2.Text);//红外波段图像
                    oCom.SetIDLVariable("imagePath4", textBox3.Text);//近红外通道图像

                    oCom.SetIDLVariable("band1", Convert.ToDouble(txtHeight.Text));//劈窗通道波长1
                    oCom.SetIDLVariable("band2", Convert.ToDouble(textBox4.Text));//劈窗通道波长2
                    oCom.SetIDLVariable("BareSoilNDVIThresholdValue", Convert.ToDouble(textBox6.Text));//裸土NDVI阈值
                    oCom.SetIDLVariable("vegetationNDVIThresholdValue", Convert.ToDouble(textBox5.Text));//植被NDVI阈值
                    oCom.SetIDLVariable("BareSoilEmissivity1", Convert.ToDouble(textBox8.Text));//裸土发射率1
                    oCom.SetIDLVariable("BareSoilEmissivity2", Convert.ToDouble(textBox7.Text));//裸土发射率2
                    oCom.SetIDLVariable("vegetationEmissivity1", Convert.ToDouble(textBox10.Text));//植被发射率1
                    oCom.SetIDLVariable("vegetationEmissivity2", Convert.ToDouble(textBox9.Text));//植被发射率2
                    oCom.SetIDLVariable("windowSize1", Convert.ToDouble(textBox12.Text));//窗口设置1
                    oCom.SetIDLVariable("windowSize2", Convert.ToDouble(textBox13.Text));//窗口设置2

                    //oCom.SetIDLVariable("outputdir", txtSaveFile.Text);

                    string tmp = "splitpwv_jicheng,'" + textBand1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + txtSaveFile.Text.ToString()
                        + "'," + Convert.ToDouble(txtHeight.Text) + "," + Convert.ToDouble(textBox4.Text) + "," + Convert.ToDouble(textBox12.Text) + "," + Convert.ToDouble(textBox13.Text)
                       + "," + Convert.ToDouble(textBox6.Text) + "," + Convert.ToDouble(textBox5.Text) + "," + Convert.ToDouble(textBox8.Text) + "," + Convert.ToDouble(textBox7.Text)
                       + "," + Convert.ToDouble(textBox10.Text) + "," + Convert.ToDouble(textBox9.Text) + "";
                    Console.WriteLine(tmp);
                    string tmp2 = ".compile '" + Application.StartupPath.ToString() + "\\splitpwv_jicheng.pro'";
                    oCom.ExecuteString(tmp2);
                    oCom.ExecuteString(tmp);
                    //oCom.ExecuteString("splitpwv_jicheng,imagePath1,imagePath2,imagePath3,imagePath4,outputdir,band1,band2,windowSize1,windowSize2,BareSoilNDVIThresholdValue,vegetationNDVIThresholdValue,BareSoilEmissivity1,BareSoilEmissivity2,vegetationEmissivity1,vegetationEmissivity2");
                    oCom.DestroyObject();


                    //oCom.ExecuteString("Restore,'splitpww.sav'");//编译程序 
                    //oCom.ExecuteString("splitpww");
                    //oCom.ExecuteString(tmp);  

                    MessageBox.Show("运行成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void label19_Click(object sender, EventArgs e)
        {

        }
        //
        //热红外劈窗通道图像2:
        //
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择影像";
            openFileDialog.Filter = "(*.tif,*.tiff)|*.tif;*.tiff|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                textBox1.Text = openFileDialog.FileName;
            }
        }
        //
        //红外波段图像:
        //
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择影像";
            openFileDialog.Filter = "(*.tif,*.tiff)|*.tif;*.tiff|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                textBox2.Text = openFileDialog.FileName;
            }
        }
        //
        //近红外通道图像:
        //
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择影像";
            openFileDialog.Filter = "(*.tif,*.tiff)|*.tif;*.tiff|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                textBox3.Text = openFileDialog.FileName;
            }
        }
    }
}
