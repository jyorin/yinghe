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

    public partial class 电机型号管理 : DevExpress.XtraEditors.XtraForm
    {
        private struct 功率效率点
        {
            public double 输出功率P2;
            public double 效率η;
        }
        private Decimal ID号 = -1;
        private FormElement _form = null;
        private DataTable GridDataTabel = null;
        private List<功率效率点> 功率效率点集合 = new List<功率效率点>();
        public 电机型号管理()
        {
            InitializeComponent();
            功率效率点集合.Clear();
            this.grid1.InitViewLayout("管理表格配置\\电机型号管理表格.xml");
        }
        public void 控件赋值(string 字段名, string 值)
        {
              _form.GetControlElementByInfo("dbo.电机型号管理", 字段名).SetValue(值);   
        }
        public void 设置功率效率点(Decimal id,DataTable data)
        {
            Decimal _id = 0;
            功率效率点集合.Clear();
            foreach (DataRow dr in data.Rows)
            {
                _id = Convert.ToDecimal(dr["ID"]);
                if (_id == id)
                {
                    功率效率点 功率效率点 = new 功率效率点();
                    功率效率点.输出功率P2 = Convert.ToDouble(dr["输出功率P2"]);
                    功率效率点.效率η = Convert.ToDouble(dr["效率η"]);
                    功率效率点集合.Add(功率效率点);
                }
            }
        }

        // public void 控件

        private void 保存_电机型号管理数据()
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.SaveTabs(new string[] { "dbo.电机型号管理" });
        }
        private void 删除_电机型号管理数据()
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.deleteTabs(new string[] { "dbo.电机型号管理" });
        }
        private void 查询_电机型号管理数据()
        {
            DataTable dt = _form.SelectTabs("dbo.电机型号管理");
            // object value = null;
            if (GridDataTabel == null)
            {
                GridDataTabel = new DataTable();
                GridDataTabel.Columns.Add("ID");
                GridDataTabel.Columns.Add("电机制造商");
                GridDataTabel.Columns.Add("电机型号");
                GridDataTabel.Columns.Add("出厂编号");
            }
            GridDataTabel.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                DataRow GridDataRow = GridDataTabel.NewRow();//声明行
                object[] objs = { dr["ID"], dr["电机制造商"], dr["电机型号"], dr["出厂编号"]}; //赋值 
                GridDataRow.ItemArray = objs;
                GridDataTabel.Rows.Add(GridDataRow); //添加行 
            }

            this.grid1.SetDataSource(GridDataTabel);
        }

        private void simpleButton1_保存型号信息_Click(object sender, EventArgs e)
        {
            保存_电机型号管理数据();
            Insert_功率效率点ToDB();
            查询_电机型号管理数据();
            MessageBox.Show("数据保存成功！", "提示");
        }

        private void 电机型号管理_Load(object sender, EventArgs e)
        {
            if (_form == null)
            {
                _form = new FormElement();
            }
            _form.LoadTabs(new string[] { "dbo.电机型号管理" }, new decimal[] { -1 });
            _form.AddControlByLayout(this.panel_电机制造商, "dbo.电机型号管理", "电机制造商");
            _form.AddControlByLayout(this.panel_出厂编号, "dbo.电机型号管理", "出厂编号");
            _form.AddControlByLayout(this.panel_电机型号, "dbo.电机型号管理", "电机型号");
            _form.AddControlByLayout(this.panel_额定电压, "dbo.电机型号管理", "额定电压");
            _form.AddControlByLayout(this.panel_额定电流, "dbo.电机型号管理", "额定电流");
            _form.AddControlByLayout(this.panel_额定功率, "dbo.电机型号管理", "额定功率");
            _form.AddControlByLayout(this.panel_额定效率, "dbo.电机型号管理", "额定效率");
            查询_电机型号管理数据();
        }

        private void grid1_BtnReduceRowClick(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("是否要删除选择行？", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                删除_电机型号管理数据();
                查询_电机型号管理数据();
            }
        }

        private void grid1_BtnAddRowClick(object sender, EventArgs e)
        {
            _form.ClearFormTable("dbo.电机型号管理");
        }

        private void grid1_SelectRow(int nline)
        {
            Decimal id = -1;
            id = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));
            foreach (DataRow dr in GridDataTabel.Rows)
            {
                if (id == Convert.ToDecimal(dr["ID"]))
                {
                    _form.SetId("dbo.电机型号管理", id);
                    _form.LoadTabs(new string[] { "dbo.电机型号管理" }, new decimal[] { id });
                    _form.BindControlAgin("dbo.电机型号管理");
                    ID号 = id;
                    Sel_功率效率点FromDB(id);
                    Show_ListBox();
                }
            }
        }


        private void simpleButton_功率效率点_Click(object sender, EventArgs e)
        {
            Push_功率效率点();
        }

        private void Sel_功率效率点FromDB(Decimal id)
        {
            DataTable data = _form.SelectTabsBySql("select * from dbo.电机型号功率效率点");
            设置功率效率点(id, data);
        }

       
        private void Insert_功率效率点ToDB()
        {
            string strSql = "Delete from dbo.电机型号功率效率点 where id=" + ID号;
            _form.ExcuteSql(strSql);
            foreach (功率效率点 _功率效率点 in 功率效率点集合)
            {
                strSql = "Insert into dbo.电机型号功率效率点 (id,输出功率P2,效率η) values (" + ID号 + "," + _功率效率点.输出功率P2 + "," + _功率效率点.效率η + ")";
                _form.ExcuteSql(strSql);
            }

        }

        private void Push_功率效率点()
        {
            if ((textEdit_输出功率P2.Text.Equals("") == true) ||
                (textEdit_效率η.Text.Equals("") == true))
            {
                return;
            }
            string strtext = "";
            功率效率点 功率效率点 = new 功率效率点();
            功率效率点.输出功率P2 = Convert.ToDouble(textEdit_输出功率P2.Text);
            功率效率点.效率η = Convert.ToDouble(textEdit_效率η.Text);
            功率效率点集合.Add(功率效率点);
            strtext = "p:";
            strtext += textEdit_输出功率P2.Text;
            strtext += "|η:";
            strtext += textEdit_效率η.Text;
            listBoxControl_功率效率点.Items.Add(strtext);
        }

        public void Show_ListBox()
        {
            string strtext = "";
            listBoxControl_功率效率点.Items.Clear();
            foreach(功率效率点 _功率效率点 in 功率效率点集合)
            {
                strtext = "p:";
                strtext += _功率效率点.输出功率P2;
                strtext += "|η:";
                strtext += _功率效率点.效率η;
                listBoxControl_功率效率点.Items.Add(strtext);
            }

        }

        private int Del_功率效率点()
        {
            int index = listBoxControl_功率效率点.SelectedIndex;
            listBoxControl_功率效率点.Items.RemoveAt(listBoxControl_功率效率点.SelectedIndex);
            return index;
           // string filed = listBoxControl_功率效率点.SelectedItem.ToString();
           // listBoxControl_功率效率点.
        }

        private void btn_删除功率效率点_Click(object sender, EventArgs e)
        {
            int index = Del_功率效率点();
            功率效率点集合.RemoveAt(index);
        }
        private void simpleButton_生成拟合曲线_Click(object sender, EventArgs e)
        {
            int count = 功率效率点集合.Count;
            scatterGraph1.ClearData();
            if (count > 0)
            {
                double[] x = new double[count];
                double[] y = new double[count];
                int i=0;
                foreach (功率效率点 _功率效率点 in 功率效率点集合)
                {
                    x[i] = _功率效率点.输出功率P2;
                    y[i] = _功率效率点.效率η;
                    i++;
                    scatterGraph1.Plots[0].PlotXY(x, y);
                }
            }
        }
        private void simpleButton_方案选择_Click(object sender, EventArgs e)
        {
            电机型号管理方案选择 _form = new 电机型号管理方案选择(this);
            _form.ShowDialog(); 
        }
        private void simpleButton_方案保存_Click(object sender, EventArgs e)
        {
              存储方案();
              MessageBox.Show("方案保存成功！", "提示");
        }
        private Boolean 方案是否已经存在()
        {
            DataTable _data = null;
            string strSql = "select * from dbo.电机型号管理方案";
            _data = _form.SelectTabsBySql(strSql);
            Decimal ID = -1;
            ID = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));
            foreach (DataRow dr in _data.Rows)
            {
                Decimal _id = Convert.ToDecimal(dr["ID"]);

                if (_id == ID)
                {
                    return true;
                }
            }
            return false;
        }
        private void 存储方案()
        {
            Decimal id = -1;
            string strSql = "";
            id = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));
            if (id == -1)
            {
                MessageBox.Show("存储方案失败!", "错误");
                return;
            }

            if (方案是否已经存在() == false)
            {
                strSql = 方案保存_拼接插入Sql();
            }
            else
            {
                strSql = 方案保存_拼接更新Sql();
            }
          
            Insert_电机型号管理方案_功率效率点(id);

            _form.ExcuteSql(strSql);
        }
        private void Insert_电机型号管理方案_功率效率点(Decimal id)
        {
            string strSql = "Delete from dbo.电机型号管理方案_功率效率点 where id=" + id;
            _form.ExcuteSql(strSql);
            foreach (功率效率点 _功率效率点 in 功率效率点集合)
            {
                strSql = "Insert into dbo.电机型号管理方案_功率效率点 (id,输出功率P2,效率η) values (" + id + "," + _功率效率点.输出功率P2 + "," + _功率效率点.效率η + ")";
                _form.ExcuteSql(strSql);
            }
        }

        private string 方案保存_拼接插入Sql()
        {
            Decimal id = -1;
            id = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));
            string strSql = "insert dbo.电机型号管理方案  (ID,电机型号,电机制造商,出厂编号,额定电压,额定电流,额定功率,额定效率) values (" +
                             id + ",";

            ControlElement control = _form.GetControlElementByInfo("dbo.电机型号管理", "电机型号");
            strSql += "'";
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.电机型号管理", "电机制造商");
            strSql += "'";
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.电机型号管理", "出厂编号");
            strSql += "'";
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.电机型号管理", "额定电压");
            strSql += "'";
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.电机型号管理", "额定电流");
            strSql += "'";
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.电机型号管理", "额定功率");
            strSql += "'";
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.电机型号管理", "额定效率");
            strSql += "'";
            strSql += control.GetValue();
            strSql += "')";

            return strSql;
        }
        private string 方案保存_拼接更新Sql()
        {
            Decimal id = -1;
            id = Convert.ToDecimal(this.grid1.GetFocusedRowCellValue("ID"));
            string strSql = "update dbo.电机型号管理方案  set ";

            ControlElement control = _form.GetControlElementByInfo("dbo.电机型号管理", "电机型号");
            strSql += "电机型号='";
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.电机型号管理", "电机制造商");
            strSql += "电机制造商='";
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.电机型号管理", "出厂编号");
            strSql += "出厂编号='";
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.电机型号管理", "额定电压");
            strSql += "额定电压='";
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.电机型号管理", "额定电流");
            strSql += "额定电流='";
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.电机型号管理", "额定功率");
            strSql += "额定功率='";
            strSql += control.GetValue();
            strSql += "',";
            control = _form.GetControlElementByInfo("dbo.电机型号管理", "额定效率");
            strSql += "额定效率='";
            strSql += control.GetValue();
            strSql += "' where ID=" + id;

            return strSql;
        }
    }
}