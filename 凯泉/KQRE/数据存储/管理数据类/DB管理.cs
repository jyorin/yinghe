using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using 数据库操作库;

namespace 数据存储.管理数据类
{
    public class DB管理
    {
        public static DataTable GetTable(string sql)
        {
            return 数据库操作类.GetTableBySql(sql);
        }
    }
}