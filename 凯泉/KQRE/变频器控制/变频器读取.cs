using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 变频器控制
{
    public class 变频器读取
    {
        private CRC16 crc = null;
        private byte 设备地址;
        private byte 功能码;
        private byte 数据地址高位;
        private byte 数据地址低位;
        private byte 数据长度高位;
        private byte 数据长度低位;
        private byte CRC高位;
        private byte CRC低位;

        public 变频器读取(byte 设备地址, ushort 数据地址, ushort 数据长度)
        {
            crc = new CRC16();
            this.设备地址 = 设备地址;
            this.功能码 = 3; // 读取保持寄存器
            this.数据地址低位 = System.BitConverter.GetBytes(数据地址)[0];
            this.数据地址高位 = System.BitConverter.GetBytes(数据地址)[1];
            this.数据长度低位 = System.BitConverter.GetBytes(数据长度)[0];
            this.数据长度高位 = System.BitConverter.GetBytes(数据长度)[1];
            byte[] data = { this.设备地址, this.功能码, this.数据地址高位,this.数据地址低位 ,this.数据长度高位,this.数据长度低位 };
            ushort _data = crc.CalculateCrc16(data);
            this.CRC高位 = System.BitConverter.GetBytes(_data)[1];
            this.CRC低位 = System.BitConverter.GetBytes(_data)[0]; 
        }

        public byte[] 报文数据()
        {
            return new byte[] { this.设备地址, this.功能码, this.数据地址高位, this.数据地址低位, this.数据长度高位 ,this.数据长度低位,this.CRC高位,this.CRC低位 };
        }
    }
}
