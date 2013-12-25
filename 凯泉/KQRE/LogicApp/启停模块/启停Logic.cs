using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 数据库操作库;

namespace LogicApp.启停模块
{
    public class 启停Logic
    {
        public static void 删除所有启动记录(decimal groupid)
        {
            string sql = "delete from dbo.启动试验 where groupid = " + groupid;
            数据库操作类.ExcuteSql(sql);
        }

        public static void 删除所有惰转记录(decimal groupid)
        {
            string sql = "delete from dbo.惰转试验 where groupid = " + groupid;
            数据库操作类.ExcuteSql(sql);
        }
    }
}
