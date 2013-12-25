using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using 数据库操作库;

namespace Main.管理界面
{
   
    public partial class 试验组对比 : DevExpress.XtraEditors.XtraForm
    {
        NationalInstruments.UI.ScatterPlot 扬程1;
        NationalInstruments.UI.ScatterPlot 轴功率1;
        NationalInstruments.UI.ScatterPlot 泵效率1;
        NationalInstruments.UI.ScatterPlot 扬程2;
        NationalInstruments.UI.ScatterPlot 轴功率2;
        NationalInstruments.UI.ScatterPlot 泵效率2;
        List<decimal> ID试验组 = null;
        List<string> 编号试验组 = null;
        DataTable 试验组 = null;
        public 试验组对比()
        {
            InitializeComponent();
            ID试验组 = new List<decimal>();
            编号试验组 = new List<string>();
        }

        public void 绑定数据()
        {
            string[] coloumNames = new string[] { "ID", "水泵型号" };
            string[] columIDs = new string[] { "ID", "水泵型号" };
            string[] invisibleColums = new string[] { "ID"};
            this.grid1.SetGridColumns(coloumNames, columIDs, invisibleColums);
            string sql = "select ID,水泵型号 from 水泵型号管理";
            DataTable tb = 数据库操作类.GetTableBySql(sql);
            this.grid1.ExportView.GridControl.DataSource = tb;

            this.grid2.ExportView.OptionsView.EnableAppearanceEvenRow = false;
            this.grid2.ExportView.OptionsView.EnableAppearanceOddRow = false;
            string[] _coloumNames = new string[] { "选择试验组","ID", "试验组名","试验编号" };
            string[] _invisibleColums = new string[] { "ID" };
            string[] _columIDs = new string[] { "isCheck","ID", "试验组名","试验编号" };
            this.grid2.SetGridColumns(_coloumNames, _columIDs, _invisibleColums);
            RepositoryItemCheckEdit radio = new RepositoryItemCheckEdit();
            this.grid2.ExportView.Columns[0].ColumnEdit = radio;
            this.grid2.ExportView.Columns[0].OptionsColumn.AllowEdit = true;
            this.grid2.SetReadOnly(false);
            decimal id = -1;
            if (tb.Rows.Count > 0)
            {
                id = System.Convert.ToDecimal(tb.Rows[0]["id"].ToString());
            }
            sql = "select ID,试验组名,试验编号 from 生成试验组 where 被试水泵ID=" + id;
            试验组 = 数据库操作类.GetTableBySql(sql);
            试验组.Columns.Add("isCheck",typeof(bool));
            foreach (DataRow col in 试验组.Rows)
            {
                col["isCheck"] = false;
            }
            this.grid2.ExportView.GridControl.DataSource = 试验组;        
        }

        public void 重新绑定试验组(decimal id)
        {
            string sql = "select ID,试验组名,试验编号 from 生成试验组 where 被试水泵ID=" + id;
            DataTable tb = 数据库操作类.GetTableBySql(sql);
            试验组.Clear();
            int count = tb.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                试验组.ImportRow(tb.Rows[i]);
            }
        }

        private void 试验组对比_Load(object sender, EventArgs e)
        {
            绑定数据();
           
        }

        private void grid1_Btn执行命令1Click(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)this.grid1.ExportView.GetRow(this.grid1.ExportView.FocusedRowHandle);
            if (row != null)
            {
                decimal id = System.Convert.ToDecimal(row["id"].ToString());
                重新绑定试验组(id);
            }
        }

        private void grid2_Btn执行命令1Click(object sender, EventArgs e)
        {
            this.ID试验组.Clear();
            this.编号试验组.Clear();
            int count = this.试验组.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.试验组.Rows[i]["isCheck"].ToString() == "True")
                {
                    if (ID试验组.Count == 2)
                    {
                        MessageBox.Show("选择不能多于两个选项");
                        return;
                    }
                    ID试验组.Add(System.Convert.ToDecimal(this.试验组.Rows[i]["id"].ToString()));
                    编号试验组.Add(this.试验组.Rows[i]["试验编号"].ToString());
                }
            }
            if (ID试验组.Count == 1)
            {
                MessageBox.Show("选择不能少于两个选项");
                return;
            }
            this.T_试验1.Text = "试验1:" + 编号试验组[0];
            this.T_试验2.Text = "试验2:" + 编号试验组[1];
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                this.扬程1 = new NationalInstruments.UI.ScatterPlot();
                this.扬程1.LineColor = Color.Red;
                this.扬程1.YAxis = new NationalInstruments.UI.YAxis();
                选择Y轴(this.扬程1);
                this.xyGraph1.Graph.YAxes.Add(this.扬程1.YAxis);
                this.xyGraph1.Graph.Plots.Add(this.扬程1);
                PaintWave(this.ID试验组[0],"扬程",this.扬程1);
                
            }
            else
            {
                this.xyGraph1.Graph.Plots.Remove(this.扬程1);
            }
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit2.Checked)
            {
                Color aa = Color.FromArgb(128, 255, 128);     
                this.轴功率1 = new NationalInstruments.UI.ScatterPlot();
                this.轴功率1.LineColor = aa;
                this.轴功率1.YAxis = new NationalInstruments.UI.YAxis();
                选择Y轴(this.轴功率1);
                this.xyGraph1.Graph.YAxes.Add(this.轴功率1.YAxis);
                this.xyGraph1.Graph.Plots.Add(this.轴功率1);
                PaintWave(this.ID试验组[0], "轴功率", this.轴功率1);
            }
            else
            {
                this.xyGraph1.Graph.Plots.Remove(this.轴功率1);
            }
        }

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit3.Checked)
            {
                Color aa = Color.FromArgb(255, 255, 128); 
                this.泵效率1 = new NationalInstruments.UI.ScatterPlot();
                this.泵效率1.LineColor = aa;
                this.泵效率1.YAxis = new NationalInstruments.UI.YAxis();
                选择Y轴(this.泵效率1);
                this.xyGraph1.Graph.YAxes.Add(this.泵效率1.YAxis);
                this.xyGraph1.Graph.Plots.Add(this.泵效率1);
                PaintWave(this.ID试验组[0], "额定转速下_泵效率", this.泵效率1);
            }
            else
            {
                this.xyGraph1.Graph.Plots.Remove(this.泵效率1);
            }
        }

        private void checkEdit4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit4.Checked)
            {
                
                this.扬程2 = new NationalInstruments.UI.ScatterPlot();
                this.扬程2.LineColor = Color.Blue;
                this.扬程2.YAxis = new NationalInstruments.UI.YAxis();
                选择Y轴(this.扬程2);
                this.xyGraph1.Graph.YAxes.Add(this.扬程2.YAxis);
                this.xyGraph1.Graph.Plots.Add(this.扬程2);
                PaintWave(this.ID试验组[1], "扬程", this.扬程2);
            }
            else
            {
                this.xyGraph1.Graph.Plots.Remove(this.扬程2);
            }
        }

        private void checkEdit5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit5.Checked)
            {
                this.轴功率2 = new NationalInstruments.UI.ScatterPlot();
                this.轴功率2.LineColor = Color.Cyan;
                this.轴功率2.YAxis = new NationalInstruments.UI.YAxis();
                选择Y轴(this.轴功率2);
                this.xyGraph1.Graph.YAxes.Add(this.轴功率2.YAxis);
                this.xyGraph1.Graph.Plots.Add(this.轴功率2);
                PaintWave(this.ID试验组[1], "轴功率", this.轴功率2);
            }
            else
            {
                this.xyGraph1.Graph.Plots.Remove(this.轴功率2);
            }
        }

        private void checkEdit6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit6.Checked)
            {
                this.泵效率2 = new NationalInstruments.UI.ScatterPlot();
                this.泵效率2.LineColor = Color.Fuchsia;
                this.泵效率2.YAxis = new NationalInstruments.UI.YAxis();
                选择Y轴(this.泵效率2);
                this.xyGraph1.Graph.YAxes.Add(this.泵效率2.YAxis);
                this.xyGraph1.Graph.Plots.Add(this.泵效率2);
                PaintWave(this.ID试验组[1], "额定转速下_泵效率", this.泵效率2);
            }
            else
            {
                this.xyGraph1.Graph.Plots.Remove(this.泵效率2);
            }
        }

        public void 选择Y轴(NationalInstruments.UI.ScatterPlot p)
        {
            if (p == null) { return; }
            int len = this.xyGraph1.Graph.YAxes.Count;
            for (int i = 0; i < len; i++)
            {
                this.xyGraph1.Graph.YAxes[i].Visible = false;
            }
            p.YAxis.Visible = true;
        }

        public void PaintWave(decimal groupid, string 列名, NationalInstruments.UI.ScatterPlot p)
        {
            string sql = string.Format("select 流量,{0} from 潜水泵性能试验 where groupid={1}",列名,groupid);
            DataTable tb = 数据库操作类.GetTableBySql(sql);
            int len = tb.Rows.Count;
            double[] _x = new double[len];
            double[] _y = new double[len];
            for (int i = 0; i < len; i++)
            {
                _x[i] = System.Convert.ToDouble(tb.Rows[i]["流量"].ToString());
                _y[i] = System.Convert.ToDouble(tb.Rows[i][列名].ToString());
            }
            this.设置X轴(_x);
            p.PlotXY(_x, _y);
        }

        private void panel_扬程1_Click(object sender, EventArgs e)
        {
            this.选择Y轴(this.扬程1);
        }

        private void panel_轴功率1_Click(object sender, EventArgs e)
        {
            this.选择Y轴(this.轴功率1);
        }

        private void panel_泵效率1_Click(object sender, EventArgs e)
        {
            this.选择Y轴(this.泵效率1);
        }

        private void panel_扬程2_Click(object sender, EventArgs e)
        {
            this.选择Y轴(this.扬程2);
        }

        private void panel_轴功率2_Click(object sender, EventArgs e)
        {
            this.选择Y轴(this.轴功率2);
        }

        private void panel_泵效率2_Click(object sender, EventArgs e)
        {
            this.选择Y轴(this.泵效率2);
        }

        double Max = 0;
        double Min = 0;
        public void 设置X轴(double[] x)
        {
            int len = x.Length;
            for (int i = 0; i < len; i++)
            {
                if (x[i] > Max) { Max = x[i]; }
                if(Min == 0)
                {
                    Min = x[i];
                    return;
                }
                if (x[i] < Min)
                {
                    Min = x[i];
                }
            }
            this.xyGraph1.Graph.XAxes[0].Range = new NationalInstruments.UI.Range(Min, Max);
           
        }
    }
}