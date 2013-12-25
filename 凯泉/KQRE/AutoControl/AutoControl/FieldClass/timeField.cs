using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoControl
{
    internal class timeField : FieldElement
    {
        public timeField()
        {
        }
        public override BindData GetBindData()
        {
            BindData data = new BindData();
            data.Value = this.FieldValue;
            return data;
        }
    }
}
