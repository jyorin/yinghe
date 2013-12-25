using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AutoControl
{
    internal class TableElement
    {
        private decimal id;
        public string tableName;
        public  List<FieldElement> fields = new List<FieldElement>();

        public TableElement(string tableName)
        {
            this.tableName = tableName;
            this.BuildFiels();
        }

        public void SetId(decimal id)
        {
            this.id = id;
        }

        private ControlFieldSet GetTestData()
        {
            ControlFieldSet ds = new ControlFieldSet();
            string sql = "select * from ControlFieldSet where TableName = '" + this.tableName + "'";
            DBControl.FillDataSet(ds,"ControlFieldSet",sql);
            return ds;
        }

        private void BuildFiels()
        {
            ControlFieldSet ds = GetTestData();
            int count = ds._ControlFieldSet.Count;
            for (int i = 0; i < count; i++)
            {
                if (ds._ControlFieldSet[i].ControlType.Trim() == "1") // Text
                {
                    charField field = new charField();
                    field._Type = ControlType.Text;
                    field.ControlID = ds._ControlFieldSet[i].ID.Trim();
                    field.FieldName = ds._ControlFieldSet[i].FieldName.Trim();
                    field.FieldTable = ds._ControlFieldSet[i].TableName.Trim();
                    this.fields.Add(field);
                }
                else if (ds._ControlFieldSet[i].ControlType.Trim() == "2") // Text
                {
                    comboBoxField field = new comboBoxField();
                    field._Type = ControlType.ComboBox;
                    field.ControlID = ds._ControlFieldSet[i].ID.Trim();
                    field.FieldName = ds._ControlFieldSet[i].FieldName.Trim();
                    field.FieldTable = ds._ControlFieldSet[i].TableName.Trim();
                    this.fields.Add(field);
                }
                else if (ds._ControlFieldSet[i].ControlType.Trim() == "3") // 时间控件
                {
                    timeField field = new timeField();
                    field._Type = ControlType.TimeBox;
                    field.ControlID = ds._ControlFieldSet[i].ID.Trim();
                    field.FieldName = ds._ControlFieldSet[i].FieldName.Trim();
                    field.FieldTable = ds._ControlFieldSet[i].TableName.Trim();
                    this.fields.Add(field);
                }
                else if (ds._ControlFieldSet[i].ControlType.Trim() == "4") // 数字控件
                {
                    NumericField field = new NumericField();
                    field._Type = ControlType.NumericEdit;
                    field.ControlID = ds._ControlFieldSet[i].ID.Trim();
                    field.FieldName = ds._ControlFieldSet[i].FieldName.Trim();
                    field.FieldTable = ds._ControlFieldSet[i].TableName.Trim();
                    this.fields.Add(field);
                }
            }
        }

        public void Load(decimal id)
        {
            this.id = id;
            string sql = "select * from " + this.tableName + " where id = " + id;
            DataTable tb = DBControl.GetTable(sql);
            if (tb.Rows.Count == 0) { return; }
            int len = this.fields.Count;
            for (int i = 0; i < len; i++)
            {
                this.fields[i].FieldValue = tb.Rows[0][this.fields[i].FieldName].ToString();
            }
        }

        public decimal SaveRecord()
        {
            string sql = string.Empty;
            int len = 0;
            if (this.id < 0)
            {
                this.id =  DBControl.GetSystemID(1)[0];
                // 新增
                len = this.fields.Count;
                sql = sql + "insert into " + this.tableName + "(id,";
                for (int i = 0; i < len; i++)
                {
                    if (i != len - 1)
                    {
                        sql = sql + this.fields[i].FieldName + ",";
                    }
                    else
                    {
                        sql = sql + this.fields[i].FieldName + ") values (" + this.id + ",";
                    }
                }
                for (int i = 0; i < len; i++)
                {
                    if (i != len - 1)
                    {
                        sql = sql + "'" + this.fields[i]._GetControlValue() + "',";
                    }
                    else
                    {
                        sql = sql + "'" + this.fields[i]._GetControlValue() + "')";
                    }
                }
            }
            else
            {
                // 修改
                len = this.fields.Count;
                sql = sql + "update " + this.tableName + " set ";
                for (int i = 0; i < len; i++)
                {
                    if (i != len - 1)
                    {
                        sql = sql + this.fields[i].FieldName + "='" + this.fields[i]._GetControlValue() + "',";
                    }
                    else       
                    {
                        sql = sql + this.fields[i].FieldName + "='" + this.fields[i]._GetControlValue() + "'";
                    }
                }
                sql = sql + " where id = " + this.id;
            }
            DBControl.ExcuteSql(sql);
            return this.id;
        }

        public decimal SaveRecord(string[] strFiled,string[] strValues)
        {
            string sql = string.Empty;
            int len = 0;
            if (this.id < 0)
            {
                this.id = DBControl.GetSystemID(1)[0];
                // 新增
                len = this.fields.Count;
                sql = sql + "insert into " + this.tableName + "(id,";
                for (int i = 0; i < len; i++)
                {
                    if (i != len - 1)
                    {
                        sql = sql + strFiled[i] + ",";
                    }
                    else
                    {
                        sql = sql + strFiled[i] + ") values (" + this.id + ",";
                    }
                }
                for (int i = 0; i < strValues.Length; i++)
                {
                    if (i != strValues.Length-1)
                    {
                        sql = sql + "'" + strValues[i] + "',";
                    }
                    else
                    {
                        sql = sql + "'" + strValues[i]+ "')";
                    }
                }
            }
            else
            {
                // 修改
             // len = this.fields.Count;
                sql = sql + "update " + this.tableName + " set ";
                for (int i = 0; i < strValues.Length; i++)
                {
                    if (i != strValues.Length-1)
                    {
                        sql = sql + strFiled[i] + "='" + strValues[i] + "',";
                    }
                    else
                    {
                        sql = sql + strFiled[i] + "='" + strValues[i] + "'";
                    }
                }
                sql = sql + " where id = " + this.id;
            }
            DBControl.ExcuteSql(sql);
            return this.id;
        }

        //添加
        public void DeletRecord()
        {
            string sql = string.Empty;
            int len = 0;

            // 新增
            len = this.fields.Count;
            sql = sql + "delete from " + this.tableName + " where id="+ this.id;
            DBControl.ExcuteSql(sql);
            SetId(-1);
        }
        public DataTable SelectRecord()
        {
            DataTable DataTb = null;
            string sql = string.Empty;
            int len = 0;

            // 新增
            len = this.fields.Count / 2;
            sql = sql + "select *  from " + this.tableName;
            DataTb = DBControl.GetTable(sql);
            return DataTb;
        }

        public  FieldElement GetFieldElement(string fieldName)
        {
            int count = this.fields.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.fields[i].FieldName == fieldName)
                {
                    return this.fields[i];
                }
            }
            return null;
        }
    }
}
