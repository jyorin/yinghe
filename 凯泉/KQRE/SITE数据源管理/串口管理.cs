using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SITE数据源管理
{
    public class 串口管理
    {
        串口读数 _串口读数 = null;

        public 串口管理()
        {
            _串口读数 = new 串口读数();
        }
        public void 串口读数(string com)
        {
            _串口读数.Open(com);
        }
    }
}
