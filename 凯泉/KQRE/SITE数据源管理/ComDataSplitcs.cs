using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace SITE数据源管理
{
    internal class ComDataSplitcs
    {
        public delegate void SplitData(byte[] bytes);
        public event SplitData _SplitData;
        public System.IO.MemoryStream men = null; // 基础缓存
        public bool 是否规则转化 = false;
        Exception ex = new Exception();

        public ComDataSplitcs()
        {
            men = new MemoryStream();

        }

        public void AddBytes(byte[] bytes)
        {
            if (bytes == null) { return; }
            if (bytes.Length == 8)
            {
                if (bytes[0] == 240 && bytes[7] == 254)
                {
                    _SplitData(bytes);
                    return;
                }
            }
            try
            {
                men.Write(bytes, 0, bytes.Length);
                Split();
            }
            catch
            {
                men.SetLength(0);   // 当发生异常时要初始化基础缓存
                this.是否规则转化 = false;
            }
        }

        public void TReturn()
        {
            this.men.SetLength(0);
            this.men.Position = 0;
            System.Threading.Thread.Sleep(300);
            this.是否规则转化 = false;
        }

        public void Split()
        {
            int 当前包索引 = 0;
            int 下一个包索引 = 0;
            int 当前遍历数据长度 = 0;// 包长度相加
            int 流长度 = 0;
            int 当前包长度 = 0;
            byte[] pageLen = new byte[2];
            byte[] 当前包Bits = null;
            int 下一个包长度 = 0;
            byte[] 剩余数据 = null;
            int test = 0;
            if (!是否规则转化)
            {
                规则转化();
            }
            流长度 = (int)men.Length;
            do
            {
                men.Position = 当前包索引;
                test = men.ReadByte();
                if (test != 240) { TReturn(); return; }
                men.Position = 当前包索引 + 1;
                men.Read(pageLen, 0, 2);
                当前包长度 = System.BitConverter.ToInt16(pageLen, 0) + 3;
                当前包Bits = new byte[当前包长度];
                men.Position = 当前包索引;
                men.Read(当前包Bits, 0, 当前包Bits.Length);
                test = 当前包Bits[当前包Bits.Length - 1];
                if (test != 254) { TReturn(); return; }
                try
                {
                    _SplitData(当前包Bits);
                }
                catch
                {

                }
                test = 当前包Bits[当前包Bits.Length - 1];
                //Debug.Assert(test == 254);

                //if (test != 254)
                //{ byte[] data = men.ToArray(); }

                当前遍历数据长度 = 当前遍历数据长度 + 当前包长度;

                if ((流长度 - 当前遍历数据长度) > 3)
                {
                    下一个包索引 = 当前包索引 + 当前包长度;
                    men.Position = 下一个包索引;
                    test = men.ReadByte();
                    //Debug.Assert(test == 240);
                    if (test != 240) { TReturn(); return; }
                    men.Position = 下一个包索引 + 1;
                    men.Read(pageLen, 0, 2);
                    下一个包长度 = System.BitConverter.ToInt16(pageLen, 0) + 3;
                    当前包索引 = 下一个包索引;
                }

            } while ((流长度 - 当前遍历数据长度) > 下一个包长度);
            if ((流长度 - 当前遍历数据长度) > 0)
            {
                剩余数据 = new byte[流长度 - 当前遍历数据长度];

                men.Position = 当前包索引;
                men.Read(剩余数据, 0, 剩余数据.Length);
                if (剩余数据.Length == 8)
                {
                    if (剩余数据[0] == 240 && 剩余数据[7] == 254)
                    {
                        _SplitData(剩余数据);
                        return;
                    }
                }
                test = 剩余数据[0];
                //Debug.Assert(test == 240);
                if (test != 240) { TReturn(); return; }
                men.SetLength(0);
                men.Write(剩余数据, 0, 剩余数据.Length);
            }
        }

        public void 规则转化()
        {
            int byteContent = 0;
            byte[] Lenbytes = new byte[2];
            int len = -1; // 第一个F0的起始字节
            int vlen = 0;// 第一个包的长度
            byte[] 规则Bits = null;
            bool firstPage = false;
            men.Position = 0;
            int test = 0;
            do
            {
                byteContent = (int)men.ReadByte();
                len = len + 1;
                if (byteContent == 240)
                {
                    men.Position = len + 4;
                    byteContent = (int)men.ReadByte();
                    if (byteContent == 83 || byteContent == 84 || byteContent == 85)
                    {
                        men.Position = len + 1;
                        men.Read(Lenbytes, 0, 2);
                        vlen = System.BitConverter.ToInt16(Lenbytes, 0);
                        men.Position = len + 2 + vlen;
                        byteContent = (int)men.ReadByte();
                        if (byteContent == 254)
                        {
                            firstPage = true;
                        }
                    }
                }
            } while (!firstPage);
            if (firstPage)
            {
                规则Bits = new byte[men.Length - len];
                men.Position = len;
                men.Read(规则Bits, 0, 规则Bits.Length);
                test = 规则Bits[0];
                if (test != 240) { TReturn(); return; }
                men.SetLength(0);
                men.Write(规则Bits, 0, 规则Bits.Length);
                是否规则转化 = true;
            }
        }
    }
}
