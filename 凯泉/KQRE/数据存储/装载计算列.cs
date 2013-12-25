using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Computer;

namespace 数据存储
{
    public class 装载计算列
    {
        public static  void To装载计算列()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Computer.dll";
            Assembly _ass = Assembly.LoadFile(path);
            文件操作 file = new 文件操作();
            file.PATH = AppDomain.CurrentDomain.BaseDirectory + "\\数据配置文件\\计算列源.csv";
            file.加载文件();
            string value = string.Empty;
            string[] _value = null;

            while ((value = file.读数据()) != null)
            {
                _value = value.Split(',');

                Type type = _ass.GetType(_value[1]);
                IComputerItem obj = (IComputerItem)Activator.CreateInstance(type, null);
                obj.load(数据项哈希存储.数据项哈希集);
                数据项哈希存储.AddItem(_value[0], obj);
            }
        }
    }

    public class 装载值列
    {
        public static void To装载值列()
        {
            时基值 _时基值 = new 时基值();
            数据项哈希存储.AddItem("时基值", _时基值);
            日期值 _日期值 = new 日期值();
            数据项哈希存储.AddItem("日期值", _日期值);
            时间值 _时间值 = new 时间值();
            数据项哈希存储.AddItem("时间值", _时间值);
            数据项哈希存储.AddItem("额定转速", new 额定转速());
            批次编号 _批次编号 = new 批次编号();
            数据项哈希存储.AddItem("批次编号", _批次编号);
            string[] 序列组 = new string[] {"序列1","序列2","序列3","序列4" };
            for (int i = 0; i < 4; i++)
            {
                数据项哈希存储.AddItem(序列组[i], new 采集序号());
            }
            string[] ID组 = new string[] { "潜水泵性能试验", "汽蚀试验","运转试验","启动试验","惰转试验","温升试验" };
            for (int i = 0; i < ID组.Length; i++)
            {
                采集ID _id = new 采集ID();
                _id.加载ID(ID组[i]);
                数据项哈希存储.AddItem(ID组[i], _id);
            }
            string[] GROUP组 = new string[] { "潜水泵性能试验_GROUPID", "汽蚀试验_GROUPID", "运转试验_GROUPID", "启动试验_GROUPID", "惰转试验_GROUPID", "温升试验_GROUPID" };
            for (int i = 0; i < GROUP组.Length; i++)
            {
                数据项哈希存储.AddItem(GROUP组[i], new GROUP组());
            }
        }

        public static void 加载组信息(decimal groupid)
        {
            string[] ID组 = new string[] { "潜水泵性能试验_GROUPID", "汽蚀试验_GROUPID", "运转试验_GROUPID", "启动试验_GROUPID","惰转试验_GROUPID", "温升试验_GROUPID" };
            for (int i = 0; i < ID组.Length; i++)
            {
                ((GROUP组)数据项哈希存储.GetIValue(ID组[i])).Value = groupid;
            }
        }
    }
}
