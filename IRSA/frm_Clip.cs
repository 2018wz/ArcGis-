using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.SpatialAnalystTools;
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.esriSystem;

namespace IRSA
{
    public partial class frm_Clip : Form
    {
        public frm_Clip()
        {
            InitializeComponent();
        }

        string rasterName;
        string shapefileName;
        string path;
        private void btn_raster_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia_open = new OpenFileDialog();
            dia_open.Title = "选择要裁剪的影像";
            dia_open.Filter = "栅格文件(*.tif,*.img)|*.tif;*.img|所有文件(*.*)|*.*";
            if (dia_open.ShowDialog() == DialogResult.OK)
            {
               rasterName= dia_open.FileName;
               cmbInputRaster.Text = rasterName;
            }

        }

        private void btn_feature_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia_open = new OpenFileDialog();
            dia_open.Title = "选择要裁剪的影像";
            dia_open.Filter = "矢量文件(*.shp)|*.shp|所有文件(*.*)|*.*";
            if (dia_open.ShowDialog() == DialogResult.OK)
            {
                shapefileName = dia_open.FileName;
                cmbInputFeature.Text = shapefileName;
                path = System.IO.Path.GetDirectoryName(shapefileName);
            }

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Geoprocessor gp = new Geoprocessor();
            ExtractByMask mask = new ExtractByMask();
            mask.in_raster = rasterName;
            mask.in_mask_data = shapefileName;
            mask.out_raster =txtOutput.Text;
            try
            {
                gp.Execute(mask, null);
                MessageBox.Show("裁切成功！");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btn_output_Click(object sender, EventArgs e)
        {
            SaveFileDialog dia_save = new SaveFileDialog();
            dia_save.Title = "选择输出影像";
            dia_save.Filter = "栅格文件(*.tif，*.img)|*.tif;*.img|所有文件(*.*)|*.*";
            if (dia_save.ShowDialog() == DialogResult.OK)
            {
                txtOutput.Text = dia_save.FileName;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Clip_Load(object sender, EventArgs e)
        {

        }
    }
}
