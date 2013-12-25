using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Gather
{
    public interface IGatherDB
    {
        GatherDataSet GetGatherInfo(string reportName);
        DataTable GetDataTable(); // 获取所有数据
        void InsertSql(string sql);
        decimal[] GetSystemID(int count);
        void SaveDB(DataTable tb, string reportName);
        void DeleteRecord(decimal id,string reportName);
    }
}
