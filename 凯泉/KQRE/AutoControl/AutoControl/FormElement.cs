using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace AutoControl
{
    public class FormElement
    {
        private List<TableElement> tabs = new List<TableElement>();
        private List<ControlElement> controls = new List<ControlElement>();
        public void LoadTabs(string[] tbNames,decimal[] ids) 
        {
            TableElement tb = null;
            int count = tbNames.Length;
            for (int i = 0; i < count; i++)
            {
                tb = GetTableElement(tbNames[i]);
                if (tb == null)
                {
                    tb = new TableElement(tbNames[i]);
                    tb.Load(ids[i]);
                    this.tabs.Add(tb);
                }
                else
                {
                    tb.Load(ids[i]);
                }
            }
        }
        public ControlElement GetControlElementByInfo(string tbName, string fieldName) 
        {
            int conLen = this.controls.Count;
            for (int i = 0; i < conLen; i++)
            {
                if (this.controls[i].Field.FieldName == fieldName && this.controls[i].Field.FieldTable == tbName)
                {
                    return this.controls[i];
                }
            }
            int len = tabs.Count;
            FieldElement field = null;
            for (int i = 0; i < len; i++)
            {
                if (tabs[i].tableName == tbName)
                {
                    field = tabs[i].GetFieldElement(fieldName);
                }
            }
            if (field != null)
            {
                if (field._Type == ControlType.Text)
                {
                    charText _charText = new charText(field);
                    return _charText;
                }
                else if (field._Type == ControlType.ComboBox)
                {
                    comboBox _box = new comboBox(field);
                    return _box;
                }
                else if (field._Type == ControlType.TimeBox)
                {
                    timeBox _timebox = new timeBox(field);
                    return _timebox;
                }
                else if (field._Type == ControlType.NumericEdit)
                {
                    NumericEdit _NumericEdit = new NumericEdit(field);
                    return _NumericEdit;
                }
            }
            return null;
        }
        public void ClearFormTable(string tbName)
        {
            ControlElement con = null;
            TableElement _tab = this.GetTableElement(tbName);
            _tab.SetId(-1);
            List<FieldElement> fields = _tab.fields;
            int count = fields.Count;
            for (int i = 0; i < count; i++)
            {
                con = this.GetControlElementByInfo(tbName, fields[i].FieldName);
                con.ClearRecord();
            }
        }
        public void AddControlByLayout(System.Windows.Forms.Panel _panel, string tbName, string fieldName) 
        {
            ControlElement _control = GetControlElementByInfo(tbName, fieldName);
            if (_control != null)
            {
                _control.AddControlByLayout(_panel);
                this.controls.Add(_control);
            }

        }
        public void BindControlAgin(string tbName)
        {
            ControlElement con = null;
            TableElement _tab = this.GetTableElement(tbName);
            List<FieldElement> fields = _tab.fields;
            int count = fields.Count;
            for (int i = 0; i < count; i++)
            {
                con = this.GetControlElementByInfo(tbName, fields[i].FieldName);
                con.BindTheControl(fields[i].GetBindData());
            }
        }
        public decimal[] SaveTabs(string[] tbNames) 
        {
            int len = tbNames.Length;
            decimal[] ids = new decimal[len];
            TableElement table = null; ;
            for (int i = 0; i < len;i++ )
            {
                table = GetTableElement(tbNames[i]);
                ids[i] = table.SaveRecord();
            }
            return ids;
        }
        public decimal SaveTabs(string tbNames,string[] strFiled,string[] strValues)
        {
            int len = tbNames.Length;
            decimal ids;
            TableElement table = null;

            table = GetTableElement(tbNames);
            ids = table.SaveRecord(strFiled,strValues);
            return ids;
        }
        //添加
        public void deleteTabs(string[] tbNames)
        {
            int len = tbNames.Length;
            decimal[] ids = new decimal[len];
            TableElement table = null; ;
            for (int i = 0; i < len; i++)
            {
                table = GetTableElement(tbNames[i]);
                table.DeletRecord();
            }
        }

         public void  SetId(string tbNames,decimal id)
        {
            int len = tbNames.Length;
            decimal[] ids = new decimal[len];
            TableElement table = null;
             table = GetTableElement(tbNames);
             table.SetId(id);
        }


        public DataTable SelectTabs(string tbNames)
        {
            DataTable dt = null;
            int len = tbNames.Length;
            decimal[] ids = new decimal[len];
            TableElement table = null; ;
            table = GetTableElement(tbNames);
            dt=table.SelectRecord();
            return dt;
        }

        public DataTable SelectTabsBySql(string sql)
        {
           return DBControl.GetTable(sql);
        }
        public void ExcuteSql(string sql)
        {
            DBControl. ExcuteSql(sql);
        }

        public void ExcuteSqlInputParam(string sql, OleDbParameter[] param, int len)
        {
            DBControl.ExcuteSqlInputParam(sql, param, len);
        }


        private TableElement GetTableElement(string tbName)
        {
            int count = this.tabs.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.tabs[i].tableName == tbName)
                {
                    return this.tabs[i];
                }
            }
            return null;
        }
    }
}
