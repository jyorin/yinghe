using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AutoControl;
using 数据库操作库;

namespace Main.管理界面
{
    public partial class 当前试验组 : DevExpress.XtraEditors.XtraForm
    {
        public struct 数据控件组
        {
            public string filedname
            {
                get;
                set;
            }
            public DevExpress.XtraLayout.LayoutControlItem LayoutControlItem;
            public System.Windows.Forms.Panel panelctrl;
            public System.Windows.Forms.Label labelctrl;
        }

        private List<数据控件组> 控件组;
        public 当前试验组()
        {
            InitializeComponent();
            if (控件组==null)
            控件组 = new List<数据控件组>();
        }
        private void 初始化控件组()
        {
            控件组.Clear();
            if (控件组 == null)
            {
                控件组 = new List<数据控件组>();
            }
            layoutControlItem_1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem_2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;;
            layoutControlItem_3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem_4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem_5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem_6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem_7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem_8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem_9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem_10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem_11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem_12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem_13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem_14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutControlItem_15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
        }
        private void 删除字段(string filedname)
        {
             foreach (数据控件组 item in 控件组)
            {
                if (item.filedname.Equals(filedname))
                {
                    控件组.Remove(item);
                    return;
                }
            }
        }
        private void 添加字段(string filedname, 
            DevExpress.XtraLayout.LayoutControlItem ControlItem,
            System.Windows.Forms.Panel panelcrl,
            System.Windows.Forms.Label labelcrl)
        {
            foreach (数据控件组 item in 控件组)
            {
                if (item.filedname.Equals(filedname))
                {
                    return;
                }
            }

            数据控件组 数据控件 = new 数据控件组();
            ControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            ControlItem.Text = filedname;
            数据控件.LayoutControlItem = ControlItem;
            数据控件.panelctrl = panelcrl;
            数据控件.labelctrl = labelcrl;
            数据控件.filedname = filedname;
            控件组.Add(数据控件);
        }
        private void listBox_试验项_SelectedIndexChanged(object sender, EventArgs e)
        {
            选择试验组项();
        }
        private void 选择试验组项()
        {
            初始化控件组();
            string str试验项=listBox_试验项.Text;
            if (str试验项.Equals("试验组基本信息"))
            {
                添加字段("试验组名", layoutControlItem_1, panel1, label1);
                添加字段("试验日期", layoutControlItem_2, panel2, label2);
                添加字段("试验编号", layoutControlItem_3, panel3, label3);
                添加字段("室温", layoutControlItem_4, panel4, label4);
                添加字段("水温", layoutControlItem_5, panel5, label5);
                添加字段("气压", layoutControlItem_6, panel6, label6);
                设定试验组基本信息值();
                return;
            }

             if (str试验项.Equals("被试水泵"))
            {
                添加字段("用户名称", layoutControlItem_1, panel1, label1);
                添加字段("出厂编号", layoutControlItem_2, panel2, label2);
                添加字段("水泵型号", layoutControlItem_3, panel3, label3);
                添加字段("水泵类型", layoutControlItem_4, panel4, label4);
                添加字段("额定流量", layoutControlItem_5, panel5, label5);
                添加字段("额定扬程", layoutControlItem_6, panel6, label6);
                添加字段("额定轴功率", layoutControlItem_7, panel7, label7);
                添加字段("汽蚀余量", layoutControlItem_8, panel8, label8);
                添加字段("进口直径", layoutControlItem_9, panel9, label9);
                添加字段("出口直径", layoutControlItem_10, panel10, label10);
                添加字段("额定转速", layoutControlItem_11, panel11, label11);

                设定被试水泵值();
                return;
            }
                
             if (str试验项.Equals("拖动电机"))
            {
                添加字段("电机制造商", layoutControlItem_1, panel1, label1);
                添加字段("出厂编号", layoutControlItem_2, panel2, label2);
                添加字段("电机型号", layoutControlItem_3, panel3, label3);
                添加字段("额定功率", layoutControlItem_4, panel4, label4);
                添加字段("额定电压", layoutControlItem_5, panel5, label5);
                添加字段("额定效率", layoutControlItem_6, panel6, label6);
                添加字段("额定电流", layoutControlItem_7, panel7, label7);
                设定拖动电机值();
                return;
            }

             if (str试验项.Equals("流量仪表"))
            {
                添加字段("流量计类型", layoutControlItem_1, panel1, label1);
                添加字段("传出转速上限", layoutControlItem_2, panel2, label2);
                添加字段("流量计编号", layoutControlItem_3, panel3, label3);
                添加字段("传出转速下限", layoutControlItem_4, panel4, label4);
                添加字段("传递功率", layoutControlItem_5, panel5, label5);
                添加字段("流量计规格", layoutControlItem_6, panel6, label6);
                添加字段("传入转速", layoutControlItem_7, panel7, label7);
                添加字段("传递效率", layoutControlItem_8, panel8, label8);
                设定流量仪表值();
                return;
            }

             if (str试验项.Equals("转速仪表"))
            {
                添加字段("传感器类型", layoutControlItem_1, panel1, label1);
                添加字段("传感器编号", layoutControlItem_2, panel2, label2);
                添加字段("测量方式", layoutControlItem_3, panel3, label3);
                设定转速仪表值();
                return;
            }

             if (str试验项.Equals("进口压力仪表"))
            {
                添加字段("变送器型号", layoutControlItem_1, panel1, label1);
                添加字段("变送器编号", layoutControlItem_2, panel2, label2);
                添加字段("进口表距", layoutControlItem_3, panel3, label3);
                添加字段("量程上限", layoutControlItem_4, panel4, label4);
                添加字段("量程下限", layoutControlItem_5, panel5, label5);
                添加字段("有效期", layoutControlItem_6, panel6, label6);

                设定进口压力仪表值();
                return;
            }

             if (str试验项.Equals("出口压力仪表"))
            {
                添加字段("变送器型号", layoutControlItem_1, panel1, label1);
                添加字段("变送器编号", layoutControlItem_2, panel2, label2);
                添加字段("出口表距", layoutControlItem_3, panel3, label3);
                添加字段("量程上限", layoutControlItem_4, panel4, label4);
                添加字段("量程下限", layoutControlItem_5, panel5, label5);
                添加字段("有效期", layoutControlItem_6, panel6, label6);

                设定出口压力仪表值();
                return;
            }

             if (str试验项.Equals("功率测量仪表"))
            {
                添加字段("测功方式", layoutControlItem_1, panel1, label1);
                添加字段("扭矩传感器规格", layoutControlItem_2, panel2, label2);
                添加字段("扭矩传感器编号", layoutControlItem_3, panel3, label3);
                添加字段("二次仪表编号", layoutControlItem_4, panel4, label4);
                添加字段("检定有效日期", layoutControlItem_5, panel5, label5);
                添加字段("电测功电压选择", layoutControlItem_6, panel6, label6);
                添加字段("变送器编号", layoutControlItem_7, panel7, label7);

                设定功率测量仪表值();
                return;
            }

             if (str试验项.Equals("温度测量仪表"))
            {
                添加字段("传感器类型", layoutControlItem_1, panel1, label1);
                添加字段("传感器编号", layoutControlItem_2, panel2, label2);

                设定温度测量仪表值();
                return;
            }


             if (str试验项.Equals("液力耦合器"))
            {
                添加字段("耦合器型号", layoutControlItem_1, panel1, label1);
                添加字段("传出转速上限", layoutControlItem_2, panel2, label2);
                添加字段("出厂编号", layoutControlItem_3, panel3, label3);
                添加字段("传出转速下限", layoutControlItem_4, panel4, label4);
                添加字段("传递功率", layoutControlItem_5, panel5, label5);
                添加字段("耦合器制造商", layoutControlItem_6, panel6, label6);
                添加字段("传入转速", layoutControlItem_7, panel7, label7);
                添加字段("传递效率", layoutControlItem_8, panel8, label8);

                设定液力耦合器值();
                return;
            }
        }
        private void 设定试验组基本信息值()
        {
            string strSql = "Select * from 生成试验组 where ID = " + 全局缓存.当前试验组信息.试验ID;
            DataTable tb = 数据库操作类.GetTableBySql(strSql);

            if (tb.Rows.Count == 0)
            {
                return;
            }

            foreach (DataRow dr in tb.Rows)
            {
                label1.Text = Convert.ToString(dr["试验组名"]);
                label2.Text = Convert.ToString(dr["试验日期"]);
                label3.Text = Convert.ToString(dr["试验编号"]);
                label4.Text = Convert.ToString(dr["室温"]);
                label5.Text = Convert.ToString(dr["水温"]);
                label6.Text = Convert.ToString(dr["气压"]);
                return;
            }
        }
        private void 设定被试水泵值()
        {
            string strSql = "Select * from 水泵型号管理 where ID = " + 全局缓存.当前试验组信息.被试水泵ID;
            DataTable tb = 数据库操作类.GetTableBySql(strSql);

            if (tb.Rows.Count == 0)
            {
                return;
            }

            foreach (DataRow dr in tb.Rows)
            {
                label1.Text = Convert.ToString(dr["用户名称"]);
                label2.Text = Convert.ToString(dr["出厂编号"]);
                label3.Text = Convert.ToString(dr["水泵型号"]);
                label4.Text = Convert.ToString(dr["水泵类型"]);
                label5.Text = Convert.ToString(dr["额定流量"]);
                label6.Text = Convert.ToString(dr["额定扬程"]);
                label7.Text = Convert.ToString(dr["额定轴功率"]);
                label8.Text = Convert.ToString(dr["汽蚀余量"]);
                label9.Text = Convert.ToString(dr["进口直径"]);
                label10.Text = Convert.ToString(dr["出口直径"]);
                label11.Text = Convert.ToString(dr["额定转速"]);
                return;
            }
        }
        private void 设定拖动电机值()
        {
            string strSql = "Select * from 电机型号管理 where ID = " + 全局缓存.当前试验组信息.拖动电机ID;
            DataTable tb = 数据库操作类.GetTableBySql(strSql);

            if (tb.Rows.Count == 0)
            {
                return;
            }

            foreach (DataRow dr in tb.Rows)
            {
                label1.Text = Convert.ToString(dr["电机制造商"]);
                label2.Text = Convert.ToString(dr["出厂编号"]);
                label3.Text = Convert.ToString(dr["电机型号"]);
                label4.Text = Convert.ToString(dr["额定功率"]);
                label5.Text = Convert.ToString(dr["额定电压"]);
                label6.Text = Convert.ToString(dr["额定效率"]);
                label7.Text = Convert.ToString(dr["额定电流"]);
                return;
            }
        }
        private void 设定流量仪表值()
        {
            string strSql = "Select * from 流量仪表 where ID = " + 全局缓存.当前试验组信息.流量仪表ID;
            DataTable tb = 数据库操作类.GetTableBySql(strSql);

            if (tb.Rows.Count == 0)
            {
                return;
            }

            foreach (DataRow dr in tb.Rows)
            {
                label1.Text = Convert.ToString(dr["流量计类型"]);
                label2.Text = Convert.ToString(dr["传出转速上限"]);
                label3.Text = Convert.ToString(dr["流量计编号"]);
                label4.Text = Convert.ToString(dr["传出转速下限"]);
                label5.Text = Convert.ToString(dr["传递功率"]);
                label6.Text = Convert.ToString(dr["流量计规格"]);
                label7.Text = Convert.ToString(dr["传入转速"]);
                label8.Text = Convert.ToString(dr["传递效率"]);
                return;
            }
        }
        private void 设定转速仪表值()
        {
            string strSql = "Select * from 转速测量 where ID = " + 全局缓存.当前试验组信息.转速测量仪表ID;
            DataTable tb = 数据库操作类.GetTableBySql(strSql);

            if (tb.Rows.Count == 0)
            {
                return;
            }

            foreach (DataRow dr in tb.Rows)
            {
                label1.Text = Convert.ToString(dr["传感器类型"]);
                label2.Text = Convert.ToString(dr["传感器编号"]);
                label3.Text = Convert.ToString(dr["测量方式"]);
                return;
            }
        }
        private void 设定进口压力仪表值()
        {
            string strSql = "Select * from 进口压力仪表 where ID = " + 全局缓存.当前试验组信息.进口压力仪表ID;
            DataTable tb = 数据库操作类.GetTableBySql(strSql);

            if (tb.Rows.Count == 0)
            {
                return;
            }

            foreach (DataRow dr in tb.Rows)
            {
                label1.Text = Convert.ToString(dr["变送器型号"]);
                label2.Text = Convert.ToString(dr["变送器编号"]);
                label3.Text = Convert.ToString(dr["进口表距"]);
                label4.Text = Convert.ToString(dr["量程上限"]);
                label5.Text = Convert.ToString(dr["量程下限"]);
                label6.Text = Convert.ToString(dr["有效期"]);
                return;
            }
        }
        private void 设定出口压力仪表值()
        {
            string strSql = "Select * from 出口压力仪表 where ID = " + 全局缓存.当前试验组信息.出口压力仪表ID;
            DataTable tb = 数据库操作类.GetTableBySql(strSql);

            if (tb.Rows.Count == 0)
            {
                return;
            }

            foreach (DataRow dr in tb.Rows)
            {
                label1.Text = Convert.ToString(dr["变送器型号"]);
                label2.Text = Convert.ToString(dr["变送器编号"]);
                label3.Text = Convert.ToString(dr["出口表距"]);
                label4.Text = Convert.ToString(dr["量程上限"]);
                label5.Text = Convert.ToString(dr["量程下限"]);
                label6.Text = Convert.ToString(dr["有效期"]);
                return;
            }
        }
        private void 设定功率测量仪表值()
        {
            string strSql = "Select * from 功率测量仪表 where ID = " + 全局缓存.当前试验组信息.功率测量仪表ID;
            DataTable tb = 数据库操作类.GetTableBySql(strSql);

            if (tb.Rows.Count == 0)
            {
                return;
            }

            foreach (DataRow dr in tb.Rows)
            {
                label1.Text = Convert.ToString(dr["测功方式"]);
                label2.Text = Convert.ToString(dr["扭矩传感器规格"]);
                label3.Text = Convert.ToString(dr["扭矩传感器编号"]);
                label4.Text = Convert.ToString(dr["二次仪表编号"]);
                label5.Text = Convert.ToString(dr["检定有效日期"]);
                label6.Text = Convert.ToString(dr["电测功电压选择"]);
                label7.Text = Convert.ToString(dr["变送器编号"]);
                return;
            }
        }
        private void 设定温度测量仪表值()
        {
            string strSql = "Select * from 温度测量仪表 where ID = " + 全局缓存.当前试验组信息.温度测量仪表ID;
            DataTable tb = 数据库操作类.GetTableBySql(strSql);

            if (tb.Rows.Count == 0)
            {
                return;
            }

            foreach (DataRow dr in tb.Rows)
            {
                label1.Text = Convert.ToString(dr["传感器类型"]);
                label2.Text = Convert.ToString(dr["传感器编号"]);
                return;
            }
        }
        private void 设定液力耦合器值()
        {
            string strSql = "Select * from 液力耦合器 where ID = " + 全局缓存.当前试验组信息.液力耦合器ID;
            DataTable tb = 数据库操作类.GetTableBySql(strSql);

            if (tb.Rows.Count == 0)
            {
                return;
            }

            foreach (DataRow dr in tb.Rows)
            {
                label1.Text = Convert.ToString(dr["耦合器型号"]);
                label2.Text = Convert.ToString(dr["传出转速上限"]);
                label3.Text = Convert.ToString(dr["出厂编号"]);
                label4.Text = Convert.ToString(dr["传出转速下限"]);
                label5.Text = Convert.ToString(dr["传递功率"]);
                label6.Text = Convert.ToString(dr["耦合器制造商"]);
                label7.Text = Convert.ToString(dr["传入转速"]);
                label8.Text = Convert.ToString(dr["传递效率"]);
                return;
            }
        }
        private void 当前试验组_Load(object sender, EventArgs e)
        {
            listBox_试验项.SetSelected(0, true);
        }
    }
}
