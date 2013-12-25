using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AutoControl
{
    public class comboBoxField : FieldElement
    {
        public override BindData GetBindData()
        {
            comBoxBD data = new comBoxBD();
            data.Value = this.FieldValue;
            data.comboxList = Getlist();
            return data;
        }

        public List<string> Getlist()
        {
            string sql = "select NAME from ComboBoxSet where FieldId = '" + this.ControlID + "'";
            DataTable tb = DBControl.GetTable(sql);
            List<string> list = new List<string>();
            int count = tb.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                list.Add(tb.Rows[i]["NAME"].ToString());
            }
            return list;
        }
    }
}
