using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;

namespace IRSA
{
    class BandCombinationShow
    {
        /// <summary>
        /// 拉伸渲染模式（貌似）
        /// </summary>
        /// <param name="rasterDataset"></param>
        /// <returns></returns>
        private static IRasterRenderer StretchRenderer(ESRI.ArcGIS.Geodatabase.IRasterDataset rasterDataset, int graypos, int i)
        {
            try
            {
                //Define the from and to colors for the color ramp.
                IRgbColor fromColor = new RgbColorClass();
                fromColor.Red = 255;
                fromColor.Green = 0;
                fromColor.Blue = 0;
                IColor toColor = new RgbColorClass();
                //此处应该是写错了
                fromColor.Red = 0;
                fromColor.Green = 255;
                fromColor.Blue = 0;
                //Create the color ramp.
                IAlgorithmicColorRamp colorRamp = new AlgorithmicColorRampClass();
                colorRamp.Size = 255;
                colorRamp.FromColor = fromColor;
                colorRamp.ToColor = toColor;
                bool createColorRamp;
                colorRamp.CreateRamp(out createColorRamp);
                //Create a stretch renderer.
                IRasterStretchColorRampRenderer stretchRenderer = new
                    RasterStretchColorRampRendererClass();

                //设置显示对比度和亮度
                //((IRasterDisplayProps)stretchRenderer).BrightnessValue = -90;
                IRasterRenderer rasterRenderer = (IRasterRenderer)stretchRenderer;


                //Set the renderer properties.
                IRaster raster = rasterDataset.CreateDefaultRaster();
                rasterRenderer.Raster = raster;
                rasterRenderer.Update();
                stretchRenderer.BandIndex = graypos;
                //stretchRenderer.ColorRamp = colorRamp;
                //Set the stretch type.
                IRasterStretch stretchType = (IRasterStretch)rasterRenderer;
                stretchType.StretchType = esriRasterStretchTypesEnum.esriRasterStretch_StandardDeviations;
                stretchType.StandardDeviationsParam = 2;
                return rasterRenderer;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据单波段灰度渲染
        /// </summary>
        /// <param name="rasterDataset">栅格数据集</param>
        /// <param name="graypos">第几波段</param>
        /// <returns></returns>
        public static IRasterRenderer StretchRenderer(ESRI.ArcGIS.Geodatabase.IRasterDataset rasterDataset, int graypos)
        {
            try
            {
                //Define the from and to colors for the color ramp.
                IRgbColor fromColor = new RgbColorClass();
                fromColor.Red = 255;
                fromColor.Green = 0;
                fromColor.Blue = 0;
                IColor toColor = new RgbColorClass();
                fromColor.Red = 0;
                fromColor.Green = 255;
                fromColor.Blue = 0;
                //Create the color ramp.
                IAlgorithmicColorRamp colorRamp = new AlgorithmicColorRampClass();
                colorRamp.Size = 255;
                colorRamp.FromColor = fromColor;
                colorRamp.ToColor = toColor;
                bool createColorRamp;
                colorRamp.CreateRamp(out createColorRamp);
                //Create a stretch renderer.
                IRasterStretchColorRampRenderer stretchRenderer = new
                RasterStretchColorRampRendererClass();

                //设置显示对比度和亮度
                //((IRasterDisplayProps)stretchRenderer).BrightnessValue = -90;
                IRasterRenderer rasterRenderer = (IRasterRenderer)stretchRenderer;


                //Set the renderer properties.
                IRaster raster = rasterDataset.CreateDefaultRaster();
                rasterRenderer.Raster = raster;
                rasterRenderer.Update();
                stretchRenderer.BandIndex = graypos;
                //stretchRenderer.ColorRamp = colorRamp;
                //Set the stretch type.
                IRasterStretch stretchType = (IRasterStretch)rasterRenderer;
                stretchType.StretchType = esriRasterStretchTypesEnum.esriRasterStretch_StandardDeviations;
                stretchType.StandardDeviationsParam = 2;
                return rasterRenderer;
            }
            catch
            {
                return null;
            }
        }
    }
}
