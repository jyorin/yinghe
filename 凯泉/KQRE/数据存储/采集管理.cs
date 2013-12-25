using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace 数据存储
{
    public class 采集管理
    {
        string 实时采集Path = "";
        string 间隔采集Path = "";
        FileStream 实时流 = null;
        FileStream 间隔流 = null;

        public 采集管理() { }

        public void 生成实时采集()
        {
            实时流 = new FileStream(获取实时采集路径(), FileMode.OpenOrCreate);
        }

        public void 关闭实时采集()
        {
            实时流.Close();
        }

        public void 生成间隔采集()
        {
            间隔流 = new FileStream(this.间隔采集Path, FileMode.OpenOrCreate);
        }

        public void 关闭间隔采集()
        {
            间隔流.Close();
        }

        private string GetStr(string value)
        {
            return value.PadLeft(2).Replace(" ", "0");
        }

        private string 获取时间路径()
        {
            DateTime time = System.DateTime.Now;
            return time.Year.ToString() + GetStr(time.Month.ToString()) +  GetStr(time.Day.ToString()) + GetStr(time.Hour.ToString()) +  GetStr(time.Minute.ToString()) + GetStr(time.Second.ToString());
        }

        private string 获取实时采集路径()
        {
            return "c:\\" + "延时" + 获取时间路径();
        }

        private string 获取间隔采集路径()
        {
            return "c:\\" + "间隔" + 获取时间路径();
        }

        public void 实时采集(int 数据序号, float 数据值, int 时基)
        {
            byte[] bytes = System.BitConverter.GetBytes(数据序号);
            this.实时流.Write(bytes, 0, 4);
            bytes = System.BitConverter.GetBytes(数据值);
            this.实时流.Write(bytes, 0, 4);
            bytes = System.BitConverter.GetBytes(时基);
            this.实时流.Write(bytes, 0, 4);
            this.实时流.Flush();
        }

        public void 间隔采集(int 数据序号, float 数据值, int 时基)
        {
            byte[] bytes = System.BitConverter.GetBytes(数据序号);
            this.间隔流.Write(bytes, 0, 4);
            bytes = System.BitConverter.GetBytes(数据值);
            this.间隔流.Write(bytes, 0, 4);
            bytes = System.BitConverter.GetBytes(时基);
            this.间隔流.Write(bytes, 0, 4);
            this.间隔流.Flush();
        }
    }
}
