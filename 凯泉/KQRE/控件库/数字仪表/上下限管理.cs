using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 控件库.数字仪表
{
    public class 上下限管理
    {
        public static int  上下限计算(float 上限, float 下限, float value)
        {
            if (value > 上限) { return 100; }
            else if (value < 下限) { return 0; }
            else
            {
                return (int)(((value - 下限) / (上限 - 下限)) * 100);
            }
        }
    }
}
