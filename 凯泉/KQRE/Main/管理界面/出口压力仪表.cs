using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AutoControl;
using DevExpress.XtraGrid;

namespace Main.管理界面
{
    public partial class 出口压力仪表 : DevExpress.XtraEditors.XtraForm
    {
        private FormElement _form = null;
        private DataTable GridDataTabel = null;
        public 出口压力仪表()
        {
            InitializeComponent();
            this.grid1.InitViewLayout("管理表格配置\\出口压力仪表表格.xml");
        }
        private void 保存_出口压力仪表数据()
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.SaveTabs(new string[] { "dbo.出口压力仪表" });
        }
        private void 删除_出口压力仪表数据()
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.deleteTabs(new string[] { "dbo.出口压力仪表" });
        }

        private void 查询_出口压力仪表数据()
        {
            DataTable dt = _form.SelectTabs("dbo.出口压力仪表");
           // object value = null;
            if (GridDataTabel == null)
            {
                GridDataTabel = new DataTable();
                GridDataTabel.Columns.Add("ID");
                GridDataTabel.Columns.Add("变送器型号");
                GridDataTabel.Columns.Add("变送器编号");
            }
            GridDataTabel.Clear();

            foreach(DataRow dr in dt.Rows)
            {
                 DataRow GridDataRow = GridDataTabel.NewRow();//声明行
                 object[] objs = {dr["ID"],dr["变送器型号"],dr["变送器编号"] }; //赋值 
                 GridDataRow.ItemArray = objs;
                 GridDataTabel.Rows.Add(GridDataRow); //添加行 
            }

            this.grid1.SetDataSource(GridDataTabel);

        }

        private void simpleButton1_保存型号信息_Click(object sender, EventArgs e)
        {
            保存_出口压力仪表数据();
            查询_出口压力仪表数据();
            MessageBox.Show("数据保存成功！", "提示");
        }
        private void 出口压力仪表_Load(object sender, EventArgs e)
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.LoadTabs(new string[] { "dbo.出口压力仪表" }, new decimal[] { -1 });
            _form.AddControlByLayout(this.panel_变送器型号, "dbo.出口压力仪表", "变送器型号");
            _form.AddControlByLayout(this.panel_变送器编号, "dbo.出口压力仪表", "变送器编号");
            _form.AddControlByLayout(this.panel_出口表距, "dbo.出口压力仪表", "出口表距");
            _form.AddControlByLayout(this.panel_量程上限, "dbo.出口压力仪表", "量程上限");
            _form.AddControlByLayout(this.panel_量程下限, "dbo.出口压力仪表", "量程下限");
            _form.AddControlByLayout(this.panel_有效期, "dbo.出口压力仪表", "有效期");

            查询_出口压力仪表数据();
        }

        private void grid1_BtnReduceRowClick(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("是否要删除选择行？", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                删除_出口压力仪表数据();
                查询_出口压力仪表数据();
            }
        }

        private void grid1_BtnAddRowClick(object sender, EventArgs e)
        {
            _form.ClearFormTable("dbo.出口压力仪表");
        }

        private void grid1_SelectRow(int nline)
        {
            Decimal id = -1;
            id = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));
            foreach (DataRow dr in GridDataTabel.Rows)
            {
                if (id == Convert.ToDecimal(dr["ID"]))
                {
                    _form.SetId("dbo.出口压力仪表", id);
                    _form.LoadTabs(new string[] { "dbo.出口压力仪表" }, new decimal[] { id });
                    _form.BindControlAgin("dbo.出口压力仪表");
                }
            }
        }

        //public 数据_出口压力仪表 获取数据()
        //{
       // }

    }
}