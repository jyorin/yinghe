using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 变频器控制
{
    public class 变频器控制
    {
        private bool 变频器1频率设置 = false; // false 表示未设置,true 表示已设置
        private bool 变频器2频率设置 = false; // false 表示未设置,true 表示已设置

        private 变频器串口 变频器写 = null;
        public static 变频器控制 变频器控制Obj;
        public static 变频器控制 Get_变频器控制()
        {
            if (变频器控制.变频器控制Obj == null)
            {
                变频器控制 _变频器控制 = new 变频器控制();
                变频器控制.变频器控制Obj = _变频器控制;
                return _变频器控制;
            }
            else
            {
                return 变频器控制.变频器控制Obj;
            }
        }

        public 变频器控制()
        {
            变频器写 = new 变频器串口();
            变频器写.打开串口();
        }

        public bool 变频器1正转()
        {
            if (!this.变频器1频率设置) { return false; }
            变频器报文 报文 = new 变频器报文(12, 0, 1);
            变频器写.写报文(报文.报文数据());
            return true;
        }

        public bool 变频器1正转停()
        {
            if (!this.变频器1频率设置) { return false; }
            变频器报文 报文 = new 变频器报文(12, 0, 0);
            变频器写.写报文(报文.报文数据());
            return true;
        }

        public bool 变频器1反转()
        {
            if (!this.变频器1频率设置) { return false; }
            变频器报文 报文 = new 变频器报文(12, 1, 1);
            变频器写.写报文(报文.报文数据());
            return true;
        }

        public bool 变频器1反转停()
        {
            if (!this.变频器1频率设置) { return false; }
            变频器报文 报文 = new 变频器报文(12, 1, 0);
            变频器写.写报文(报文.报文数据());
            return true;
        }

        public void 变频器1写频率(decimal 频率) // 0-50HZ
        {
           ushort f = (ushort)(频率 / System.Convert.ToDecimal(50) * 32000);
           变频器报文 报文 = new 变频器报文(12, 50, f);
           变频器写.写报文(报文.报文数据());
           if (频率 > 0)
           {
               this.变频器1频率设置 = true;
           }
           else
           {
               this.变频器1频率设置 = false;
           }
        }

        public bool 变频器2正转()
        {
            if (!this.变频器2频率设置) { return false; }
            变频器报文 报文 = new 变频器报文(12, 2, 1);
            变频器写.写报文(报文.报文数据());
            return true;
        }

        public bool 变频器2正转停()
        {
            if (!this.变频器2频率设置) { return false; }
            变频器报文 报文 = new 变频器报文(12, 2, 0);
            变频器写.写报文(报文.报文数据());
            return true;
        }

        public bool 变频器2反转()
        {
            if (!this.变频器2频率设置) { return false; }
            变频器报文 报文 = new 变频器报文(12, 3, 1);
            变频器写.写报文(报文.报文数据());
            return true;
        }

        public bool 变频器2反转停()
        {
            if (!this.变频器2频率设置) { return false; }
            变频器报文 报文 = new 变频器报文(12, 3, 0);
            变频器写.写报文(报文.报文数据());
            return true;
        }

        public bool 变频器3正转()
        {
            变频器报文 报文 = new 变频器报文(12, 4, 1);
            变频器写.写报文(报文.报文数据());
            return true;
        }

        public bool 变频器3正转停()
        {
            变频器报文 报文 = new 变频器报文(12, 4, 0);
            变频器写.写报文(报文.报文数据());
            return true;
        }

        public bool 变频器3反转()
        {
            变频器报文 报文 = new 变频器报文(12, 5, 1);
            变频器写.写报文(报文.报文数据());
            return true;
        }

        public bool 变频器3反转停()
        {
            变频器报文 报文 = new 变频器报文(12, 5, 0);
            变频器写.写报文(报文.报文数据());
            return true;
        }

        public void 变频器2写频率(decimal 频率)// 0-50HZ
        {
            ushort f = (ushort)(频率 / System.Convert.ToDecimal(50) * 32000);
            变频器读取 报文 = new 变频器读取(12, 51, f);
            变频器写.写报文(报文.报文数据());
            if (频率 > 0)
            {
                this.变频器2频率设置 = true;
            }
            else
            {
                this.变频器2频率设置 = false;
            }
        }
    }
}
