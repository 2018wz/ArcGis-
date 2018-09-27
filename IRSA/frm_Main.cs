using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.GeoAnalyst;

using RADIOMETRIC_CALIBRATION_INTEGRATION;
using ESRI.ArcGIS.DataSourcesFile;
using System.IO;


namespace IRSA
{
    public partial class frm_Main : Form
    {

        //获取打开的栅格数据列表
        List<IRasterLayer> pRasterLayerList = new List<IRasterLayer>();
        //进行灰度显示的波段索引
        private int grayPos = 0;
        //RGB合成时候选中的波段数POS
        private int[] rgbPos = new int[3] { 0, 1, 2 };


        //图层操作所用到的变量
        private ILayer TOCRightLayer;
        esriTOCControlItem itemType = esriTOCControlItem.esriTOCControlItemNone;
        IBasicMap basicMap = null;
        ILayer layer = null;
        object unk = null;
        object data = null;

        //裁剪
        bool Is_clip = false;

        //直方图
        string curFileName;
        Bitmap curBitmap;

        public frm_Main()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            axTOCControl1.SetBuddyControl(axMapControl1);
            axToolbarControl1.SetBuddyControl(axMapControl1);
            axToolbarControl1.AddItem(new CommandRotate(), -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            //修改TOCControl上图层控制的名称
            this.axMapControl1.Map.Name = "文件列表";
            axTOCControl1.Update();

            //控制波段列表中灰度显示和彩色合成
            radioBtnColor.Checked = true;
            labelRed.Visible = true;
            labelGreen.Visible = true;
            labelBlue.Visible = true;
            combRed.Visible = true;
            combGreen.Visible = true;
            combBlue.Visible = true;
            labelGray.Visible = false;
            combGray.Visible = false;
        }

        private void 土壤温度反演ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //Geoprocessor gp = new Geoprocessor();
            //Rotate ro = new Rotate();
            //ro.in_raster = @"E:\空间数据\test\CHLOROPHYLLRETRIEVAL_All_2011-08-26.tif";
            ////ro.out_raster = @"E:\空间数据\test\new.tif";
            //ro.angle = 30;
            //gp.Execute(ro, null);
            //MessageBox.Show("jdjod");
            ////axMapControl1.AddLayerFromFile(@"E:\空间数据\test\new.tif");
            //

        }

        private void axMapControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            
            //旋转
            if (frm_Rotate.flag == 1)
            {
                IScreenDisplay display = axMapControl1.ActiveView.ScreenDisplay;
                display.TrackRotate();
            }

            //裁剪
            if (Is_clip == true)
            {
                IRgbColor pcolor = new RgbColorClass();
                pcolor.Red = 255;
                pcolor.Blue = 0;
                pcolor.Green = 255;
                ISimpleFillSymbol linesymbol = new SimpleFillSymbolClass();
                linesymbol.Color = pcolor;
                //ISymbol symbol = linesymbol as ISymbol;
                object symbol = linesymbol;
                IGeometry geom = axMapControl1.TrackPolygon();
                //IScreenDisplay display = axMapControl1.ActiveView.ScreenDisplay;
                //display.StartDrawing(display.hDC, (short)esriScreenCache.esriAllScreenCaches);
                //display.SetSymbol(symbol);
                //display.DrawPolygon(geom);
                //display.FinishDrawing();
                axMapControl1.DrawShape(geom, ref symbol);
                //方法一
                IRasterLayer rasterlayer =axMapControl1.get_Layer(0) as IRasterLayer;
                IGeoDataset geodataset = rasterlayer as IGeoDataset;
                geom.SpatialReference = geodataset.SpatialReference;
                RasterClip(rasterlayer, geom as IPolygon);
                Is_clip = false;
                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
            }
        }

        //裁剪
        static int flag = 0;
        public static void RasterClip(IRasterLayer pRasterLayer, IPolygon clipGeo)
        {
            IRaster pRaster = pRasterLayer.Raster;
            IRasterProps pProps = pRaster as IRasterProps;
            object cellSizeProvider = pProps.MeanCellSize().X;
            IGeoDataset pInputDataset = pRaster as IGeoDataset;
            IExtractionOp pExtractionOp = new RasterExtractionOpClass();
            IRasterAnalysisEnvironment pRasterAnaEnvir = pExtractionOp as IRasterAnalysisEnvironment;
            pRasterAnaEnvir.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue, ref cellSizeProvider);
            object extentProvider = clipGeo.Envelope;
            object snapRasterData = Type.Missing;
            pRasterAnaEnvir.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvMinOf, ref extentProvider, ref snapRasterData);
            //IWorkspaceFactory pWrokspaceFactory = new RasterWorkspaceFactoryClass();
            //if (flag == 0)
            //{
            //    flag++;
            //}
            //if (flag == 1)
            //{
            //    pRasterAnaEnvir.OutWorkspace = pWrokspaceFactory.OpenFromFile("D://temp", 0);
            //}
            IGeoDataset pOutputDataset = pExtractionOp.Polygon(pInputDataset, clipGeo, true);//裁切操作
            IRaster clipRaster = pOutputDataset as IRaster; //裁切后得到的IRaster
            
            //保存裁切后得到的clipRaster
            //如果直接保存为img影像文件
            IWorkspaceFactory pWKSF = new RasterWorkspaceFactory();
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Title = "选择输出影像";
            savefile.Filter = "栅格文件(*.tif)|*.tif|栅格文件(*.img)|*.img";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                IWorkspace pWorkspace = pWKSF.OpenFromFile(System.IO.Path.GetDirectoryName(savefile.FileName), 0);
                ISaveAs pSaveAs = clipRaster as ISaveAs;
                pSaveAs.SaveAs(System.IO.Path.GetFileName(savefile.FileName), pWorkspace, "TIFF");//以img格式保存;
                MessageBox.Show("裁切成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }  
        }


        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            this.axTOCControl1.HitTest(e.x, e.y, ref itemType, ref basicMap, ref layer, ref unk, ref data);
            if (e.button == 2)
            {
                switch (itemType)
                {
                    case esriTOCControlItem.esriTOCControlItemLayer:
                        this.TOCRightLayer = layer;
                        this.contextMenuTOCFeatureLyr.Show(this.axTOCControl1, e.x, e.y);
                        break;
                    case esriTOCControlItem.esriTOCControlItemMap:
                        //this.contextMenuTOCMap.Show(this.axTOCControl1, e.x, e.y);
                        break;
                }
            }
        }

        //控制波段列表中灰度显示和彩色合成显示
        private void radioBtnGray_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnGray.Checked == true)
            {
                labelRed.Visible = false;
                labelGreen.Visible = false;
                labelBlue.Visible = false;
                combRed.Visible = false;
                combGreen.Visible = false;
                combBlue.Visible = false;

                labelGray.Visible = true;
                combGray.Visible = true;
            }
        }

        //控制波段列表中灰度显示和彩色合成显示
        private void radioBtnColor_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnColor.Checked == true)
            {
                labelRed.Visible = true;
                labelGreen.Visible = true;
                labelBlue.Visible = true;
                combRed.Visible = true;
                combGreen.Visible = true;
                combBlue.Visible = true;

                labelGray.Visible = false;
                combGray.Visible = false;
            }
        }

        private void axToolbarControl1_OnItemClick(object sender, IToolbarControlEvents_OnItemClickEvent e)
        {
            if (e.index == 2)
            {
                tabControl1.SelectedIndex = 0;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //清空
            pRasterLayerList.Clear();
            combSlectedFile.Items.Clear();
            treeView1.Nodes.Clear();
            combGray.Text = "";
            combRed.Text = "";
            combGreen.Text = "";
            combBlue.Text = "";

            if (axMapControl1.LayerCount == 0)
                return;
            for (int i = 0; i < axMapControl1.LayerCount; i++)
            {
                if (axMapControl1.get_Layer(i) is IFeatureLayer)
                {
                    continue;
                }
                else if (axMapControl1.get_Layer(i) is IRasterLayer)
                {
                    IRasterLayer pRL = new RasterLayerClass();
                    pRL = axMapControl1.get_Layer(i) as IRasterLayer;
                    pRasterLayerList.Add(pRL);
                    combSlectedFile.Items.Add(pRL.Name.ToString());
                }
            }
        }

        private void combSlectedFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < pRasterLayerList.Count; i++)
            {
                if (combSlectedFile.Text.Trim() == pRasterLayerList[i].Name.ToString().Trim())
                {
                    List<string> bandnames = new List<string>();
                    bandnames = getBandName(pRasterLayerList[i]);
                    addBandNameToCombox(combGray, bandnames);
                    addBandNameToCombox(combRed, bandnames);
                    addBandNameToCombox(combGreen, bandnames);
                    addBandNameToCombox(combBlue, bandnames);
                    showBandsInTree(pRasterLayerList[i].Name.ToString().Trim(), bandnames);
                }
            }
        }

        private List<string> getBandName(IRasterLayer pRLayer)
        {
            try
            {
                string fullPath = pRLayer.FilePath;
                IRasterDataset rasterDataset = OpenFileRasterDataset(fullPath);
                IRasterBandCollection pRBCollection = rasterDataset as IRasterBandCollection;
                List<string> lstring = new List<string>();
                for (int i = 0; i < pRLayer.BandCount; i++)
                {
                    IRasterBand pRBand = pRBCollection.Item(i);
                    lstring.Add(pRBand.Bandname);
                }
                return lstring;
            }
            catch
            {
                return null;
            }
        }

        private static IRasterDataset OpenFileRasterDataset(string fullpath)
        {
            try
            {
                IWorkspaceFactory WorkspaceFactory = new RasterWorkspaceFactoryClass();
                string filePath = System.IO.Path.GetDirectoryName(fullpath);
                string fileName = System.IO.Path.GetFileName(fullpath);
                IWorkspace Workspace = WorkspaceFactory.OpenFromFile(filePath, 0);
                IRasterWorkspace rasterWorkspace = (IRasterWorkspace)Workspace;
                IRasterDataset rasterSet = (IRasterDataset)rasterWorkspace.OpenRasterDataset(fileName);
                return rasterSet;
            }
            catch
            {
                return null;
            }
        }

        private void addBandNameToCombox(ComboBox cb, List<string> bandName)
        {
            cb.Text = "";
            cb.Items.Clear();
            foreach (string name in bandName)
            {
                cb.Items.Add(name);
            }
        }

        private void showBandsInTree(string filename, List<string> bandname)
        {
            treeView1.Nodes.Clear();
            TreeNode fileNode = new TreeNode(filename, 0, 0);
            foreach (string band in bandname)
            {
                TreeNode bands = new TreeNode(band, 2, 3);
                fileNode.Nodes.Add(bands);
            }
            this.treeView1.Nodes.Add(fileNode);
            this.treeView1.ExpandAll();
            this.treeView1.ShowPlusMinus = true;
        }

        //单击显示按钮
        private void BtnBandShow_Click(object sender, EventArgs e)
        {
            if (combSlectedFile.Text == "")
            {
                MessageBox.Show("请选择影像", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                //isOpenOrReRenderer = true;
                if (treeView1.Nodes.Count > 0)
                {
                    if (radioBtnGray.Checked == true)
                    {
                        if (combGray.Text == "")
                        {
                            MessageBox.Show("请选择显示波段", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        this.grayPos = combGray.SelectedIndex;
                        drawImage(combSlectedFile.Text.ToString(), axMapControl1.Extent);
                        this.axMapControl1.Refresh();
                        this.axTOCControl1.Refresh();
                    }
                    else
                    {
                        //如果选择的不够三个波段，无法进行彩色合成
                        if (combRed.Text.Length == 0 || combGreen.Text.Length == 0 || combBlue.Text.Length == 0)
                        {
                            MessageBox.Show("请选择进行彩色合成的波段！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        this.rgbPos[0] = combRed.SelectedIndex;
                        this.rgbPos[1] = combGreen.SelectedIndex;
                        this.rgbPos[2] = combBlue.SelectedIndex;

                        drawImage(combSlectedFile.Text.ToString(), axMapControl1.Extent);
                        this.axMapControl1.Refresh();
                        this.axTOCControl1.Refresh();
                    }
                }
            }
        }


        //波段合成影像
        private void drawImage(string file, IEnvelope extent)
        {
            IRasterLayer pSelectedRasterLayer = new RasterLayerClass();
            ILayer pLayer;
            foreach (IRasterLayer pR in pRasterLayerList)
            {
                if (pR.Name.ToString() == file)
                {
                    pSelectedRasterLayer = pR;
                }
            }
            IRasterBandCollection pRBCollection = pSelectedRasterLayer.Raster as IRasterBandCollection;
            //判断所选择是渲染方式是否是彩色通道
            if (radioBtnColor.Checked == true && pSelectedRasterLayer.BandCount >= 2)
            {
                pLayer = RasterRenderedLayer(pSelectedRasterLayer, true, 0, rgbPos);

                if (axMapControl1.LayerCount == 0)
                {
                    this.axMapControl1.AddLayer(pLayer);
                }
                else
                {
                    bool flag = false;
                    for (int i = 0; i < axMapControl1.LayerCount; i++)
                    {
                        if (pLayer.Name.ToString() == axMapControl1.get_Layer(i).Name.ToString())
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        this.axMapControl1.AddLayer(pLayer);
                    }
                    else
                    {
                        for (int i = 0; i < axMapControl1.LayerCount; i++)
                        {
                            if (pLayer.Name == axMapControl1.get_Layer(i).Name)
                            {
                                this.axMapControl1.DeleteLayer(i);
                                this.axMapControl1.AddLayer(pLayer);
                            }
                        }
                    }
                }
                //if (extent == null)
                //{
                this.axMapControl1.Extent = ((pLayer as IRasterLayer).Raster as IGeoDataset).Extent;
                //}
                //else
                //{
                //    this.axMapControl1.Extent = extent;
                //}
            }
            else
            {
                pLayer = RasterRenderedLayer(pSelectedRasterLayer, false, grayPos, null);

                if (axMapControl1.LayerCount == 0)
                {
                    this.axMapControl1.AddLayer(pLayer);
                }
                else
                {
                    bool flag = false;
                    for (int i = 0; i < axMapControl1.LayerCount; i++)
                    {
                        if (pLayer.Name.ToString() == axMapControl1.get_Layer(i).Name.ToString())
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        this.axMapControl1.AddLayer(pLayer);
                    }
                    else
                    {
                        for (int i = 0; i < axMapControl1.LayerCount; i++)
                        {
                            if (pLayer.Name == axMapControl1.get_Layer(i).Name)
                            {
                                this.axMapControl1.DeleteLayer(i);
                                this.axMapControl1.AddLayer(pLayer);
                            }
                        }
                    }
                }

                //this.mainMap.AddLayer(layer);
                //if (extent == null)
                //{
                this.axMapControl1.Extent = ((pLayer as IRasterLayer).Raster as IGeoDataset).Extent;
                //}
                //else
                //{
                //    this.axMapControl1.Extent = extent;
                //}
            }
        }


        /// <summary>
        ///对Raster根据数据行进行渲染，可以渲染成单通道灰度显示和RGB合成显示
        /// </summary>
        /// <param name="renderType">渲染方式调节</param>
        /// <returns></returns>
        public IRasterLayer RasterRenderedLayer(IRasterLayer pRL, bool renderType, int grayBandIndex, int[] rgbBandIndex)
        {
            //实例新的栅格图层
            IRasterLayer rlayer = new RasterLayerClass();

            string fullPath = pRL.FilePath;
            IRasterDataset rasterDataset = OpenFileRasterDataset(fullPath);


            //单波段
            if (rgbBandIndex == null)
            {
                //如果grayBandIndex=-1
                try
                {
                    IRasterRenderer render = null;
                    render = BandCombinationShow.StretchRenderer(rasterDataset, grayBandIndex);
                    rlayer.CreateFromDataset(rasterDataset);
                    rlayer.Renderer = render as IRasterRenderer;
                    return rlayer;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return null;
                }
            }
            else//多波段显示
            {

                try
                {
                    if (!renderType)
                    {
                        IRasterRenderer render = BandCombinationShow.StretchRenderer(rasterDataset, grayPos);
                        rlayer.CreateFromDataset(rasterDataset);
                        rlayer.Renderer = render as IRasterRenderer;
                    }
                    else
                    {
                        //设置彩色合成顺序 生成新的渲染模式
                        IRasterRGBRenderer render = new RasterRGBRendererClass();
                        render.RedBandIndex = rgbBandIndex[0];
                        render.GreenBandIndex = rgbBandIndex[1];
                        render.BlueBandIndex = rgbBandIndex[2];

                        IRasterStretch stretchType = (IRasterStretch)render;
                        stretchType.StretchType = esriRasterStretchTypesEnum.esriRasterStretch_StandardDeviations;
                        stretchType.StandardDeviationsParam = 2;


                        rlayer.CreateFromDataset(rasterDataset);
                        rlayer.Renderer = render as IRasterRenderer;

                    }

                    return rlayer;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return null;
                }
            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "tif/tiff File(*.tif;*.tiff)|*.tif;*.tiff|Shape File(*.shp)|*.shp|All Files (*.*)|*.*";
            //openFileDialog1.Filter = "(*.tif)|*.tif|(*raw)|*raw";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string extendName = System.IO.Path.GetExtension(openFileDialog.FileName);
                if (extendName == ".shp")
                {
                    try
                    {
                        OpenVectorFile(openFileDialog.FileName);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("文件格式不支持！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    IRasterLayer rasterLayer = new RasterLayerClass();
                    try
                    {
                        rasterLayer.CreateFromFilePath(openFileDialog.FileName); // fileName指存本地的栅格文件路径
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("文件格式不支持！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //设置空间坐标系统
                    try
                    {
                        IWorkspaceFactory pRSTWorkspaceFactory = new RasterWorkspaceFactoryClass();
                        IRasterWorkspace pRSTWorkspace = (IRasterWorkspace)pRSTWorkspaceFactory.OpenFromFile(System.IO.Path.GetDirectoryName(openFileDialog.FileName), 0);
                        IGeoDataset pGeoDataset = pRSTWorkspace.OpenRasterDataset(System.IO.Path.GetFileName(openFileDialog.FileName)) as IGeoDataset;

                        //设置空间坐标系统
                        ISpatialReference pTifSpatialReference = pGeoDataset.SpatialReference;
                        axMapControl1.SpatialReference = pTifSpatialReference;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    axMapControl1.AddLayer(rasterLayer, 0);
                    axMapControl1.Refresh();
                    axTOCControl1.Update();
                }
            }
            tabControl1.SelectedIndex = 0;
        }

        public void OpenVectorFile(string Path)
        {
            IWorkspaceFactory pWsFactory = new ShapefileWorkspaceFactoryClass();
            string filepath = System.IO.Path.GetDirectoryName(Path);
            string filename = System.IO.Path.GetFileName(Path);
            IFeatureWorkspace pWorkSpace = pWsFactory.OpenFromFile(filepath, 0) as IFeatureWorkspace;
            IFeatureClass pFeatureClass = pWorkSpace.OpenFeatureClass(filename);
            IFeatureLayer pFeatureLayer = new FeatureLayerClass();
            pFeatureLayer.Name = pFeatureClass.AliasName;
            pFeatureLayer.FeatureClass = pFeatureClass;

            axMapControl1.AddLayer(pFeatureLayer, 0);
            axMapControl1.Refresh();
            axTOCControl1.Update();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ctMenuTFRemove_Click(object sender, EventArgs e)
        {
            this.axMapControl1.Map.DeleteLayer(this.TOCRightLayer);
            this.axTOCControl1.Update();

            //清空combSelectedFile、treeList1和combRed、combGreen、combBlue、combGray控件。
            this.combSlectedFile.Text = "";
            treeView1.Nodes.Clear();
            this.combRed.Items.Clear();
            this.combGreen.Items.Clear();
            this.combBlue.Items.Clear();
            this.combGray.Items.Clear();
        }

        private void ctMenuTFZoomToLayer_Click(object sender, EventArgs e)
        {
            axMapControl1.Extent = this.TOCRightLayer.AreaOfInterest;
            axMapControl1.Refresh();
        }

        private void 几何校正ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frm_GeoCorrection fgc = new frm_GeoCorrection();
            //fgc.ShowDialog();
            string path = Application.StartupPath + @"\dll_GeoRectify\Debug\test.exe";
            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            ScaleLabel.Text = "比例尺 1：" + ((long)this.axMapControl1.MapScale).ToString();
            CoordinateLabel.Text = "  当前坐标 X=" + e.mapX.ToString() + "  Y=" + e.mapY.ToString() + "  " + this.axMapControl1.MapUnits.ToString().Substring(4);
        }


        private void 像元平均温度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_input fmTemperat = new Frm_input();
            fmTemperat.ShowDialog();
        }

        private void 一体化辐射校正ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //RADIOMETRIC_CALIBRATION_INTEGRATION.Form1 fm1 = new Form1();
            //fm1.ShowDialog();
            frm_RadiometricCalibrationIntegration frmRCI = new frm_RadiometricCalibrationIntegration();
            frmRCI.ShowDialog();
        }

        private void 相对辐射校正ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //radiometric_correction_ralative.Form1 fm1 = new radiometric_correction_ralative.Form1();
            //fm1.ShowDialog();
            indoor frm_RCR = new indoor();
            frm_RCR.ShowDialog();
        }

        private void 图像边缘增强ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //EdgeEnhance.Form1 fm1 = new EdgeEnhance.Form1();
            //fm1.ShowDialog();
            frm_EdgeEnhance frm_EE = new frm_EdgeEnhance();
            frm_EE.ShowDialog();
        }

        private void 噪声抑制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //NoiseSuppress.Form1 fm1 = new NoiseSuppress.Form1();
            //fm1.ShowDialog();
            frm_NoiseSuppress frm_NS = new frm_NoiseSuppress();
            frm_NS.ShowDialog();
        }


        private void 增强ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<IRasterLayer> list_layers = new List<IRasterLayer>();
            for (int i = 0; i < axMapControl1.LayerCount; i++)
            {
                if (axMapControl1.get_Layer(i) is IRasterLayer)
                {
                    IRasterLayer rasterlayer = (IRasterLayer)axMapControl1.get_Layer(i);
                    list_layers.Add(rasterlayer);
                }
            }
            
        }

        //卷帘
        int isJuanlianOrNot = 0;
        ILayerEffectProperties pEffectLayer = new CommandsEnvironmentClass();//注意需要将此代码定义为全局变量。
        private void 卷帘ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (isJuanlianOrNot == 0)
            {
                卷帘ToolStripMenuItem.Checked = true;
                //barButtonItem1.Hint = "卷帘工具";
                ILayer pSwipeLayer = axMapControl1.get_Layer(0);//获得卷帘图层
                pEffectLayer.SwipeLayer = pSwipeLayer;//设置卷帘图层
                ICommand pCommand = new ControlsMapSwipeToolClass();//调用卷帘工具
                pCommand.OnCreate(this.axMapControl1.Object);//绑定工具
                this.axMapControl1.CurrentTool = pCommand as ITool;

                isJuanlianOrNot = 1;
            }
            else
            {
                卷帘ToolStripMenuItem.Checked = false;
                isJuanlianOrNot = 0;
                ICommand pCommand = new ControlsMapFullExtentCommandClass();
                pCommand.OnCreate(this.axMapControl1.Object);
                this.axMapControl1.CurrentTool = pCommand as ITool;
            }
        }

        private void 直方图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TOCRightLayer is IRasterLayer)
            {
                直方图ToolStripMenuItem.Visible = true;
                IRasterLayer rasterlayer = TOCRightLayer as IRasterLayer;
                frm_Histogram histogram = new frm_Histogram(rasterlayer);
                histogram.ShowDialog();
            }
            else
            {
                直方图ToolStripMenuItem.Visible = false;
            }
        }

        private void 拉伸增强ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TOCRightLayer is IRasterLayer)
            {
                拉伸增强ToolStripMenuItem.Visible = true;
                IRasterLayer rasterlayer = TOCRightLayer as IRasterLayer;
                frm_Stretch stretch = new frm_Stretch(rasterlayer);
                stretch.Show();
            }
            else
            {
                拉伸增强ToolStripMenuItem.Visible = false;
            }
        }

        private void 矢量文件裁切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Clip clip = new frm_Clip();
            clip.Show();
        }

        private void 自定义范围裁切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Is_clip = true;
        }

        private void 绝对辐射校正ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_RadiometricCorrectionAbsolute frmRadioCorrAbso = new frm_RadiometricCorrectionAbsolute();
            frmRadioCorrAbso.ShowDialog();
        }

        private void 单窗地表温度反演ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\单窗温度反演\envi_batch_Atmcorr.sav";
            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 图像拼接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\纹理拼接\Mosaic.exe";
            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 图像对比统计ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<IRasterLayer> layers = new List<IRasterLayer>();
            for (int i = 0; i < axMapControl1.LayerCount;i++ )
            {
                layers.Add(axMapControl1.get_Layer(i) as IRasterLayer);
            }
            frm_ImgContrast frm_IC = new frm_ImgContrast(layers);
            frm_IC.ShowDialog();
        }

        private void 清除所有文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要删除所有的图层吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                for (int i = axMapControl1.LayerCount - 1; i >= 0; i--)
                {
                    axMapControl1.DeleteLayer(i);
                }
            }
        }

        private void axTOCControl1_OnDoubleClick(object sender, ITOCControlEvents_OnDoubleClickEvent e)
        {
            esriTOCControlItem toccItem = esriTOCControlItem.esriTOCControlItemNone;
            ILayer iLayer = null;
            IBasicMap iBasicMap = null;
            object unk = null;
            object data = null;
            if (e.button == 1)
            {
                axTOCControl1.HitTest(e.x, e.y, ref toccItem, ref iBasicMap, ref iLayer, ref unk,
                    ref data);
                System.Drawing.Point pos = new System.Drawing.Point(e.x, e.y);
                if (toccItem == esriTOCControlItem.esriTOCControlItemLegendClass)
                {
                    ESRI.ArcGIS.Carto.ILegendClass pLC = new LegendClassClass();
                    ESRI.ArcGIS.Carto.ILegendGroup pLG = new LegendGroupClass();
                    if (unk is ILegendGroup)
                    {
                        pLG = (ILegendGroup)unk;
                    }
                    pLC = pLG.get_Class((int)data);
                    ISymbol pSym;
                    pSym = pLC.Symbol;
                    ESRI.ArcGIS.DisplayUI.ISymbolSelector pSS = new
                        ESRI.ArcGIS.DisplayUI.SymbolSelectorClass();
                    bool bOK = false;
                    pSS.AddSymbol(pSym);
                    bOK = pSS.SelectSymbol(0);
                    if (bOK)
                    {
                        pLC.Symbol = pSS.GetSymbolAt(0);
                    }
                    this.axMapControl1.ActiveView.Refresh();
                    this.axTOCControl1.Refresh();
                }
            }
        }

        private void 海表温度反演ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 关于系统AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("红外多角度遥感图像处理系统", "关于系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 地震信息提取ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string path = @"C:\Program Files (x86)\EQdetctor-1.0\bin\visat.exe";
            string path1 = @"C:\Program Files\EQdetctor-1.0\bin\visat.exe";
            string path2 = @"D:\Program Files\EQdetctor-1.0\bin\visat.exe";
            if (File.Exists(path))
            {
                System.Diagnostics.Process.Start(path);
                return;
            }
            else if (File.Exists(path1))
            {
                System.Diagnostics.Process.Start(path1);
                return;
            }
            else if (File.Exists(path2))
            {
                System.Diagnostics.Process.Start(path2);
                return;
            }
            else
            {
                MessageBox.Show("找不到可执行文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 劈窗地表温度反演ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_input fmTemperat = new Frm_input();
            fmTemperat.ShowDialog();
        }

        //
        //近红外大气水汽估算
        //
        private void 水汽估算WToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_WaterVapor frmWaterVapor = new frm_WaterVapor();
            frmWaterVapor.ShowDialog();
        }

        private void 测试程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void 图像室内测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            indoor s = new indoor();
            s.ShowDialog();
        }

        private void 影像融合ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_shape p = new frm_shape();
            p.ShowDialog();
        }
        //
        //热红外大气水汽估算
        //
        private void 热红外大气水汽估算PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_INFWaterVapor frmWaterVapor = new frm_INFWaterVapor();
            frmWaterVapor.ShowDialog();
        }
        //
        //大气校正
        //
        private void 大气校正ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_AtmosphericCorrection frmWaterVapor = new frm_AtmosphericCorrection();
            frmWaterVapor.ShowDialog();
        }
    }
}

