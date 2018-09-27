using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;



namespace IRSA
{
    public class FileListOperate
    {
        /// <summary>
        /// 保存路径
        /// </summary>
        private string savePath;
        public string SavePath
        {
            get { return savePath; }
            set { savePath = value; }
        }

        /// <summary>
        /// 保存内容
        /// </summary>
        //private Dictionary<int, List<string>> dicts_content;
        //public Dictionary<int, List<string>> Dicts_Content
        //{
        //    get { return dicts_content; }
        //    set { dicts_content = value; }
        //}
        private List<string> dicts_content;
        public List<string> Dicts_Content
        {
            get { return dicts_content; }
            set { dicts_content = value; }
        }
       
        /// <summary>
        /// 写入配置文件
        /// </summary>

        public void WriteConfigFile()
        {
            StreamWriter sw = new StreamWriter(savePath);
            //foreach (string dic in dicts_content)
            //{
            for (int i = 0; i < dicts_content.Count(); i++)
            {
                sw.WriteLine(i / 8 + "*" + dicts_content[i]);
            }
            //}
            sw.Flush();
            sw.Close();
        }
        //读取配置文件
        public List<string> ReadConfigFile()
        {
            string[] list_item;//一行的记录
            //int key_value = 0;//键
            List<string> list_value = new List<string>();//值
            StreamReader sr = new StreamReader(savePath);
            int i=0;
            while (sr.Peek() >= 0)
            {
                i++;
                string item=sr.ReadLine();
                list_item = item.Split(new char[] { '*' });
                //key_value = Convert.ToInt32(list_item[0]);
                if (File.Exists(list_item[1]))
                {
                    list_value.Add(list_item[1]);
                }
                else
                {
                    list_value.Add("该文件不存在！");
                }
                if (i % 8 == 0)
                {
                    dicts_content.AddRange(list_value);
                    //dicts_content.Add(key_value, list_value);
                    list_value = new List<string>();
                }
            }
            return dicts_content;
        }

        public  bool isFileExists()
        { 
            bool isexist=true;
            foreach (string dic in dicts_content)
            {
                for (int i = 0; i < dic.Count(); i++)
                {
                    if (dic == "该文件不存在！")
                    {
                        isexist = false;
                    }
                    else
                    {
                        isexist = true;
                    }
                }
            }
         return isexist;
        }
    }
}
