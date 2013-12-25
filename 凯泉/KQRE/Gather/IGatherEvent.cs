using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gather
{
    public class GatherEvent
    {
        public delegate void 外部采集事件委托();
        public event 外部采集事件委托 外部采集事件;

        public void 外部采集处理函数()
        {
            if (外部采集事件 != null)
            this.外部采集事件();
        }
    }
}
