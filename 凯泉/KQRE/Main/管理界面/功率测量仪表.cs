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
    public partial class 功率测量仪表 : DevExpress.XtraEditors.XtraForm
    {
        private FormElement _form = null;
        private DataTable GridDataTabel = null;
        public 功率测量仪表()
        {
            InitializeComponent();
            this.grid1.InitViewLayout("管理表格配置\\功率测量仪表表格.xml");
        }

        private void 保存_功率测量仪表数据()
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.SaveTabs(new string[] { "dbo.功率测量仪表" });
        }


        private void 删除_功率测量仪表数据()
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.deleteTabs(new string[] { "dbo.功率测量仪表" });
        }
        private void 查询_功率测量仪表数据()
        {
            DataTable dt = _form.SelectTabs("dbo.功率测量仪表");
            // object value = null;
            if (GridDataTabel == null)
            {
                GridDataTabel = new DataTable();
                GridDataTabel.Columns.Add("ID");
                GridDataTabel.Columns.Add("测功方式");
                GridDataTabel.Columns.Add("扭矩传感器规格");
                GridDataTabel.Columns.Add("扭矩传感器编号");
            }
            GridDataTabel.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                DataRow GridDataRow = GridDataTabel.NewRow();//声明行
                object[] objs = { dr["ID"], dr["测功方式"], dr["扭矩传感器规格"], dr["扭矩传感器编号"] }; //赋值 
                GridDataRow.ItemArray = objs;
                GridDataTabel.Rows.Add(GridDataRow); //添加行 
            }

            this.grid1.SetDataSource(GridDataTabel);
        }


        private void simpleButton1_保存型号信息_Click(object sender, EventArgs e)
        {
            保存_功率测量仪表数据();
            查询_功率测量仪表数据();
            MessageBox.Show("数据保存成功！", "提示");
        }

        private void 功率测量仪表_Load(object sender, EventArgs e)
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.LoadTabs(new string[] { "dbo.功率测量仪表" }, new decimal[] { -1 });
            _form.AddControlByLayout(this.panel_测功方式, "dbo.功率测量仪表", "测功方式");
            _form.AddControlByLayout(this.panel_扭矩传感器规格, "dbo.功率测量仪表", "扭矩传感器规格");
            _form.AddControlByLayout(this.panel_二次仪表编号, "dbo.功率测量仪表", "二次仪表编号");
            _form.AddControlByLayout(this.panel_扭矩传感器编号, "dbo.功率测量仪表", "扭矩传感器编号");
            _form.AddControlByLayout(this.panel_检定有效日期, "dbo.功率测量仪表", "检定有效日期");
            _form.AddControlByLayout(this.panel_电测功电压选择, "dbo.功率测量仪表", "电测功电压选择");
            _form.AddControlByLayout(this.panel_变送器编号, "dbo.功率测量仪表", "变送器编号");
            查询_功率测量仪表数据();
        }

        private void grid1_BtnReduceRowClick(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("是否要删除选择行？", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                删除_功率测量仪表数据();
                查询_功率测量仪表数据();
            }
        }

        private void grid1_BtnAddRowClick(object sender, EventArgs e)
        {
            _form.ClearFormTable("dbo.功率测量仪表");
        }

        private void grid1_SelectRow(int nline)
        {
            Decimal id = -1;
            id = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));
            foreach (DataRow dr in GridDataTabel.Rows)
            {
                if (id == Convert.ToDecimal(dr["ID"]))
                {
                    _form.SetId("dbo.功率测量仪表", id);
                    _form.LoadTabs(new string[] { "dbo.功率测量仪表" }, new decimal[] { id });
                    _form.BindControlAgin("dbo.功率测量仪表");
                }
            }
        }
    }
}