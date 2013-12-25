using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gather;
using 数据存储;

namespace LogicApp.采集模块
{
    internal class GatherGroupLogic : IGatherGroup
    {
        private decimal groupid;
        public void LoadGroupInfo(decimal groupid)
        {
            this.groupid = groupid;
            装载值列.加载组信息(groupid);
        }

        public decimal GetGroupId()
        {
            return this.groupid;
        }
    }
}
