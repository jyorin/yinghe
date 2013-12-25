using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gather;
using System.Data;
using 数据存储;
using AnyWay数据源管理;

namespace LogicApp.采集模块
{
    public class GatherLogic
    {
        DataView view = null;


        public void EditTime(string reportName, int 间隔时间)
        {
             GatherFace.EditTime(reportName,间隔时间);
        }
        // 加载报表信息
        public void Load(string reportName,IThreadAction _action,decimal groupid,int 间隔时间,int 延时时间)
        {
          
            GatherGroupLogic _group = new GatherGroupLogic();
            _group.LoadGroupInfo(groupid);
            GatherDBLogic db = new GatherDBLogic(reportName, _group);
            GatherItemLogic IItem = new GatherItemLogic();
            GatherFace.Load(reportName,db, IItem,间隔时间,延时时间,_action);
        }
        public void LoadGrid(控件库.表格控件.Grid _Grid, string tbName)
        {
            GatherFace.LoadGrid(_Grid, tbName);
        }
        bool isOrder = false;
        public void LoadGrid(控件库.表格控件.Grid _Grid, string tbName, string Fliter,string sort,bool order) // Fliter过滤条件,sort是排序,order是否要加入自动序号
        {
            this.isOrder = order;
            view = GatherFace.LoadGrid(_Grid, tbName, Fliter,sort,order);
        }
        public void GatherComplete(IGatherComplete _complete, string reportName)
        {
            GatherFace.GatherComplete(_complete, reportName);
        }
        public void TableComputer(string tbName, string FiledName, ITableComputer computer)
        {
            GatherFace.TableComputer(tbName, FiledName, computer);
        }
        public DataTable GetReportTable(string reportName)
        {
            return GatherFace.GetReportTable(reportName);
        }
        public void LoginSurfaceGather(string reportName,string WP4000IP) // 注册外部采集
        {
            功率分析仪 _功率分析仪 = AnyWay类构造.获取功率分析仪(WP4000IP);
            GatherEvent e = new GatherEvent();
            _功率分析仪.解析完毕 += new 功率分析仪.解析完毕通知(e.外部采集处理函数);
            GatherFace.LoginSurfaceGather(reportName,e);
        }
        public void OffSurfaceGather(string reportName,string WP4000IP) // 注销外部采集
        {
            GatherEvent e = GatherFace.OffSurfaceGather(reportName);
            功率分析仪 _功率分析仪 = AnyWay类构造.获取功率分析仪(WP4000IP);
            _功率分析仪.解析完毕 -= e.外部采集处理函数;
           
        }
        public void GatherStorePattern(string reportName,DataStoreType type) // 采集存储模式
        {
            GatherFace.GatherStorePattern(reportName,type);
        }
        public  void StartGather(string reportName)
        {
            GatherFace.StartGather(reportName);
        }
        public void EndGather(string reportName)
        {
            GatherFace.EndGather(reportName);
        }
        public  void HandGather(string reportName)
        {
            GatherFace.HandGather(reportName);
            if(this.isOrder)
            GatherFace.SetOrder(this.view);
        }
        public void UpdateToDB(string reportName) // 更新表到数据库
        {
            GatherFace.UpdateToDB(reportName);
        }
        public  void RemoveRecord(decimal id, string reportName)
        {
            GatherFace.RemoveRecord(id, reportName);
            if(this.isOrder)
            GatherFace.SetOrder(this.view);
        }

        public void AddRowEvent(string reportName, IGatherRow Irow)
        {
            GatherFace.AddRowEvent(reportName, Irow);
        }
    }
}
