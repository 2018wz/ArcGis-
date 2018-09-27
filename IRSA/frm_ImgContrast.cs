using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;

namespace IRSA
{
    public partial class frm_ImgContrast : Form
    {
        List<IRasterLayer> list_layers = new List<IRasterLayer>();
        public frm_ImgContrast(List<IRasterLayer> layers)
        {
            InitializeComponent();
            list_layers = layers;
        }

        private void frm_ImgContrast_Load(object sender, EventArgs e)
        {
            List<string> list_name1 = new List<string>();
            List<string> list_name2 = new List<string>();
            for (int i = 0; i < list_layers.Count; i++)
            {
                IRasterLayer layer=list_layers[i];
                list_name1.Add(layer.Name);
                list_name2.Add(layer.Name);
            }
            comboBox1.DataSource = list_name1;
            comboBox2.DataSource = list_name2;

            comboBox1.Text = "";
            comboBox2.Text = "";
            labelGuangpu.Text = "";
            labelPiancha.Text = "";
            labelXiangguan.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string firstiamgepath="";
            string secondiamgepath = "";
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null)
            {
                string firstimage = comboBox1.SelectedValue.ToString();
                string secondimage = comboBox2.SelectedValue.ToString();
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if (comboBox1.SelectedValue.ToString() == list_layers[i].Name)
                    {
                        firstiamgepath = list_layers[i].FilePath;
                    }
                }

                for (int i = 0; i < comboBox2.Items.Count; i++)
                {
                    if (comboBox2.SelectedValue.ToString() == list_layers[i].Name)
                    {
                        secondiamgepath = list_layers[i].FilePath;
                    }
                }
            }

            try
            {
                COM_IDL_connectLib.ICOM_IDL_connect oCom = new COM_IDL_connectLib.COM_IDL_connect();
                oCom.CreateObject(0, 0, 0);
                string temp = "statistic20150306,'" + firstiamgepath + "','" + secondiamgepath + "',xmin=xmin,ymin=ymin,xmax=xmax,ymax=ymax,xmean=xmean,ymean=ymean,s1=s1,s2=s2,deviation=deviation,p1=p1,p2=p2,g1=g1,g2=g2,r=r,DI=DI";
                //oCom.SetIDLVariable("inputfolder", textBox1.Text.ToString().Trim());
                //oCom.SetIDLVariable("method", comboBox1.SelectedIndex);
                //oCom.SetIDLVariable("outputfolder", textBox2.Text.ToString().Trim());

                oCom.ExecuteString(".compile '" + Application.StartupPath.ToString() + "\\statistic20150306.pro'");
                oCom.ExecuteString(temp);
                //oCom.ExecuteString("noisesuppress20141217,inputfolder,method,outputfolder");
                //MessageBox.Show("运行成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //this.Close();
                //comboBox1.Text = "";
                //comboBox2.Text = "";

                object deviation = oCom.GetIDLVariable("deviation");//输出像元方差
                labelPiancha.Text = Math.Round(Convert.ToDecimal(deviation), 6).ToString();

                object r = oCom.GetIDLVariable("r");//输出像元方差
                labelXiangguan.Text = Math.Round(Convert.ToDecimal(r), 6).ToString();

                object DI = oCom.GetIDLVariable("DI");//输出像元方差
                labelGuangpu.Text = Math.Round(Convert.ToDecimal(DI), 6).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
