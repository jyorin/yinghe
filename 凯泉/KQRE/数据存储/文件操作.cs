using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace 数据存储
{
    public class 文件操作
    {
        StreamReader 文件 = null;
        public string PATH
        {
            get;
            set;
        }
        public void 加载文件()
        {
            文件 = new StreamReader(PATH,Encoding.Default);
        }
        public string 读数据()
        {
            if (文件.Peek() > 0)
                return 文件.ReadLine();
            else
            {
                文件.Close() ;
                return null;
            }
        }
    }
}
