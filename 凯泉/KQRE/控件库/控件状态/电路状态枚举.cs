using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 控件库
{
   public  enum 电路状态枚举
    {
       准备就绪 = 0,
       右闭合= 1,
       右断开= 2,
       左闭合 = 3,
       左断开 = 4,
       双闭合 =5,
       双断开 = 6
    }

   public enum 机器类型
   { 
        异步机 = 0,
        永磁机 = 1,
        直流机 = 2
   }

   public enum 控件写命令方式
   {
       点断,
       脉冲
   }
}
