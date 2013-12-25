using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AutoControl;
using System.Data.OleDb;
namespace Main.管理界面
{
    public partial class 流量仪表 : DevExpress.XtraEditors.XtraForm
    {
        private DataTable GridDataTabel = null;
        private FormElement _form = null;
        public 流量仪表()
        {
            InitializeComponent();
            this.grid1.InitViewLayout("管理表格配置\\流量仪表表格.xml");
        }

        private void 保存_流量仪表数据()
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.SaveTabs(new string[] { "dbo.流量仪表" });
        }

        private void simpleButton1_保存型号信息_Click(object sender, EventArgs e)
        {
            保存_流量仪表数据();
            查询_流量仪表数据();
            MessageBox.Show("数据保存成功！", "提示");
        }

        private void 流量仪表_Load(object sender, EventArgs e)
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.LoadTabs(new string[] { "dbo.流量仪表" }, new decimal[] { -1 });
            _form.AddControlByLayout(this.panel_流量计类型, "dbo.流量仪表", "流量计类型");
            _form.AddControlByLayout(this.panel_传出转速上限, "dbo.流量仪表", "传出转速上限");
            _form.AddControlByLayout(this.panel_流量计编号, "dbo.流量仪表", "流量计编号");
            _form.AddControlByLayout(this.panel_传出转速下限, "dbo.流量仪表", "传出转速下限");
            _form.AddControlByLayout(this.panel_传递功率, "dbo.流量仪表", "传递功率");
            _form.AddControlByLayout(this.panel_流量计规格, "dbo.流量仪表", "流量计规格");
            _form.AddControlByLayout(this.panel_传入转速, "dbo.流量仪表", "传入转速");
            _form.AddControlByLayout(this.panel_传递效率, "dbo.流量仪表", "传递效率");
            查询_流量仪表数据();
        }


        private void 删除_流量仪表数据()
        {
             if (_form == null)
            {
                _form = new FormElement();
            }
            _form.deleteTabs(new string[] { "dbo.流量仪表" });  
        }
        private void 查询_流量仪表数据()
        {
            DataTable dt = _form.SelectTabs("dbo.流量仪表");
            // object value = null;
            if (GridDataTabel == null)
            {
                GridDataTabel = new DataTable();
                GridDataTabel.Columns.Add("ID");
                GridDataTabel.Columns.Add("流量计类型");
                GridDataTabel.Columns.Add("流量计规格");
                GridDataTabel.Columns.Add("流量计编号");
            }
            GridDataTabel.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                DataRow GridDataRow = GridDataTabel.NewRow();//声明行
                object[] objs = { dr["ID"], dr["流量计类型"], dr["流量计规格"], dr["流量计编号"] }; //赋值 
                GridDataRow.ItemArray = objs;
                GridDataTabel.Rows.Add(GridDataRow); //添加行 
            }

            this.grid1.SetDataSource(GridDataTabel);
        }

        private void grid1_BtnReduceRowClick(object sender, EventArgs e)
        {
           DialogResult result= MessageBox.Show("是否要删除选择行？", "提示", MessageBoxButtons.OKCancel);
           if (result == DialogResult.OK)
           {
               删除_流量仪表数据();
               查询_流量仪表数据();
           }
        }

        private void grid1_BtnAddRowClick(object sender, EventArgs e)
        {
            _form.ClearFormTable("dbo.流量仪表");
        }

        private void grid1_SelectRow(int nline)
        {
            Decimal id = -1;
            id = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));
            foreach (DataRow dr in GridDataTabel.Rows)
            {
                if (id == Convert.ToDecimal(dr["ID"]))
                {
                    _form.SetId("dbo.流量仪表", id);
                    _form.LoadTabs(new string[] { "dbo.流量仪表" }, new decimal[] { id });
                    _form.BindControlAgin("dbo.流量仪表");
                }
            }
        }
    }
}