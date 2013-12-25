using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 变频器控制
{
    public class 变频器报文
    {
        private byte 设备地址;
        private byte 功能码;
        private byte 数据地址高位;
        private byte 数据地址低位;
        private byte 数据高位;
        private byte 数据低位;
        private byte CRC高位;
        private byte CRC低位;
        private CRC16 crc = null;

        public 变频器报文(byte 设备地址, ushort 数据地址, ushort 数据)
        {
            crc = new CRC16();
            this.设备地址 = 设备地址;
            this.功能码 = 6;
            this.数据地址低位 = System.BitConverter.GetBytes(数据地址)[0];
            this.数据地址高位 = System.BitConverter.GetBytes(数据地址)[1];
            this.数据低位 = System.BitConverter.GetBytes(数据)[0];
            this.数据高位 = System.BitConverter.GetBytes(数据)[1];
            byte[] data = { this.设备地址, this.功能码, this.数据地址高位, this.数据地址低位, this.数据高位,this.数据低位 };
            ushort _data = crc.CalculateCrc16(data);
            this.CRC高位 = System.BitConverter.GetBytes(_data)[1];
            this.CRC低位 = System.BitConverter.GetBytes(_data)[0]; 
        }

        public byte[] 报文数据()
        {
            return new byte[] { this.设备地址, this.功能码, this.数据地址高位, this.数据地址低位, this.数据高位 ,this.数据低位,this.CRC高位,this.CRC低位 };
        }
    }
}
