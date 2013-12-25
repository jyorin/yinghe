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
    public partial class 电机型号管理方案选择 : Form
    {
        private DataTable datatable;
        private DataTable GridDataTabel;
        电机型号管理 电机型号管理对象 = null;
        public 电机型号管理方案选择(电机型号管理 电机型号管理)
        {
            InitializeComponent();
            this._gridControl.InitViewLayout("管理表格配置\\电机型号管理方案.xml");
            电机型号管理对象 = 电机型号管理;
        }


        private void simpleButton_选择_Click(object sender, EventArgs e)
        {
            选择电机型号();
        }

        private void 查询数据()
        {
            if (GridDataTabel == null)
            {
                GridDataTabel = new DataTable();
                GridDataTabel.Columns.Add("ID");
                GridDataTabel.Columns.Add("电机制造商");
                GridDataTabel.Columns.Add("电机型号");
                GridDataTabel.Columns.Add("出厂编号");
            }
            GridDataTabel.Clear();

            datatable = 数据库操作类.GetTable("dbo.电机型号管理方案");
            foreach (DataRow dr in datatable.Rows)
            {
                DataRow GridDataRow = GridDataTabel.NewRow();//声明行
                string idd = (string)dr["电机制造商"];
                object[] objs = { dr["ID"], dr["电机制造商"], dr["电机型号"], dr["出厂编号"] }; //赋值 
                GridDataRow.ItemArray = objs;
                GridDataTabel.Rows.Add(GridDataRow); //添加行 
            }


            this._gridControl.SetDataSource(GridDataTabel);
        }
        private void 删除电机型号()
        {
            Decimal ID = -1;
            ID = Convert.ToDecimal(this._gridControl.GetFocusedRowCellValue("ID"));
            if (ID >= 0)
            {
                string strsql = "delete from dbo.电机型号管理方案 where ID =" + ID;
                数据库操作库.数据库操作类.ExcuteSql(strsql);
                strsql = "delete from dbo.电机型号管理方案_功率效率点 where ID =" + ID;
                数据库操作库.数据库操作类.ExcuteSql(strsql);
            }
        }
        private void 选择电机型号()
        {
            Decimal ID = -1;
            ID = Convert.ToDecimal(this._gridControl.GetFocusedRowCellValue("ID"));
            datatable.Clear();
            datatable = 数据库操作库.数据库操作类.GetTable("dbo.电机型号管理方案");

            foreach (DataRow dr in datatable.Rows)
            {
                if (ID == Convert.ToDecimal(dr["ID"]))
                {
                    电机型号管理对象.控件赋值("电机型号",Convert.ToString(dr["电机型号"]));
                    电机型号管理对象.控件赋值("电机制造商",Convert.ToString(dr["电机制造商"]));
                    电机型号管理对象.控件赋值("出厂编号",Convert.ToString(dr["出厂编号"]));
                    电机型号管理对象.控件赋值("额定电压",Convert.ToString(dr["额定电压"]));
                    电机型号管理对象.控件赋值("额定电流",Convert.ToString(dr["额定电流"]));
                    电机型号管理对象.控件赋值("额定功率",Convert.ToString(dr["额定功率"]));
                    电机型号管理对象.控件赋值("额定效率", Convert.ToString(dr["额定效率"]));                        
                }
            }

          datatable = 数据库操作库.数据库操作类.GetTable("dbo.电机型号管理方案_功率效率点");
          电机型号管理对象.设置功率效率点(ID,datatable);
          电机型号管理对象.Show_ListBox();
          this.Close();
        }

        private void 电机型号管理方案选择_Load(object sender, EventArgs e)
        {
            查询数据();
        }

        private void simpleButton_关闭_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 删除_Click(object sender, EventArgs e)
        {
            删除电机型号();
            查询数据();
        }
    }
}
