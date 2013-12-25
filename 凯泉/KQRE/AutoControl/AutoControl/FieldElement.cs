using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoControl
{
    public abstract class FieldElement
    {
        GetControlValue _getValue;
        public string FieldTable { get; set; }
        public string FieldName { get; set; }
        public ControlType _Type;
        public string ID { get; set; }
        public string ControlID { get; set; }
        public string Title { get; set; }
        public string FieldValue { get; set; } // 数据库值
        public FieldElement()
        {
        }
        public void BindGetValue(GetControlValue _getValue)
        {
            this._getValue = _getValue;
        }
        public abstract BindData GetBindData();
        public string _GetControlValue()
        {
            if (this._getValue == null) { return string.Empty; }
            return this._getValue();
        }
    }
}
