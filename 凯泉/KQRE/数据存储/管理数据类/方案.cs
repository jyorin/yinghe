using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using 数据库操作库;
using 辅助库;

namespace 数据存储.管理数据类
{
    public class 方案
    {
        public string 试验编号 = "";
        public double 水温 = 0;
        public int 被试水泵ID = 0;
        public int 拖动电机ID = 0;
        public int 流量仪表ID = 0;
        public int 转速测量ID = 0;
        public int 进口压力仪表ID = 0;
        public int 出口压力仪表ID = 0;
        public int 功率测量仪表ID = 0;
        public int 温度测量仪表ID = 0;
        public int 液力耦合器ID = 0;
        private List<表模板> list = null;
        private void 添加表模板(string 表名, int  ID)
        {
            string strsql = "select * from " + 表名 + " where ID=" + ID;
            表模板 表模板 = new 表模板();
            表模板.填充表模板(表名, strsql);
            list.Add(表模板);
        }

        public 方案()
        {
            list = new List<表模板>();
        }

        public bool 方案加载(decimal 方案ID)
        {
            list.Clear();
            string strsql = "select * from dbo.生成试验组 where ID=" + 方案ID;
            DataTable tb = 数据库操作类.GetTableBySql(strsql);

            if (tb.Rows.Count == 0)
            {
                return false;
            }

            foreach (DataRow dr in tb.Rows)
            {
                水温 = Convert.ToDouble(dr["水温"]);
                试验编号 = Convert.ToString(dr["试验编号"]);
                被试水泵ID = Convert.ToInt32(dr["被试水泵ID"]);
                拖动电机ID = Convert.ToInt32(dr["拖动电机ID"]);
                流量仪表ID = Convert.ToInt32(dr["流量仪表ID"]);
                转速测量ID = Convert.ToInt32(dr["转速测量ID"]);
                进口压力仪表ID = Convert.ToInt32(dr["进口压力仪表ID"]);
                出口压力仪表ID = Convert.ToInt32(dr["出口压力仪表ID"]);
                功率测量仪表ID = Convert.ToInt32(dr["功率测量仪表ID"]);
                温度测量仪表ID = Convert.ToInt32(dr["温度测量仪表ID"]);
                液力耦合器ID = Convert.ToInt32(dr["液力耦合器ID"]);
                break;
            }

            添加表模板("dbo.水泵型号管理", 被试水泵ID);
            添加表模板("dbo.电机型号管理", 拖动电机ID);
            添加表模板("dbo.流量仪表", 流量仪表ID);
            添加表模板("dbo.转速测量", 转速测量ID);
            添加表模板("dbo.进口压力仪表", 进口压力仪表ID);
            添加表模板("dbo.出口压力仪表", 出口压力仪表ID);
            添加表模板("dbo.功率测量仪表", 功率测量仪表ID);
            添加表模板("dbo.温度测量仪表", 温度测量仪表ID);
            添加表模板("dbo.液力耦合器", 液力耦合器ID);
            

            return true;
        }

        public 字段 提取字段(string 表模板名称, string 字段名称)
        {
            字段 _字段 = new 字段();
            foreach (表模板 表 in list)
            {
                if (表.表模板名称.Equals(表模板名称) == true)
                {
                    _字段 = 表.获取字段值(字段名称);
                    if (_字段 != null)
                    {
                        return _字段;
                    }
                }
            }

            return null;
        }

    }
}
