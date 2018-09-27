using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IRSA
{
    public partial class Frm_input : Form
    {
        int lstBxItemCount;//分组数
        List<string> allData = new List<string>();
        //Dictionary<int, List<string>> allDataList = new Dictionary<int, List<string>>();
        //bool saveOrNot = false;

        public Frm_input()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstBxItemCount = 1;
            lstBxGroup.SelectedIndex = 0;
        }

        private void btnGroupAdd_Click(object sender, EventArgs e)
        {
            lstBxGroup.Items.Add("第 " + (lstBxItemCount + 1).ToString() + " 组");

            lstBxItemCount++;
            listBoxGroupReseting();//重置组名为按顺序排列的组

            int i = lstBxGroup.Items.Count - 1;
            lstBxGroup.SelectedItem = lstBxGroup.Items[i];
        }

        private void btnGroupDelete_Click(object sender, EventArgs e)
        {
            if (lstBxGroup.Items.Count == 0)
            {
                return;
            }
            if (lstBxGroup.Items.Count == 1)
            {
                lstBx1.Items.Clear();
                allData.RemoveRange(0, allData.Count);
                return;
            }
            if (lstBxGroup.SelectedItem != null)
            {
                int i = lstBxGroup.SelectedIndex;
                lstBxGroup.Items.Remove(lstBxGroup.SelectedItem);
                try
                {
                    allData.RemoveRange(i*8, 8);
                }
                catch
                { }
                if (i == lstBxGroup.Items.Count)
                    i = lstBxGroup.Items.Count - 1;
                if (i == -1)
                    return;
                lstBxGroup.SelectedItem = lstBxGroup.Items[i];

                listBoxGroupReseting();//重置组名为按顺序排列的组
            }
        }

        /// <summary>
        /// 重置组名
        /// </summary>
        public void listBoxGroupReseting()
        {
            int groupCount = lstBxGroup.Items.Count;
            for (int i = 0; i < groupCount; i++)
            {
                lstBxGroup.Items[i] = "第 " + (i+1).ToString() + " 组";
            }
        }

        private void lstBxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBxGroup.SelectedItem == null)
                return;
            string selectedText = lstBxGroup.SelectedItem.ToString().Trim();
            groupBox2.Text = selectedText;


            lstBx1.Items.Clear();
            try
            {
                lstBx1.Items.AddRange(allData.GetRange(lstBxGroup.SelectedIndex * 8, 8).ToArray());
            }
            catch
            { }
        }

        private void btnSelectData_Click(object sender, EventArgs e)
        {
            //if (lstBx1.Items.Count >= 8)
            //{
            //    MessageBox.Show("已满足组数据个数需求，不能再增加数据个数,请增加组数！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "选择文件";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] fileList = openFileDialog.FileNames;
                fileaddListBox(fileList);
            }
        }
        /// <summary>
        /// 添加文件到ListBox
        /// </summary>
        /// <param name="filelist"></param>
        public void fileaddListBox(string[] filelist)
        {
            int count = 0;
            if (filelist.Count() < 8)
                count = filelist.Count();
            else
                count = 8;
            lstBx1.Items.Clear();
            for (int i = 0; i < count; i++)
            {
                lstBx1.Items.Add(filelist[i]);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstBx1.SelectedIndex == -1)
                return;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择文件";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lstBx1.Items[lstBx1.SelectedIndex] = openFileDialog.FileName;
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            //若不是第一行则上移
            if (lstBx1.SelectedIndex > 0)
            {
                object selstr = lstBx1.Items[lstBx1.SelectedIndex - 1];
                lstBx1.Items[lstBx1.SelectedIndex - 1] = lstBx1.SelectedItem;
                lstBx1.Items[lstBx1.SelectedIndex] = selstr;
                lstBx1.SelectedItem = lstBx1.Items[lstBx1.SelectedIndex - 1];
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            //若不是最后一行则下移
            if (lstBx1.SelectedIndex != lstBx1.Items.Count - 1)
            {
                object selstr = lstBx1.Items[lstBx1.SelectedIndex + 1];
                lstBx1.Items[lstBx1.SelectedIndex + 1] = lstBx1.SelectedItem;
                lstBx1.Items[lstBx1.SelectedIndex] = selstr;
                lstBx1.SelectedItem = lstBx1.Items[lstBx1.SelectedIndex + 1];
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (lstBx1.Items.Count == 0 || lstBx1.Items.Count == 1)
            //    return;
            //if (lstBx1.SelectedItem != null)
            //{
            //    int i = lstBx1.SelectedIndex;
            //lstBx1.Items.Remove(lstBx1.SelectedItem);
            //    if (i == lstBx1.Items.Count)
            //        i = lstBx1.Items.Count - 1;
            //    if (i == -1)
            //        return;
            //    lstBx1.SelectedItem = lstBx1.Items[i];
            //}

            //lstBx1.Items.Add("第 " + (lstBxItemCount + 1).ToString() + " 组");
            //lstBx1.Items.Clear();
            lstBx1.Items[lstBx1.SelectedIndex] = "";
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            FileListOperate fo = new FileListOperate();
            fo.Dicts_Content = allData;
            bool isflag=fo.isFileExists();
            if (isflag == true && allData.Count != 0)
            {
                Frm_Params fmParams = new Frm_Params(allData);
                fmParams.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("部分文件不存在，请重新选择！");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstBx1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            StringFormat strFmt = new System.Drawing.StringFormat();
            strFmt.Alignment = StringAlignment.Near; //文本水平居中
            strFmt.LineAlignment = StringAlignment.Center; //文本垂直居中
            e.Graphics.DrawString(lstBx1.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, strFmt);
        }

        private void lstBxGroup_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            StringFormat strFmt = new System.Drawing.StringFormat();
            strFmt.Alignment = StringAlignment.Center; //文本水平居中
            strFmt.LineAlignment = StringAlignment.Center; //文本垂直居中
            e.Graphics.DrawString(lstBxGroup.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, strFmt);
        }

        private void btnSaveGroupData_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                if (lstBx1.Items.Count < 8 || lstBx1.Items[i].ToString() == "" || lstBx1.Items[i].ToString() == "该文件不存在！")
                {
                    MessageBox.Show("保存失败，请检查数据格式或数据是否为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            int index = lstBxGroup.SelectedIndex;
            //List<string> groupDataList = new List<string>();
            for (int i = 0; i < 8; i++)
            {
                //groupDataList.Add(lstBx1.Items[i].ToString());
                try
                {
                    allData[index * 8 + i] = lstBx1.Items[i].ToString();
                }
                catch
                {
                    allData.Add(lstBx1.Items[i].ToString());
                }
            }
            //try
            //{
            //    allData.Add(index, groupDataList);
            //}
            //catch
            //{
            //    allData.Remove(index);
            //    allData.Add(index, groupDataList);
            //}
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //groupDataList.Clear();//使用该变量前要清空
            //index = 0;
            //saveOrNot = true;
        }
        //保存配置文件
        private void btnSaveGroupSet_Click(object sender, EventArgs e)
        {

            if (allData.Count() == 0)
            {
                MessageBox.Show("没有组配置文件需要保存，请检查组配置文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "保存文件";
            saveFileDialog.Filter = "文本文件(*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileListOperate fo = new FileListOperate();
                fo.SavePath = saveFileDialog.FileName;
                fo.Dicts_Content = allData;
                try
                {
                    fo.WriteConfigFile();
                    MessageBox.Show("保存组配置文件成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //读取配置文件
        private void btnOpenGroupSet_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "打开文件";
            openDialog.Filter = "文本文件(*.txt)|*.txt";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                FileListOperate fo = new FileListOperate();
                fo.SavePath = openDialog.FileName;
                fo.Dicts_Content = new List<string>();
                try
                {   
                    if (allData.Count == 0)
                    {
                        lstBx1.Items.Clear();
                        lstBxGroup.Items.Clear();
                        allData = fo.ReadConfigFile();
                        //foreach (string dic in allData)
                        //{
                        //    lstBxGroup.Items.Add("第 " + (dic.Key) + " 组");
                        //    if (dic.Key == lstBxGroup.SelectedIndex + 1)
                        //    {
                        //        for (int i = 0; i < 8; i++)
                        //        {
                        //            lstBx1.Items.Add(dic.Value[i]);
                        //        }
                        //    }
                        //}
                        for (int i = 0; i < allData.Count; i=i+8)
                        {
                            lstBxGroup.Items.Add("第 " + (i / 8 + 1) + " 组");
                        }
                        lstBxGroup.SelectedIndex = 0;
                    }
                    else
                    {
                        int count=allData.Count;
                        List<string> dicts = fo.ReadConfigFile();
                        //foreach (KeyValuePair<int, List<string>> dic in dicts)
                        //{
                        //    allDataList.Add(dic.Key +count , dic.Value);
                        //}
                        //for (int i = count; i < allDataList.Count; i++)
                        //{
                        //    KeyValuePair<int, List<string>> dic = allDataList.ElementAt(i);
                        //    lstBxGroup.Items.Add("第 " + (dic.Key) + " 组");
                        //    if (dic.Key== lstBxGroup.SelectedIndex + 1)
                        //    {
                        //        for (int j = 0; j < 8; j++)
                        //        {
                        //            lstBx1.Items.Add(dic.Value[j]);
                        //        }
                        //    }
                        //    lstBxGroup.SelectedIndex = 0;
                        //}
                        for (int i = 0; i < dicts.Count; i = i + 8)
                        {
                            lstBxGroup.Items.Add("第 " + ((i + count) / 8 + 1) + " 组");
                        }
                        allData.AddRange(dicts);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
