using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Gather
{
    public class GatherInfo
    {
        public string reportName;
        public List<GatherField> list = null;
        public GatherInfo()
        {
            list = new List<GatherField>();
        }

        public GatherField GetFiled(string name)
        {
            int count = this.list.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.list[i].FieldName == name)
                {
                    return this.list[i];
                }
            }
            return null;
        }

        public void LoadGatherInfo(GatherDataSet ds)
        {
            GatherField field = null;
            int count = ds.GatherTB.Count;
            for (int i = 0; i < count; i++)
            {
                field = new GatherField();
                field.DataNo = ds.GatherTB[i].computerNo.Trim();
                field.FieldName = ds.GatherTB[i].fieldName.Trim();
                field._Type = (FieldDataType)ds.GatherTB[i].fieldDataType;
                field._SourceType = (数据来源类型)ds.GatherTB[i].fieldSourceType;
                this.list.Add(field);
            }
        }

        public void  FillDataTable(DataTable tb)
        {
            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                tb.Columns.Add(list[i].FieldName, typeof(decimal));
            }
           
        }

        public string GetColoums()
        {
            string str = "(";
            int count = this.list.Count;
            for(int i = 0;i < count;i++)
            {
                if(i == count - 1)
                str = str + this.list[i].FieldName;
                else
                str = str + this.list[i].FieldName + ",";
            }
            return str + ")";
        }

        public string GetValues(decimal id,object[] d)
        {
            string str = "(";
            int count = d.Length;
            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                {
                    if (d[i].GetType() == typeof(System.Single))
                        str = str + d[i];
                    else
                        str = str + "'" + d[i] + "'";
                }
                else
                {
                    if(d[i].GetType() == typeof(System.Single))
                    str = str + d[i] + ",";
                    else
                    str = str + "'" + d[i] + "',";
                }
            }
            return str + ")";
        }

        public string GetSql(List<object[]> list,IGatherDB db)
        {
           string sql = string.Empty;
           int len = list.Count;
           decimal[] ids = db.GetSystemID(len);
           for (int i = 0; i < len; i++)
           {
               sql = sql + string.Format("insert into {0}", this.reportName) + GetColoums() + " values " + GetValues(ids[i],list[i]) + ";";
           }
           return sql;   
        }

        public string GetSql(object[] d,IGatherDB db)
        {

            decimal[] ids = db.GetSystemID(1);
            string sql = string.Empty;
            sql = sql + string.Format("insert into {0}", this.reportName) + GetColoums() + " values " + GetValues(ids[0],d) + ";";
            return sql;
        }
    }

    public class GatherField
    {
        public string DataNo;// 来自PLC.ANYWAY.子站数据
        public string FieldName;
        public FieldDataType _Type;
        public 数据来源类型 _SourceType;
    }

    public enum FieldDataType
    {
        _String = 1,
        _Float = 2
    }

    public enum 数据来源类型
    {
        AnyWay = 1,
        PLC = 2,
        SITE = 3,
        未知 = 4
    }
}
