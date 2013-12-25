using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 数据库操作库;
using Gather;
using System.Data;
using AutoControl;

namespace LogicApp.采集模块
{
    internal class GatherDBLogic : IGatherDB
    {
        string reportName = string.Empty;
        IGatherGroup group = null;
        public GatherDBLogic(string reportName, IGatherGroup group)
        {
            this.reportName = reportName;
            this.group = group;
        }
        public GatherDataSet GetGatherInfo(string reportName)
        {
            GatherDataSet ds = new GatherDataSet();
            string sql = "";
            if (this.reportName == "汽蚀试验" || this.reportName == "潜水泵性能试验")
            {
                sql = "select * from GatherTB where reportName='" + reportName + "' order by id";    
            }
            else
            {
                sql = "select * from GatherTB where reportName='" + reportName + "'";
            }
            
            数据库操作类.FillDataSet(ds, ds.GatherTB.TableName, sql);
            return ds;
        }

        public DataTable GetDataTable()
        {
          
            string sql = string.Format("select * from {0} where groupid={1}",this.reportName,this.group.GetGroupId());
            return 数据库操作类.GetTableBySql(sql);
        }

   
        public decimal[] GetSystemID(int count)
        {
            return 数据库操作类.GetSystemID(count);
        }

        public void InsertSql(string sql)
        {
            数据库操作类.ExcuteSql(sql);
        }

        public void SaveDB(DataTable tb, string reportName)
        {
            数据库操作类.Save(tb, reportName);
        }

        public void DeleteRecord(decimal id,string reportName)
        {
            string sql = string.Format("delete from {0} where id = {1}",reportName,id);
            数据库操作类.ExcuteSql(sql);
        }
    }
}
