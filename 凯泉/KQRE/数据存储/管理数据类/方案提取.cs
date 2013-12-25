using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 数据库操作库;
using System.Data;

namespace 数据存储.管理数据类
{
    public class 方案提取
    {
        public static 方案 提取方案(decimal 方案ID)
        {
            方案 方案 = new 方案();
            if (方案.方案加载(方案ID) == false)
            {
                return null;
            }
            return 方案;
        }
    }
}
