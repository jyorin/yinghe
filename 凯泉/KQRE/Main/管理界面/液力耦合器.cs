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
    public partial class 液力耦合器 : DevExpress.XtraEditors.XtraForm
    {
        private DataTable GridDataTabel = null;
        private FormElement _form=null;
        public 液力耦合器()
        {
            InitializeComponent();
            this.grid1.InitViewLayout("管理表格配置\\液力耦合器表格.xml");
        }

        private void 液力耦合器_Load(object sender, EventArgs e)
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.LoadTabs(new string[] { "dbo.液力耦合器" }, new decimal[] { -1 });
            _form.AddControlByLayout(this.panel_耦合器制造商, "dbo.液力耦合器", "耦合器制造商");
            _form.AddControlByLayout(this.panel_耦合器型号, "dbo.液力耦合器", "耦合器型号");
            _form.AddControlByLayout(this.panel_出厂编号, "dbo.液力耦合器", "出厂编号");
            _form.AddControlByLayout(this.panel_传递功率, "dbo.液力耦合器", "传递功率");
            _form.AddControlByLayout(this.panel_传入转速, "dbo.液力耦合器", "传入转速");
            _form.AddControlByLayout(this.panel_传出转速上限, "dbo.液力耦合器", "传出转速上限");
            _form.AddControlByLayout(this.panel_传出转速下限, "dbo.液力耦合器", "传出转速下限");
            _form.AddControlByLayout(this.panel_传递效率, "dbo.液力耦合器", "传递效率");
            查询_水泵型号管理数据();
        }
        private void 保存_液力耦合器数据()
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.SaveTabs(new string[] { "dbo.液力耦合器" });
        }

        private void 删除_液力耦合器数据()
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.deleteTabs(new string[] { "dbo.液力耦合器" });
        }
        private void simpleButton1_保存型号信息_Click(object sender, EventArgs e)
        {
            保存_液力耦合器数据();
            查询_水泵型号管理数据();
            MessageBox.Show("数据保存成功！", "提示");
        }

        private void grid1_BtnReduceRowClick(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("是否要删除选择行？", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                删除_液力耦合器数据();
                查询_水泵型号管理数据();
            }
        }

        private void 查询_水泵型号管理数据()
        {
            DataTable dt = _form.SelectTabs("dbo.液力耦合器");
            // object value = null;
            if (GridDataTabel == null)
            {
                GridDataTabel = new DataTable();
                GridDataTabel.Columns.Add("ID");
                GridDataTabel.Columns.Add("耦合器制造商");
                GridDataTabel.Columns.Add("耦合器型号");
                GridDataTabel.Columns.Add("出厂编号");
            }
            GridDataTabel.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                DataRow GridDataRow = GridDataTabel.NewRow();//声明行
                object[] objs = { dr["ID"], dr["耦合器制造商"], dr["耦合器型号"], dr["出厂编号"] }; //赋值 
                GridDataRow.ItemArray = objs;
                GridDataTabel.Rows.Add(GridDataRow); //添加行 
            }

            this.grid1.SetDataSource(GridDataTabel);

        }

        private void grid1_BtnAddRowClick(object sender, EventArgs e)
        {
            _form.ClearFormTable("dbo.液力耦合器");
        }

        private void grid1_SelectRow(int nline)
        {
            Decimal id = -1;
            id = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));
            foreach (DataRow dr in GridDataTabel.Rows)
            {
                if (id == Convert.ToDecimal(dr["ID"]))
                {
                    _form.SetId("dbo.液力耦合器", id);
                    _form.LoadTabs(new string[] { "dbo.液力耦合器" }, new decimal[] { id });
                    _form.BindControlAgin("dbo.液力耦合器");
                }
            }
        }
    }
}