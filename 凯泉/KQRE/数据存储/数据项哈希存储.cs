using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Computer;

namespace 数据存储
{
    public class 数据项哈希存储
    {
        public static Hashtable 数据项哈希集 = new Hashtable();

        public static 数据项 GetItem(string key)
        {
            return 数据项哈希集[key] as 数据项;
        }

        public static IComputerItem GetComputerItem(string key)
        {
            return 数据项哈希集[key] as IComputerItem;
        }

        public static IValue GetIValue(string key)
        {
            return 数据项哈希集[key] as IValue;
        }

        public static void AddItem(string key, object item)
        {
            数据项哈希集.Add(key, item);
        }

        public static void AddData(string ip, int id, float d,int t)
        {
            string key = 数据来源编码规则.GetAnyWay(ip, id.ToString());
            数据项 _数据项 = GetItem(key);
            _数据项.AddData(d, t);   
        }
    }
}
