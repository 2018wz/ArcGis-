using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace IRSA
{
    public abstract class WaterVapor
    {
        public string height;
        public string name;
        public string longitude;
        public List<string> list_value;
        public XmlDocument document;
       
    }
    public class Vegetation : WaterVapor
    {
        public Vegetation(string name) {
            this.name = name;
        }
         
    }

    public class Soil : WaterVapor
    {
        public Soil(string name)
        {
            this.name = name;
        }
    }

    public class XmlOperate
    {
        public static WaterVapor FactoryWV(string name)
        {
            switch (name)
            {
                case "Vegetation":
                    return new Vegetation("Vegetation");

                case "Soil":
                    return new Soil("Soil");
                default:
                    return null;
            }
        }

        public static void setNodeValue(string Sun, string longitude, List<string> list1, List<string> list2)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.StartupPath + "\\WaterVaporContentConfig.xml");
            WaterVapor WV_vegetation = FactoryWV("Vegetation");
            WV_vegetation.height = Sun;
            WV_vegetation.longitude = longitude;
            WV_vegetation.list_value = list1;
            WV_vegetation.document = doc;
            setABValue(WV_vegetation);
            WaterVapor WV_Soil= FactoryWV("Soil");
            WV_Soil.height = Sun;
            WV_Soil.longitude = longitude;
            WV_Soil.list_value = list1;
            WV_Soil.document = doc;
            setABValue(WV_Soil);
        }

        public static void setABValue(WaterVapor wv)  
        {
            XmlNodeList nodelist = wv.document.GetElementsByTagName(wv.name);
            XmlNodeList childlist = nodelist[0].ChildNodes;//高度角
            for (int i = 0; i < childlist.Count; i++)
            {
                XmlNode childnode = childlist[i];//某个高度角
                if (childnode.Name == "Sun" +wv.height)
                {
                    XmlNodeList childchildlist = childnode.ChildNodes;//纬度带
                    for (int j = 0; j < childchildlist.Count; j++)
                    {
                        XmlElement childchildnode = (XmlElement)childchildlist[j];//某个纬度带
                        if (childchildnode.Name == wv.longitude)
                        {
                            childchildnode.SetAttribute("a", wv.list_value[0]);
                            childchildnode.SetAttribute("b", wv.list_value[1]);
                        }
                    }
                }
            }
            wv.document.Save(Application.StartupPath + "\\WaterVaporContentConfig.xml");
        }

        public static List<string> getNodeValue(string Sun, string longitude)
        {
            List<string> list = new List<string>();
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.StartupPath + "\\WaterVaporContentConfig.xml");
            WaterVapor WV_vegetation = FactoryWV("Vegetation");
            WV_vegetation.height = Sun;
            WV_vegetation.longitude = longitude;
            WV_vegetation.document = doc;
            list.AddRange(getABValue(WV_vegetation));
            WaterVapor WV_Soil = FactoryWV("Soil");
            WV_Soil.height = Sun;
            WV_Soil.longitude = longitude;
            WV_Soil.document = doc;
            list.AddRange(getABValue(WV_Soil));
            return list;
        }


        public static List<string> getABValue(WaterVapor wv)
        {
            List<string> list = new List<string>();
            XmlNodeList nodelist = wv.document.GetElementsByTagName(wv.name);
            XmlNodeList childlist = nodelist[0].ChildNodes;//高度角
            for (int i = 0; i < childlist.Count; i++)
            {
                XmlNode childnode = childlist[i];//某个高度角
                if (childnode.Name == "Sun" + wv.height)
                {
                    XmlNodeList childchildlist = childnode.ChildNodes;//纬度带
                    for (int j = 0; j < childchildlist.Count; j++)
                    {
                        XmlElement childchildnode = (XmlElement)childchildlist[j];//某个纬度带
                        if (childchildnode.Name == wv.longitude)
                        {
                            list.Add(childchildnode.GetAttribute("a"));
                            list.Add(childchildnode.GetAttribute("b"));
                        }
                    }

                }
            }
            return list;
        }

       
    }
}
