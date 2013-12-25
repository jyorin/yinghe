using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoControl
{
    internal class charField : FieldElement
    {
        public charField()
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
