using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 全局缓存.PLC数据源配置结构管理
{
    public class 水泵试验节点下属线路集合
    {
        public 水泵试验节点下属线路集合()
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
