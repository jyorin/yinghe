using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 全局缓存
{

    public enum 读写状态
    { 
        读,
        写,
        可读可写
    }

    public enum 写命令方式
    { 
        脉冲,
        点断
    }
}
