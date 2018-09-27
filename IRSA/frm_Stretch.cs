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
using System.IO;
using ESRI.ArcGIS.Geodatabase;

namespace IRSA
{
    public partial class frm_Stretch: Form
    {
        COM_IDL_connectLib.COM_IDL_connect oCom = new COM_IDL_connectLib.COM_IDL_connect();
        string filepath = "";
        string fileoutpath = "";
        IRasterLayer raster_layer = null;
        bool flag = false;//判断是否是首次拉伸

        public frm_Stretch(IRasterLayer layer)
        {
            InitializeComponent();
            raster_layer = layer;
        }

        string pos = "1";
        string out_name = "";
        private void button1_Click(object sender, EventArgs e)
        {
            //图像拉伸
            string input = filepath;
            string in_min = txt_in_min.Text;// "12";//输入最小要拉伸的值
            string in_max = txt_in_max.Text;// "109";//输入最大要拉伸的值
            string out_min = txt_out_min.Text;// "0";//输出最小值
            string out_max = txt_out_max.Text;// "255";//输出最大值
            //判断是否输出影像文件
            if (fileoutpath != "")
            {
              out_name = fileoutpath;// "D:\\20090823_4_254_597_linear001.tif";//输出文件名
            }
            else
            {
                //首次运行，删除TempImage文件夹下所有文件
                if (!flag)
                {
                    try
                    {
                        Directory.Delete(Application.StartupPath + "\\TempImage", true);
                        Directory.CreateDirectory(Application.StartupPath + "\\TempImage");
                        flag = true;
                    }
                    catch { }
                }
                out_name = Application.StartupPath + "\\TempImage\\temp_stretch.tif";
                while (File.Exists(out_name))
                {
                    out_name = out_name.Replace(".tif", "_.tif");
                }
            }

            //判断选择波段
            if (cmbLayerBand.SelectedItem != null)
            {
                pos =Convert.ToString(cmbLayerBand.SelectedIndex);
            }
            string method = (cmb_method.SelectedIndex + 1).ToString();// "1";//选择拉伸方法，1 Linear ，2 Equalize，3 Gaussian ，4 Square root
            string ValueOrPercent = "1";//输入值得类型，0为百分比，1为数值
            string tmp3 = "image_stretching20150306," + "\"" + input + "\"," + pos + "," + in_min + "," + in_max + "," + out_min + "," + out_max + ",\"" + out_name + "\"," + method + "," + ValueOrPercent;
            try
            {
                oCom.CreateObject(0, 0, 0);
                oCom.ExecuteString(".compile '" + Application.StartupPath.ToString() + "\\image_stretching20150306.pro'");
                oCom.ExecuteString(tmp3);
                axMapControl1.DeleteLayer(0);
                axMapControl1.Map.AddLayer(createLayer(out_name));
                axMapControl1.Refresh();
                if (fileoutpath != "")
                {
                    MessageBox.Show("拉伸成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btn_output_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "";
            saveFile.Filter = "TIFF|*.tif";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                fileoutpath = saveFile.FileName;
                txtOutput.Text = fileoutpath;
            }
        }

        private void frm_Stretch_Load(object sender, EventArgs e)
        {
            int j = 1;
            IRasterLayer pRasterLayer = raster_layer;
            filepath = pRasterLayer.FilePath;
            if (pRasterLayer.BandCount != 0)
            {
                IRasterBandCollection collection = pRasterLayer.Raster as IRasterBandCollection;
                IEnumRasterBand rasterband = collection.Bands;
                IRasterBand band = rasterband.Next();
                while (band != null)
                {
                    //绑定波段数
                    cmbLayerBand.Items.Add("band " + j);
                    j++;
                    band = rasterband.Next();
                }
                axMapControl1.Map.AddLayer(pRasterLayer);
                axMapControl1.Refresh();
            }
        }

        public IRasterLayer createLayer(string aFileName)
        {
            string fullPath;
            string path;//路径
            string fileName;//文件名

            fullPath = aFileName;
            path = System.IO.Path.GetDirectoryName(fullPath);//路径
            fileName = System.IO.Path.GetFileName(fullPath);//文件名

            IWorkspaceFactory pWorkspaceFactory = new RasterWorkspaceFactoryClass();
            IRasterWorkspace pRasterWorkspace = (IRasterWorkspace)pWorkspaceFactory.OpenFromFile(path, 0);
            IRasterDataset pRasterDataset = (IRasterDataset)pRasterWorkspace.OpenRasterDataset(fileName);
            IRasterLayer pRasterLayer = new RasterLayerClass();
            pRasterLayer.CreateFromDataset(pRasterDataset);
            return pRasterLayer;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

