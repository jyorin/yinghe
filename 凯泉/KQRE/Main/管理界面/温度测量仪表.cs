using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AutoControl;

namespace Main.管理界面
{
    public partial class 温度测量仪表 : DevExpress.XtraEditors.XtraForm
    {
        private DataTable GridDataTabel = null;
        private FormElement _form = null;
        public 温度测量仪表()
        {
            InitializeComponent();
            this.grid1.InitViewLayout("管理表格配置\\温度测量仪表表格.xml");
        }
        private void 保存_温度测量仪表数据()
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.SaveTabs(new string[] { "dbo.温度测量仪表" });
        }


        private void 删除_温度测量仪表数据()
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.deleteTabs(new string[] { "dbo.温度测量仪表" });
        }

        private void 查询_温度测量仪表数据()
        {
            DataTable dt = _form.SelectTabs("dbo.温度测量仪表");
            // object value = null;
            if (GridDataTabel == null)
            {
                GridDataTabel = new DataTable();
                GridDataTabel.Columns.Add("ID");
                GridDataTabel.Columns.Add("传感器类型");
                GridDataTabel.Columns.Add("传感器编号");
            }
            GridDataTabel.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                DataRow GridDataRow = GridDataTabel.NewRow();//声明行
                object[] objs = { dr["ID"], dr["传感器类型"], dr["传感器编号"]}; //赋值 
                GridDataRow.ItemArray = objs;
                GridDataTabel.Rows.Add(GridDataRow); //添加行 
            }

            this.grid1.SetDataSource(GridDataTabel);

        }


        private void 温度测量仪表_Load(object sender, EventArgs e)
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.LoadTabs(new string[] { "dbo.温度测量仪表" }, new decimal[] { -1 });
            _form.AddControlByLayout(this.panel_传感器类型, "dbo.温度测量仪表", "传感器类型");
            _form.AddControlByLayout(this.panel_传感器编号, "dbo.温度测量仪表", "传感器编号");
            查询_温度测量仪表数据();
        }

        private void simpleButton1_保存型号信息_Click(object sender, EventArgs e)
        {
            保存_温度测量仪表数据();
            查询_温度测量仪表数据();
            MessageBox.Show("数据保存成功！", "提示");
        }

        private void grid1_BtnReduceRowClick(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("是否要删除选择行？", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                删除_温度测量仪表数据();
                查询_温度测量仪表数据();
            }
        }

        private void grid1_BtnAddRowClick(object sender, EventArgs e)
        {
            _form.ClearFormTable("dbo.温度测量仪表");
        }

        private void grid1_SelectRow(int nline)
        {
            Decimal id = -1;
            id = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));
            foreach (DataRow dr in GridDataTabel.Rows)
            {
                if (id == Convert.ToDecimal(dr["ID"]))
                {
                    _form.SetId("dbo.温度测量仪表", id);
                    _form.LoadTabs(new string[] { "dbo.温度测量仪表" }, new decimal[] { id });
                    _form.BindControlAgin("dbo.温度测量仪表");
                }
            }
        }
    }
}