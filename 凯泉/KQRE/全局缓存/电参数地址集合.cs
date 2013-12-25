using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace 全局缓存
{
    public class 电参数地址集合
    {
        电参数配置 ds = null;
        public static 电参数地址集合 _电参数地址集合;
        public 电参数地址集合()
        {
            if (电参数地址集合._电参数地址集合 == null)
            {
                电参数地址集合._电参数地址集合 = this;
                this.加载电参数集合();
            }
        }

        public 电参数地址集合 获取电参数地址集合实例()
        {
            return 电参数地址集合._电参数地址集合;
        }

        public void 加载电参数集合()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\电参数配置\\电参数配置文件.xml";
            ds = new 电参数配置();
            ds.ReadXml(path);
        }

        public string 获取电参数(string 编码)
        {
            DataRow[] rows = ds.Tables[0].Select("KEY='" + 编码 + "'");
            if (rows.Length > 0)
            {
                return rows[0]["VALUE"].ToString();
            }
            return null;
        }
    }
}
