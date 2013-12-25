using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using 数据库操作库;

namespace Main.管理界面
{
    public partial class 水泵型号管理方案选择 : Form
    {
        private DataTable datatable;
        private DataTable GridDataTabel;
        水泵型号管理 水泵型号管理对象 = null;

        public 水泵型号管理方案选择(水泵型号管理 水泵型号管理)
        {
            InitializeComponent();
            this._gridControl.InitViewLayout("管理表格配置\\水泵型号管理方案.xml");
            水泵型号管理对象 = 水泵型号管理;
        }

        private void 查询数据()
        {
            if (GridDataTabel == null)
            {
                GridDataTabel = new DataTable();
                GridDataTabel.Columns.Add("ID");
                GridDataTabel.Columns.Add("用户名称");
                GridDataTabel.Columns.Add("水泵型号");
                GridDataTabel.Columns.Add("出厂编号");
            }
            GridDataTabel.Clear();

            datatable = 数据库操作类.GetTable("dbo.水泵型号管理方案");
            foreach (DataRow dr in datatable.Rows)
            {
                DataRow GridDataRow = GridDataTabel.NewRow();//声明行
                object[] objs = { dr["ID"], dr["用户名称"], dr["水泵型号"], dr["出厂编号"] }; //赋值 
                GridDataRow.ItemArray = objs;
                GridDataTabel.Rows.Add(GridDataRow); //添加行 
            }

            this._gridControl.SetDataSource(GridDataTabel);
        }

        private void 删除水泵型号()
        {
            Decimal ID = -1;
            ID = Convert.ToDecimal(this._gridControl.GetFocusedRowCellValue("ID"));
            if (ID >= 0)
            {
                string strsql = "delete from dbo.水泵型号管理方案 where ID =" + ID;
                数据库操作库.数据库操作类.ExcuteSql(strsql);
            }
        }
        private void 选择水泵型号()
        {
            Decimal ID = -1;
            ID = Convert.ToDecimal(this._gridControl.GetFocusedRowCellValue("ID"));
            datatable.Clear();
            datatable = 数据库操作库.数据库操作类.GetTable("dbo.水泵型号管理方案");

            foreach (DataRow dr in datatable.Rows)
            {
                if (ID == Convert.ToDecimal(dr["ID"]))
                {
                    水泵型号管理对象.控件赋值("水泵型号", Convert.ToString(dr["水泵型号"]));
                    水泵型号管理对象.控件赋值("水泵类型", Convert.ToString(dr["水泵类型"]));
                    水泵型号管理对象.控件赋值("用户名称", Convert.ToString(dr["用户名称"]));
                    水泵型号管理对象.控件赋值("出厂编号", Convert.ToString(dr["出厂编号"]));
                    水泵型号管理对象.控件赋值("额定流量", Convert.ToString(dr["额定流量"]));
                    水泵型号管理对象.控件赋值("额定扬程", Convert.ToString(dr["额定扬程"]));
                    水泵型号管理对象.控件赋值("额定轴功率", Convert.ToString(dr["额定轴功率"]));
                    水泵型号管理对象.控件赋值("汽蚀余量", Convert.ToString(dr["汽蚀余量"]));
                    水泵型号管理对象.控件赋值("进口直径", Convert.ToString(dr["进口直径"]));
                    水泵型号管理对象.控件赋值("出口直径", Convert.ToString(dr["出口直径"]));
                    水泵型号管理对象.控件赋值("额定转速", Convert.ToString(dr["额定转速"]));
                    //水泵型号管理对象.控件赋值("安装图片", Convert.ToString(dr["安装图片"]));
                    水泵型号管理对象.控件赋值("工况1_流量", Convert.ToString(dr["工况1_流量"]));
                    水泵型号管理对象.控件赋值("工况2_流量", Convert.ToString(dr["工况2_流量"]));
                    水泵型号管理对象.控件赋值("工况3_流量", Convert.ToString(dr["工况3_流量"]));
                    水泵型号管理对象.控件赋值("工况4_流量", Convert.ToString(dr["工况4_流量"]));
                    水泵型号管理对象.控件赋值("工况5_流量", Convert.ToString(dr["工况5_流量"]));
                    水泵型号管理对象.控件赋值("工况1_扬程", Convert.ToString(dr["工况1_扬程"]));
                    水泵型号管理对象.控件赋值("工况2_扬程", Convert.ToString(dr["工况2_扬程"]));
                    水泵型号管理对象.控件赋值("工况3_扬程", Convert.ToString(dr["工况3_扬程"]));
                    水泵型号管理对象.控件赋值("工况4_扬程", Convert.ToString(dr["工况4_扬程"]));
                    水泵型号管理对象.控件赋值("工况5_扬程", Convert.ToString(dr["工况5_扬程"]));
                    水泵型号管理对象.控件赋值("工况1_轴功率", Convert.ToString(dr["工况1_轴功率"]));
                    水泵型号管理对象.控件赋值("工况2_轴功率", Convert.ToString(dr["工况2_轴功率"]));
                    水泵型号管理对象.控件赋值("工况3_轴功率", Convert.ToString(dr["工况3_轴功率"]));
                    水泵型号管理对象.控件赋值("工况4_轴功率", Convert.ToString(dr["工况4_轴功率"]));
                    水泵型号管理对象.控件赋值("工况5_轴功率", Convert.ToString(dr["工况5_轴功率"]));
                    水泵型号管理对象.控件赋值("工况1_汽蚀余量", Convert.ToString(dr["工况1_汽蚀余量"]));
                    水泵型号管理对象.控件赋值("工况2_汽蚀余量", Convert.ToString(dr["工况2_汽蚀余量"]));
                    水泵型号管理对象.控件赋值("工况3_汽蚀余量", Convert.ToString(dr["工况3_汽蚀余量"]));
                    水泵型号管理对象.控件赋值("工况4_汽蚀余量", Convert.ToString(dr["工况4_汽蚀余量"]));
                    水泵型号管理对象.控件赋值("工况5_汽蚀余量", Convert.ToString(dr["工况5_汽蚀余量"]));
                    读取图片FromDB(ID);
                }
            }
            this.Close();
        }

        private void 读取图片FromDB(Decimal ID)
        {
            DataTable dt = 数据库操作库.数据库操作类.GetTable("dbo.水泵型号管理方案");
            Byte[] buf = null;

            foreach (DataRow dr in dt.Rows)
            {
                DataRow GridDataRow = GridDataTabel.NewRow();//声明行

                if (ID == Convert.ToDecimal(dr["ID"]))
                {

                    if (dr.IsNull("安装图片") == false)
                    {
                        buf = (Byte[])dr["安装图片"];
                        水泵型号管理对象.设置图片(Image.FromStream(new MemoryStream(buf)));
                       // this.pictureBox_图片.Image = );
                        break;
                    }
                }
            }

        }


        private void simpleButton_选择_Click(object sender, EventArgs e)
        {
            选择水泵型号();
        }

        private void simpleButton_关闭_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _gridControl_Load(object sender, EventArgs e)
        {
            查询数据();
        }

        private void 删除_Click(object sender, EventArgs e)
        {
            删除水泵型号();
            查询数据();
        }
    }
}
