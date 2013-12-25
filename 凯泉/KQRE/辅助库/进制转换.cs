using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 辅助库
{
    public static class 进制转换
    {
        public static UInt16 GetWData(int num)
        {
            byte[] bytes = System.BitConverter.GetBytes(num);
            byte[] _bytes = new byte[] { bytes[1], bytes[0] };
            return System.BitConverter.ToUInt16(_bytes, 0);
        }

        public static float f_保留N位小数(float num,int digits)
        {
           return  (float)Math.Round(num, digits);
        }
    }
}
