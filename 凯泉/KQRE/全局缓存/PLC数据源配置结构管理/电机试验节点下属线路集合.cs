using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 全局缓存.数据源配置结构管理
{
    public class 电机试验节点下属线路集合
    {
        public 电机试验节点下属线路集合()
        { 
        
        }

        public string 节点标识
        {
            get;
            set;
        }

        public List<string> 节点下属线路标识集合
        {
            get;
            set;
        }

        public List<object> 节点下属线路引用集合
        {
            get;
            set;
        }
    }
}
