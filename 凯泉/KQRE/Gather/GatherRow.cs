using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Computer;

namespace Gather
{
    public class GatherRow
    {
        // 整合Item
        public List<GatherItem> List = null;

        public GatherRow() { this.List = new List<GatherItem>(); }

        public void AddItem(GatherItem item)
        {
            this.List.Add(item);
        }

        public object[] GetFloats() 
        {
            int count = this.List.Count;
            object[] d = new object[count];
            for (int i = 0; i < count; i++)
            {
                if(this.List[i].field._SourceType != 数据来源类型.未知)
                d[i] = this.List[i].GetValue();
                else
                d[i] = this.List[i].GetObjValue();
            }
            return d;
        }

        public GatherItem GetIValue(string key)
        {
            int count = this.List.Count;
            for (int i = 0; i < count; i++)
            {
                if (this.List[i].field.FieldName == key)
                {
                    return (GatherItem)this.List[i]._VALUE;
                }
            }
            return null;
        }
    }
}
