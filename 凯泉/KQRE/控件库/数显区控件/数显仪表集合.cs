using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 控件库.数字仪表;
using 辅助库;
using 数据存储;
using System.Reflection;
namespace 控件库.数显区控件
{
    public partial class 数显仪表集合 : UserControl
    {
        int 序号 = 100;
        string _配置文件路径;
        List<string> 警告项;
        public 数显仪表集合()
        {
            InitializeComponent();
            警告项 = new List<string>();
        }


        public void f_初始化所有仪表(string Path)
        {
            _配置文件路径 = Path;
            List<数显仪表单体类> list = 辅助库.类XML转化.XML转类(Path, typeof(List<数显仪表单体类>)) as List<数显仪表单体类>;
           foreach(var item in list)
           {
                f_添加仪表(item);
           }
        }

        public void f_注销所有仪表()
        {
            foreach (var item in flowLayoutPanel1.Controls)
            {
                f_注销仪表数据((HarrProgressBar)item);
            }
        }
        private void f_添加仪表(数显仪表单体类 item)
        {
            Size s = new Size(item.长度, item.高度);
            HarrProgressBar 数字仪表;
            数字仪表 = new HarrProgressBar();
            数字仪表.Padding = new Padding(3);
            数字仪表.Margin = new Padding(item.间距,0,0,0);
            数字仪表.MainText = "00.00";
            数字仪表.StatusText = item.标题内容;
            数字仪表.StatusBarSize = item.标题部分高度;
            数字仪表.FillDegree = item.标题部分颜色占比;
            数字仪表.Size = s;
            数字仪表.MainFont = new System.Drawing.Font(item.数字字体, item.数字大小, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            数字仪表.StatusFont = new System.Drawing.Font(item.标题字体, item.标题大小, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            数字仪表.Checked = true;
            数字仪表.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            数字仪表.Paint += new PaintEventHandler(数字仪表_Paint);
            数字仪表.Name = (++序号).ToString();
            数字仪表.绑定参数编码 = item.数据编码;
            //绑定数据显示
            f_绑定仪表数据(数字仪表, item.数据编码,item.计算类型);
            
            this.flowLayoutPanel1.Controls.Add(数字仪表);
        }

        private void f_绑定仪表数据(HarrProgressBar 数字仪表, string 单体类数据编码,int 单体类数据计算类型)
        {
            switch (单体类数据计算类型)
            {
                case 0:
                    数据项 item = 数据存储.数据项哈希存储.GetItem(单体类数据编码);
                    if (item == null) { return; }
                    item.DataShow += 数字仪表.显示仪表数据;
                    break;
                case 1:
                    Computer.IComputerItem ComputerItem = 数据存储.数据项哈希存储.GetComputerItem(单体类数据编码);
                    if (ComputerItem == null) { return; }
                    ComputerItem.DataShow += 数字仪表.显示仪表数据;
                    break;
            }
        }

        private void f_注销仪表数据(HarrProgressBar 数字仪表)
        {
            Computer.IComputerItem item = 数据存储.数据项哈希存储.GetComputerItem(数字仪表.绑定参数编码);
            if (item == null) { return; }
            item.DataShow -= 数字仪表.显示仪表数据;
        }


        /// <summary>
        /// 重绘仪表防止背影
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void 数字仪表_Paint(object sender, PaintEventArgs e)
        {
            ((HarrProgressBar)sender).Checked = true;
        }

        public void 添加警告项(string str警告项)
        {
            foreach (string str in 警告项)
            {
                if (str警告项.Equals(str))
                {
                    return;
                }
            }
            警告项.Add(str警告项);
        }
        public void 删除警告项(string str警告项)
        {
            警告项.Remove(str警告项);
        }
        public void 开始警告()
        {
            foreach (var item in flowLayoutPanel1.Controls)
            {
                 foreach (string str in 警告项)
                 {
                     if (((HarrProgressBar)item).绑定参数编码.Equals(str))
                     {
                         ((HarrProgressBar)item).StartWanning();
                     }
                 }
            }
        }
        public void 开始警告(string str警告项,double n警告上限值,double n警告下限值)
        {
            添加警告项(str警告项);
            foreach (var item in flowLayoutPanel1.Controls)
            {
                  if (((HarrProgressBar)item).绑定参数编码.Equals(str警告项))
                  {
                         ((HarrProgressBar)item).设置警告上下限(n警告上限值, n警告下限值);
                        ((HarrProgressBar)item).StartWanning();

                  }
            }
        }
        public void 结束警告()
        {
            foreach (var item in flowLayoutPanel1.Controls)
            {
                foreach (string str in 警告项)
                {
                    if (((HarrProgressBar)item).绑定参数编码.Equals(str))
                    {
                        ((HarrProgressBar)item).StopWanning();
                    }
                }
            }
        }
        public void 结束警告(string str警告项)
        {
            foreach (var item in flowLayoutPanel1.Controls)
            {
                if (((HarrProgressBar)item).绑定参数编码.Equals(str警告项))
                {
                    ((HarrProgressBar)item).StopWanning();

                }
            }
        }

        public double 返回控件值(string str警告项)
        {
            foreach (var item in flowLayoutPanel1.Controls)
            {
                if (((HarrProgressBar)item).绑定参数编码.Equals(str警告项))
                {
                    return ((HarrProgressBar)item).返回值();

                }
            }

            return 0;
        }
    }
}
