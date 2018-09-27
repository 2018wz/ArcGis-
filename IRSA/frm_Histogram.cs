using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using COM_IDL_connectLib;
using ZedGraph;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;

namespace IRSA
{
    public partial class frm_Histogram : Form
    {
        COM_IDL_connectLib.COM_IDL_connect oCom = new COM_IDL_connectLib.COM_IDL_connect();
        string filepath = "";
        //string fileoutpath = "";
        Array y_value;
        Array x_value;
        double x_min = 0;
        double x_max = 0;
        IRasterLayer raster_layer = null;

        public frm_Histogram()
        {
            InitializeComponent();
        }

        public frm_Histogram(IRasterLayer layer)
        {
            InitializeComponent();
            raster_layer = layer;

            IRasterBandCollection rasterBandCollection = raster_layer.Raster as IRasterBandCollection;
            comboBoxBand.Items.Clear();
            for (int i = 0; i < rasterBandCollection.Count; i++)
            {
                comboBoxBand.Items.Add(rasterBandCollection.Item(i).Bandname);
            }
            //if (comboBoxBand.Items.Count != 0)
            //{
            //    comboBoxBand.SelectedIndex = 0;
            //}

            //run_histogram(0);
        }


        private void CreateGraph(ZedGraphControl zgc1, Array x_value1, Array y_value1,double x_min1,double x_max1)
        {
            zgc1.GraphPane.CurveList.Clear();
            zgc1.Refresh();
            GraphPane myPane = zgc1.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "图像直方图";
            myPane.XAxis.Title.Text = "像元值";
            myPane.YAxis.Title.Text = "像元个数";

            PointPairList list = new PointPairList();
            for (int i = 0; i < y_value1.Length; i++)    //256改为y_value.Length，纠正错误：有些影像的像元数不到256个，会产生索引溢出，by-zhzhx，
            {
                string a = x_value1.GetValue(i).ToString();
                string b = y_value1.GetValue(i).ToString();
                double x = Convert.ToDouble(a);
                double y = Convert.ToDouble(b);
                list.Add(x, y);
            }

            StickItem myCurve = myPane.AddStick("", list, Color.Blue);
            myCurve.Line.Width = 2.0f;
            //myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.Scale.Max = x_max1;
            myPane.XAxis.Scale.Min = x_min1;
            //myPane.YAxis.Scale.MajorStep = 500;

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0F);
            zgc1.AxisChange();
            zgc1.Refresh();
        }

        private void frm_Histogram_Load(object sender, EventArgs e)
        {

        }

        public void run_histogram(int bandIndex)
        {
            filepath = raster_layer.FilePath;
            oCom.CreateObject(0, 0, 0);
            //oCom.ExecuteString(".RESET_SESSION");
            //图像熵测试
            string input = filepath;//输入影像
            int pos = bandIndex;//波段，0为第一波段，1为第二波段······
            //string tmp1 = "image_entropy20140607,'" + input + "'," + pos + ",imageentropy=imageentropy";
            //oCom.ExecuteString(".compile '" + Application.StartupPath.ToString() + "\\image_entropy20140607.pro'");
            //try
            //{
            //    oCom.ExecuteString(tmp1);
            //    StatusImageShang_Value.Text = oCom.GetIDLVariable("imageentropy").ToString();//输出图像熵
            //}
            //catch
            //{
            //    StatusImageShang_Value.Text = "NaN";
            //}
            //最大，最小，平均值，标准差，直方图（纵坐标和横坐标），信息熵，平均梯度、清晰度
            try
            {
                string tmp2 = "IMAGE_STATISTICS20150306," + "\"" + input + "\"," + pos + "," + "image_dmax=image_dmax,image_dmin=image_dmin,image_dmean=image_dmean,image_stdv=image_stdv,image_hist=image_hist,binb=binb,p1=p1,g1=g1,outdata2=outdata2";
                oCom.ExecuteString(".compile '" + Application.StartupPath.ToString() + "\\IMAGE_STATISTICS20150306.pro'");
                oCom.ExecuteString(tmp2);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Array image_max = (Array)oCom.GetIDLVariable("image_dmax");//输出像元最大值
            labelMax.Text = Math.Round(Convert.ToDecimal(image_max.GetValue(0)), 6).ToString();
            x_max = Convert.ToDouble(image_max.GetValue(0).ToString());

            Array image_min = (Array)oCom.GetIDLVariable("image_dmin");//输出像元最小值
            labelMin.Text = Math.Round(Convert.ToDecimal(image_min.GetValue(0)), 6).ToString();
            x_min = Convert.ToDouble(image_min.GetValue(0).ToString());

            Array image_mean = (Array)oCom.GetIDLVariable("image_dmean");//输出像元均值
            labelMean.Text = Math.Round(Convert.ToDecimal(image_mean.GetValue(0)), 6).ToString();

            Array image_stdv = (Array)oCom.GetIDLVariable("image_stdv");//输出像元方差
            labelStd.Text = Math.Round(Convert.ToDecimal(image_stdv.GetValue(0)), 6).ToString();

            y_value = (Array)oCom.GetIDLVariable("image_hist");//输出直方图值（纵坐标）
            x_value = (Array)oCom.GetIDLVariable("binb");//输出直方图值（橫坐标）

            dataToDatagridview(x_value, y_value);

            object p1 = oCom.GetIDLVariable("p1");//输出信息熵
            labelEntropy.Text = Math.Round(Convert.ToDecimal(p1), 6).ToString();

            object g1 = oCom.GetIDLVariable("g1");//输出平均梯度
            labelMeanTiDu.Text = Math.Round(Convert.ToDecimal(g1), 6).ToString();

            object outdata2 = oCom.GetIDLVariable("outdata2");//输出清晰度
            labelArticulation.Text = Math.Round(Convert.ToDecimal(outdata2), 6).ToString();

            CreateGraph(zg1,x_value,y_value,x_min,x_max);
        }

        /// <summary>
        /// 填充表格
        /// </summary>
        /// <param name="x_value"></param>
        /// <param name="y_value"></param>
        private void dataToDatagridview(Array x_value, Array y_value)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(y_value.Length);
            for (int i = 0; i < y_value.Length; i++)    //256改为y_value.Length，纠正错误：有些影像的像元数不到256个，会产生索引溢出，by-zhzhx，
            {
                dataGridView1.Rows[i].Cells[0].Value = i+1;//填充序号列

                string a = x_value.GetValue(i).ToString();
                double x = Convert.ToDouble(a);
                dataGridView1.Rows[i].Cells[1].Value = x;

                string b = y_value.GetValue(i).ToString();
                //double y_before = y;
                double y = Convert.ToDouble(b);
                dataGridView1.Rows[i].Cells[2].Value = y;

                try
                {
                    dataGridView1.Rows[i].Cells[3].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value) + Convert.ToDouble(dataGridView1.Rows[i - 1].Cells[3].Value);
                }
                catch
                {
                    dataGridView1.Rows[i].Cells[3].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                }
            }
            double sum = Convert.ToDouble(dataGridView1.Rows[y_value.Length-1].Cells[3].Value);
            //填充百分数和百分数小计
            for (int i = 0; i < y_value.Length; i++)
            {
                dataGridView1.Rows[i].Cells[4].Value =(Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value) / sum * 100).ToString("0.0000");

                try
                {
                    dataGridView1.Rows[i].Cells[5].Value = (Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) + Convert.ToDouble(dataGridView1.Rows[i - 1].Cells[5].Value)).ToString("0.0000");
                }
                catch
                {
                    dataGridView1.Rows[i].Cells[5].Value = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value).ToString("0.0000");
                }
            }
        }

        private void comboBoxBand_SelectedIndexChanged(object sender, EventArgs e)
        {
            run_histogram(comboBoxBand.SelectedIndex);
        }
    }

}

