using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gather;
using Computer;
using 数据存储;

namespace LogicApp.采集模块
{
    internal class GatherItemLogic : IGatherItem
    {
        public  IComputerItem GetComputerItem(string key)
        {
            IComputerItem data = 数据项哈希存储.GetComputerItem(key);
            return data;
        }

        public  IValue GetIValue(string key)
        {
            return (IValue)数据项哈希存储.GetIValue(key);
        }
    }
}
