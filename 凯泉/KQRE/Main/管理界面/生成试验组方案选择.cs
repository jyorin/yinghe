using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 数据库操作库;

namespace Main.管理界面
{
    public partial class 生成试验组方案选择 : Form
    {
        private DataTable datatable;
        private DataTable GridDataTabel;
        生成试验组 生成试验组对象 = null;
        public 生成试验组方案选择(生成试验组 生成试验组)
        {
            InitializeComponent();
            this._gridControl.InitViewLayout("管理表格配置\\生成试验组方案.xml");
            生成试验组对象 = 生成试验组;
        }

        private void simpleButton_关闭_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 删除试验组方案()
        {
            Decimal ID = -1;
            ID = Convert.ToDecimal(this._gridControl.GetFocusedRowCellValue("ID"));
            if (ID >= 0)
            {
                string strsql = "delete from dbo.生成试验组方案 where ID =" + ID;
                数据库操作库.数据库操作类.ExcuteSql(strsql);
            }
        }
        private void 查询数据()
        {
            if (GridDataTabel == null)
            {
                GridDataTabel = new DataTable();
                GridDataTabel.Columns.Add("ID");
                GridDataTabel.Columns.Add("试验日期");
                GridDataTabel.Columns.Add("试验组名");
                GridDataTabel.Columns.Add("试验编号");
            }
            GridDataTabel.Clear();

            datatable = 数据库操作类.GetTable("dbo.生成试验组方案");
            foreach (DataRow dr in datatable.Rows)
            {
                DataRow GridDataRow = GridDataTabel.NewRow();//声明行
                object[] objs = { dr["ID"], dr["试验日期"], dr["试验组名"], dr["试验编号"] }; //赋值 
                GridDataRow.ItemArray = objs;
                GridDataTabel.Rows.Add(GridDataRow); //添加行 
            }

            this._gridControl.SetDataSource(GridDataTabel);
        }

        private void 删除_Click(object sender, EventArgs e)
        {
            删除试验组方案();
            查询数据();
        }

        private void 生成试验组方案选择_Load(object sender, EventArgs e)
        {
            查询数据();
        }

        private void simpleButton_选择_Click(object sender, EventArgs e)
        {
            Decimal ID = -1;
            ID = Convert.ToDecimal(this._gridControl.GetFocusedRowCellValue("ID"));
            datatable.Clear();
            datatable = 数据库操作库.数据库操作类.GetTable("dbo.生成试验组方案");

            foreach (DataRow dr in datatable.Rows)
            {
                if (ID == Convert.ToDecimal(dr["ID"]))
                {
                    生成试验组对象.控件赋值("试验日期", Convert.ToString(dr["试验日期"]));
                    生成试验组对象.控件赋值("试验编号", Convert.ToString(dr["试验编号"]));
                    生成试验组对象.控件赋值("试验组名", Convert.ToString(dr["试验组名"]));
                    生成试验组对象.控件赋值("被试水泵ID", 生成试验组对象.获取Combobox值("被试水泵ID",Convert.ToString(dr["被试水泵ID"])));
                    生成试验组对象.控件赋值("拖动电机ID", 生成试验组对象.获取Combobox值("拖动电机ID",Convert.ToString(dr["拖动电机ID"])));
                    生成试验组对象.控件赋值("流量仪表ID", 生成试验组对象.获取Combobox值("流量仪表ID",Convert.ToString(dr["流量仪表ID"])));
                    生成试验组对象.控件赋值("转速测量ID", 生成试验组对象.获取Combobox值("转速测量ID",Convert.ToString(dr["转速测量ID"])));
                    生成试验组对象.控件赋值("进口压力仪表ID", 生成试验组对象.获取Combobox值("进口压力仪表ID",Convert.ToString(dr["进口压力仪表ID"])));
                    生成试验组对象.控件赋值("出口压力仪表ID", 生成试验组对象.获取Combobox值("出口压力仪表ID",Convert.ToString(dr["出口压力仪表ID"])));
                    生成试验组对象.控件赋值("功率测量仪表ID", 生成试验组对象.获取Combobox值("功率测量仪表ID",Convert.ToString(dr["功率测量仪表ID"])));
                    生成试验组对象.控件赋值("温度测量仪表ID", 生成试验组对象.获取Combobox值("温度测量仪表ID",Convert.ToString(dr["温度测量仪表ID"])));
                    生成试验组对象.控件赋值("液力耦合器ID", 生成试验组对象.获取Combobox值("液力耦合器ID",Convert.ToString(dr["液力耦合器ID"]))); 
                }
            }

            this.Close();
        }
    }
}
