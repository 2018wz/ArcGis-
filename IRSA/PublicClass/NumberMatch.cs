using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IRSA
{
    public class NumberMatch
    {
        public static bool Regex(string text)
        {
            float value = 0;
            bool flag = true;
            try
            {
                value = Convert.ToSingle(text);
                if (value < 0 || value > 1)
                {
                    //MessageBox.Show("请输入0-1之间的数字");
                    return flag;
                }
                return false;
            }
            catch
            {
                //MessageBox.Show("请输入0-1之间的数字");
                return flag;
            }
        }

        public static bool RegexSW(int fanwei, string bijiao_value, string text2)
        {
            float value = 0;
            float r_value = 0;
            bool flag = true;
            try
            {
                value = Convert.ToSingle(text2);
                r_value = Convert.ToSingle(bijiao_value);
                //if (value < fanwei || value > 1 || value > r_value)
                if (!(value < 1 && value > r_value && r_value > fanwei))
                {
                    //MessageBox.Show("请输入0-1之间且小于NDVIs或NDVIw的数字");
                    return flag;
                }
                return false;
            }
            catch
            {
                //MessageBox.Show("请输入0-1之间的数字");
                return flag;
            }
        }

    }
}
