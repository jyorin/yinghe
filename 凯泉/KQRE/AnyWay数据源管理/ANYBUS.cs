using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace AnyWay数据源管理
{
    public class ANYBUS
    {
        #region 瞬态波形
        [DllImport("MFCNETDLL.dll")]
        public static extern void InitReal(string ip);

        [DllImport("MFCNETDLL.dll")]
        public static extern bool ConnetReal(ref byte chennl);

        [DllImport("MFCNETDLL.dll")]
        public static extern int ReadRealData(ref byte data);

        [DllImport("MFCNETDLL.dll")]
        public static extern void CloseReal();
        #endregion

        #region 稳态数据

        [DllImport("MFCNETDLL.dll")]
        public static extern void DLLDone();

        [DllImport("MFCNETDLL.dll")]
        public static extern int ConnetW(string ip);

        [DllImport("MFCNETDLL.dll")]
        public static extern bool WriteW(byte addr, byte val);

        [DllImport("MFCNETDLL.dll")]
        public static extern bool closeW();

        [DllImport("MFCNETDLL.dll")]
        public static extern bool readW(int id);

        [DllImport("MFCNETDLL.dll")]
        public static extern int readDataW(ref byte data, int len);

        #endregion
    }

}
