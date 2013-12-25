using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using 数据库操作库;
using 全局缓存;

namespace Main.管理界面
{
    public class 保存振动噪声
    {
        DataTable tb = null;
        Control col = null;
        
        public 保存振动噪声() { }
        public void 加载振动噪声(string tbName,Control col)
        {
            string sql = string.Format("select * from {0} where groupid ={1}", tbName, 当前试验组信息.试验ID);
            tb = 数据库操作类.GetTableBySql(sql);
            this.col = col;
        }

        public void 绑定数据()
        {
            if(this.tb.Rows.Count == 0){return;}
            Control[] cols = null;
            string name = string.Empty;
            string value = string.Empty;
            int count = this.tb.Columns.Count;
            DevExpress.XtraEditors.TextEdit edit;
            System.Windows.Forms.ComboBox box;
            for (int i = 0; i < count; i++)
            {
                name = "T_" + this.tb.Columns[i].ColumnName;
                if (name == "T_id" || name == "T_groupid") { continue; }
                value = this.tb.Rows[0][this.tb.Columns[i].ColumnName].ToString();
                cols = col.Controls.Find(name, true);
                if (cols.Length > 0)
                {
                    edit = cols[0] as DevExpress.XtraEditors.TextEdit;
                    box = cols[0] as System.Windows.Forms.ComboBox;
                    if (edit != null)
                        edit.Text = value;
                    else if (box != null)
                    {
                        box.Text = value;
                    }

                }
            }
        }

        public void 保存参数(string tbName) 
        {
            Control[] cols = null;
            string name = string.Empty;
            int count = this.tb.Columns.Count;
            DevExpress.XtraEditors.TextEdit edit;
            System.Windows.Forms.ComboBox box;
            if (this.tb.Rows.Count == 0)
            {
                DataRow row = this.tb.NewRow();
                row["id"] = 数据库操作类.GetSystemID();
                row["groupid"] = 当前试验组信息.试验ID;
                this.tb.Rows.Add(row);
            }
            for (int i = 0; i < count; i++)
            {
                name = "T_" + this.tb.Columns[i].ColumnName;
                if (name == "T_id" || name == "T_groupid") { continue; }
                cols = col.Controls.Find(name, true);
                if (cols.Length > 0)
                {
                    edit = cols[0] as DevExpress.XtraEditors.TextEdit;
                    box = cols[0] as System.Windows.Forms.ComboBox;
                    if(edit != null)
                    this.tb.Rows[0][this.tb.Columns[i].ColumnName] = edit.Text;
                    else if (box != null)
                    {
                        this.tb.Rows[0][this.tb.Columns[i].ColumnName] = box.Text;
                    }
                }
            }
            数据库操作类.Save(this.tb, tbName);
        }
    }
}
