using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLC数据源管理
{
    public class PLC类构造
    {
        public static PLC数据集 获取PLC数据集()
        {
            PLC数据集 _PLC = new PLC数据集();
            _PLC.加载PLC数据项();
            return _PLC;
        }
    }
}
