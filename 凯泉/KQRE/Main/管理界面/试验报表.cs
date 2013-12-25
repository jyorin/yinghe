using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 试验报表模型;
using 数据库操作库;
using 全局缓存;
using CrystalDecisions.Shared;

namespace Main.管理界面
{
    public partial class 试验报表 : DevExpress.XtraEditors.XtraForm
    {
        string path = string.Empty;
        public 试验报表()
        {
            InitializeComponent();
            this.label1.Text = "显示导出路径...";
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog aa = new FolderBrowserDialog();
            aa.ShowDialog();
            
            path = aa.SelectedPath;
            this.label1.Text = path;

        }

        //性能试验导出报表按钮
        private void button2_Click(object sender, EventArgs e)
        {
            string rptPath = string.Empty;
            if (radioButton1.Checked == true)
            {
                rptPath = AppDomain.CurrentDomain.BaseDirectory + "\\试验报表RPT\\水泵报表(中).rpt";
                this.reportDocument1.Load(rptPath);
                性能试验模型 ds = this.GetRePortModel();
                this.reportDocument1.SetDataSource(ds);
              //  this.reportDocument1.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.RichText, this.path + string.Format("\\性能试验{0}(中).rtf", ds.基础数据表[0].型号规格));
                this.reportDocument1.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, this.path + string.Format("\\性能试验{0}(中).xls", ds.基础数据表[0].型号规格));
            }
            else 
            {
                rptPath = AppDomain.CurrentDomain.BaseDirectory + "\\试验报表RPT\\水泵报表(英).rpt";
                this.reportDocument1.Load(rptPath);
                性能试验模型 ds = this.GetRePortModel();
                this.reportDocument1.SetDataSource(ds);
              //  this.reportDocument1.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.RichText, this.path + string.Format("\\性能试验{0}(英).rtf", ds.基础数据表[0].型号规格));
                this.reportDocument1.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, this.path + string.Format("\\性能试验{0}(英).xls", ds.基础数据表[0].型号规格));
            }
        }

        //汽蚀试验导出报表按钮
        private void button4_Click(object sender, EventArgs e)
        {
            ExcelFormatOptions excelFormat = new ExcelFormatOptions();
            excelFormat.ExcelTabHasColumnHeadings = false;
            excelFormat.ExcelUseConstantColumnWidth = true;
            excelFormat.ExcelConstantColumnWidth = 24.0;
            
            string rptPath = string.Empty;
            if (radioButton1.Checked == true)
            {
                rptPath = AppDomain.CurrentDomain.BaseDirectory + "\\试验报表RPT\\汽蚀报表(中).rpt";
                this.reportDocument1.Load(rptPath);
                汽蚀试验模型 ds = this.GetRePortModel2();
                this.reportDocument1.SetDataSource(ds);
             //   this.reportDocument1.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.RichText, this.path + string.Format("\\汽蚀试验{0}(中).rtf", ds.基础数据表[0].型号规格));
                this.reportDocument1.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, this.path + string.Format("\\汽蚀试验{0}(中).xls", ds.基础数据表[0].型号规格));
            }
            else 
            {
                rptPath = AppDomain.CurrentDomain.BaseDirectory + "\\试验报表RPT\\汽蚀报表(英).rpt";
                this.reportDocument1.Load(rptPath);
                汽蚀试验模型 ds = this.GetRePortModel2();
                this.reportDocument1.SetDataSource(ds);
              //  this.reportDocument1.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.RichText, this.path + string.Format("\\汽蚀试验{0}(英).rtf", ds.基础数据表[0].型号规格));
                this.reportDocument1.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, this.path + string.Format("\\汽蚀试验{0}(英).xls", ds.基础数据表[0].型号规格));
            }
        }
        //性能试验导出报表1按钮
        private void button5_Click(object sender, EventArgs e)
        {
            string rptPath = string.Empty;
            if (radioButton1.Checked == true)
            {
                rptPath = AppDomain.CurrentDomain.BaseDirectory + "\\试验报表RPT\\水泵报表1(中).rpt";
                this.reportDocument1.Load(rptPath);
                性能试验模型 ds = this.GetRePortModel();
                this.reportDocument1.SetDataSource(ds);
              //  this.reportDocument1.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.RichText, this.path + string.Format("\\水泵试验{0}(中).rtf", ds.基础数据表[0].型号规格));
                this.reportDocument1.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, this.path + string.Format("\\水泵试验{0}(中).xls", ds.基础数据表[0].型号规格));
            }
            else
            {
                rptPath = AppDomain.CurrentDomain.BaseDirectory + "\\试验报表RPT\\水泵报表1(英).rpt";
                this.reportDocument1.Load(rptPath);
                性能试验模型 ds = this.GetRePortModel();
                this.reportDocument1.SetDataSource(ds);
              //  this.reportDocument1.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.RichText, this.path + string.Format("\\水泵试验{0}(英).rtf", ds.基础数据表[0].型号规格));
                this.reportDocument1.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, this.path + string.Format("\\水泵试验{0}(英).xls", ds.基础数据表[0].型号规格));
            }
        }

        public string GetTime()
        {
            System.DateTime time = System.DateTime.Now;
            return string.Format("{0}-{1}-{2}-{3}-{4}-{5}", time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second);
        }

        public 性能试验模型 GetRePortModel()
        {
            decimal id = 当前试验组信息.试验ID;
            性能试验模型 ds = new 性能试验模型();
            
            string sql = "select * from 水泵基础信息 where id=" + 当前试验组信息.试验ID;
            数据库操作类.FillDataSet(ds, ds.基础数据表.TableName, sql);
            sql = "select a.流量,a.输入功率,a.转速,a.轴功率,a.进口压力,a.出口压力,a.扬程," + 
            "a.额定转速下_流量 as 额定转速流量,a.额定转速下_扬程 as 额定转速扬程,a.额定转速下_轴功率 as  额定转速轴功率," +
       "a.额定转速下_机组效率 as 额定转速机组效率,a.额定转速下_泵效率 as 额定转速泵效率,a.电压,a.电流,a.功率因素,a.机组效率,'' as 序号" +
       " from dbo.潜水泵性能试验 a where a.groupid=" + 当前试验组信息.试验ID + " order by a.流量";
            数据库操作类.FillDataSet(ds, ds.测试数据表.TableName, sql);
            设置行状态(ds);
            int len = ds.测试数据表.Count;
            for (int i = 0; i < len; i++)
            {
                int order = i + 1;
                ds.测试数据表[i].序号 = order.ToString();
            }
            sql = "select 性能试验 as 性能试验图片信息 from 生成试验组 where ID = " + id;
            数据库操作类.FillDataSet(ds, ds.性能曲线表.TableName, sql);
            if (ds.基础数据表.Count > 0)
            {
                //ds.基础数据表[0].进出口表距 = "0 / " + ds.基础数据表[0].进出口表距;
                ds.基础数据表[0].测试日期 = System.Convert.ToDateTime(ds.基础数据表[0].测试日期).ToShortDateString();
            }
            return ds;
        }

        public 汽蚀试验模型 GetRePortModel2()
        {
            decimal id = 当前试验组信息.试验ID;
            汽蚀试验模型 ds = new 汽蚀试验模型();

            string sql = "select * from 水泵基础信息 where id=" + 当前试验组信息.试验ID;
            数据库操作类.FillDataSet(ds, ds.基础数据表.TableName, sql);
            sql = "select a.流量,a.输入功率,a.转速,a.轴功率,a.进口压力,a.出口压力,a.扬程,a.汽蚀余量," +
            "a.额定转速下_流量 as 额定转速流量,a.额定转速下_扬程 as 额定转速扬程,a.额定转速下_轴功率 as  额定转速轴功率," +
       "a.额定转速下_泵效率 as 额定转速泵效率,a.额定转速下_汽蚀余量 as 额定汽蚀余量,a.电压,a.电流,'' as 序号" +
       " from dbo.汽蚀试验 a where a.groupid=" + 当前试验组信息.试验ID + " order by a.流量";
            数据库操作类.FillDataSet(ds, ds.测试数据表.TableName, sql);
            设置行状态2(ds);
            int len = ds.测试数据表.Count;
            for (int i = 0; i < len; i++)
            {
                int order = i + 1;
                ds.测试数据表[i].序号 = order.ToString();
            }
            sql = "select 汽蚀试验 as 汽蚀试验图片信息 from 生成试验组 where ID = " + id;
            数据库操作类.FillDataSet(ds, ds.性能曲线表.TableName, sql);
            if (ds.基础数据表.Count > 0)
            {
                //ds.基础数据表[0].进出口表距 = "0 / " + ds.基础数据表[0].进出口表距;
                ds.基础数据表[0].测试日期 = System.Convert.ToDateTime(ds.基础数据表[0].测试日期).ToShortDateString();
            }
            return ds;
        }
        public void 设置行状态(性能试验模型 ds)
        {
            int len = ds.测试数据表.Count;
            for (int i = 0; i < len; i++)
            {
                ds.测试数据表[i].行状态 = 获取行状态(i);
                if (i == len - 1)
                {
                    ds.测试数据表[i].行状态 = "结束";
                }
            }
        }


        public void 设置行状态2(汽蚀试验模型 ds)
        {
            int len = ds.测试数据表.Count;
            for (int i = 0; i < len; i++)
            {
                ds.测试数据表[i].行状态 = 获取行状态(i);
                if (i == len - 1)
                {
                    ds.测试数据表[i].行状态 = "结束";
                }
            }
        }

        public string 获取行状态(int index)
        {
            if (index == 0)
            {
                return "开始";
            }
            else if (index > 0 && index < 7)
            {
                return "运行";
            }
            else if (index == 7)
            {
                return "结束";
            }
            else
            {
                int a = (index - 7) % 22;
                if (a == 1) { return "开始"; }
                else if (a == 0) { return "结束"; }
                else
                {
                    return "运行";
                }
            }
        }

        public 温升试验集合 获取温升试验集合()
        {
            decimal id = 当前试验组信息.试验ID;
            温升试验集合 ds = new 温升试验集合();
            string sql = "select 日期值,时间值,流量,扬程,轴功率,电压,电流,温度 as 温度1,温度2,温度3,温度4,温度5,温度6,温度7,温度8 from 温升试验 where groupid=" + 当前试验组信息.试验ID;
            数据库操作类.FillDataSet(ds, ds.温升试验.TableName, sql);
            return ds;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string rptPath = AppDomain.CurrentDomain.BaseDirectory + "\\试验报表RPT\\温升报表.rpt";
            this.reportDocument1.Load(rptPath);
            //this.reportDocument1.
            温升试验集合 ds = this.获取温升试验集合();
               
            this.reportDocument1.SetDataSource(ds);
            this.reportDocument1.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, this.path + string.Format("\\温升试验{0}.xls", GetTime()));
        }
    }
}
