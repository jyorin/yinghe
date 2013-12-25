using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace 数据存储.管理数据类
{
    public class 表模板
    {
        public string 表模板名称
        {
            get;
            set;
        }

        public string 表模板SQL
        {
            get;

            set;
        }

        public List<字段> list = null;

        public 表模板()
        {
            list = new List<字段>();
        }

        private void 填充表模板()
        {
            DataTable tb = DB管理.GetTable(this.表模板SQL);
            int count = tb.Columns.Count;
            foreach (DataRow dr in tb.Rows)
            {
                for (int i = 0; i < count; i++)
                {
                    字段 字段 = new 字段();
                    字段.字段名 = tb.Columns[i].ColumnName;
                    字段.字段值 = Convert.ToString(dr[i]);
                    list.Add(字段);
                }
                break;
            }
        }
        public void 填充表模板(string _表模板名称, string _表模板SQL)
        {
           表模板SQL = _表模板SQL;
           表模板名称 = _表模板名称;
           填充表模板();
        }
        public 字段 获取字段值(string 字段名)
        {
            foreach (字段 _字段 in list)
            {
                if (_字段.字段名.Equals(字段名) == true)
                {
                    return _字段;
                }
            }
            return null;
        }
    }
}
