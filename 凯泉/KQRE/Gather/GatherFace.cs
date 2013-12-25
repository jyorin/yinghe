using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using 控件库;
using Computer;

namespace Gather
{
    public class GatherFace
    {
        public static void EditTime(string reportName,int 间隔时间)
        {
            GatherReport report = new GatherReport();
            GatherTable tab = report.GetReportTable(reportName);
            tab.修改时间间隔(间隔时间);
        }
    
        // 加载报表信息
        public static void Load(string reportName,IGatherDB db, IGatherItem IItem,int 间隔时间,int 延时时间,IThreadAction _action) 
        {
            GatherInfo info = new GatherInfo();
            info.reportName = reportName;
            GatherDataSet ds = db.GetGatherInfo(reportName);
            info.LoadGatherInfo(ds);
            GatherReport report = new GatherReport();
            report.Load(reportName,db,info, IItem,间隔时间,延时时间,_action);
            GatherTable tab = report.GetReportTable(reportName);
            tab.time.采集事件 += tab.time_采集事件;
            tab.time.采集完成 += tab.time_采集完成;
            tab.time.采集开始 += tab.time_采集开始;
        }
        public static void LoadGrid(控件库.表格控件.Grid _Grid,string tbName)
        {
            GatherReport report = new GatherReport();
            GatherTable tab = report.GetReportTable(tbName);
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit text = null;
            for (int i = 0; i < _Grid.ExportBandView.Columns.Count; i++)
            {
                text = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                
                _Grid.ExportBandView.Columns[i].ColumnEdit = text;
                _Grid.ExportBandView.Columns[i].OptionsColumn.AllowEdit = true;
                tab.计算列准备(_Grid.ExportBandView.Columns[i].FieldName, _Grid, text);
            }
            DataTable tb2 = GetReportTable(tbName);
            _Grid.SetDataSource(tb2);
        }
        public static DataView LoadGrid(控件库.表格控件.Grid _Grid, string tbName, string Fliter,string sort,bool order)
        {
            GatherReport report = new GatherReport();
            GatherTable tab = report.GetReportTable(tbName);
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit text = null;
            for (int i = 0; i < _Grid.ExportBandView.Columns.Count; i++)
            {
                text = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

                _Grid.ExportBandView.Columns[i].ColumnEdit = text;
                _Grid.ExportBandView.Columns[i].OptionsColumn.AllowEdit = true;
                tab.计算列准备(_Grid.ExportBandView.Columns[i].FieldName, _Grid, text);
            }
            DataTable tb2 = GetReportTable(tbName);
            if (order)
                tb2.Columns.Add("序号", typeof(int));
           DataView view = new DataView(tb2, Fliter,sort, DataViewRowState.CurrentRows);
           if (order)
               SetOrder(view);
            _Grid.SetDataSource(view);
            return view;
        }
        public static void SetOrder(DataView view)
        {
            int len = view.Count;
            for (int i = 0; i < len; i++)
            {
                view[i]["序号"] = i + 1;
            }
        }
        public static void GatherComplete(IGatherComplete _complete,string reportName)
        {
            GatherReport report = new GatherReport();
            GatherTable tab = report.GetReportTable(reportName);
            tab.GatherComplete = _complete;
        }
        public static void TableComputer(string tbName,string FiledName,ITableComputer computer)
        {
            GatherReport report = new GatherReport();
            GatherTable tab = report.GetReportTable(tbName);
            tab.加载计算列(FiledName, computer);
            
        }
        public static DataTable GetReportTable(string reportName)
        { 
            GatherReport report = new GatherReport();
            GatherTable tab = report.GetReportTable(reportName);
            return tab.Cache;
        }
        public static void LoginSurfaceGather(string reportName,GatherEvent e) // 注册外部采集
        {
            GatherReport report = new GatherReport();
            GatherTable tab = report.GetReportTable(reportName);
            GatherTimer time = tab.GetGatherTimer();
            time.注册外部采集器(e);
        }
        public static GatherEvent OffSurfaceGather(string reportName) // 注销外部采集
        {
            GatherReport report = new GatherReport();
            GatherTable tab = report.GetReportTable(reportName);
            GatherTimer time = tab.GetGatherTimer();
            return time.注销外部采集器();
        }
        public static void GatherStorePattern(string reportName,DataStoreType type) // 采集存储模式
        {
            GatherReport report = new GatherReport();
            GatherTable tab = report.GetReportTable(reportName);
            tab.采集模式(type);
        }
        public static void StartGather(string reportName)
        {
            GatherReport report = new GatherReport();
            GatherTable tab = report.GetReportTable(reportName);
            tab.time.开启采集();
        }
        public static void EndGather(string reportName) 
        {
            GatherReport report = new GatherReport();
            GatherTable tab = report.GetReportTable(reportName);
            tab.time.关闭采集();      
        }
        public static void HandGather(string reportName)
        {
            GatherReport report = new GatherReport();
            GatherTable tab = report.GetReportTable(reportName);
            tab.AddArrToDB();
        }
        public static void UpdateToDB(string reportName) // 更新表到数据库
        {
            GatherReport report = new GatherReport();
            GatherTable tab = report.GetReportTable(reportName);
            tab.UpdateToDB(reportName);
        }
        public static void RemoveRecord(decimal id, string reportName)
        {
            GatherReport report = new GatherReport();
            GatherTable tab = report.GetReportTable(reportName);
            tab.RemoveRecord(id, reportName);
        }
        public static void AddRowEvent(string reportName, IGatherRow Irow)
        {
            GatherReport report = new GatherReport();
            GatherTable tab = report.GetReportTable(reportName);
            tab.GatherRowEvent = Irow;
        }
    }
}
