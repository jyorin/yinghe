using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace 数据存储
{
    public interface I数据平均处理
    {
        float 取平均值(float d, int t);
    }

    public class 数据平均处理 : I数据平均处理
    {
        private float 平均值 = -1;
        private DateTime 基点时间;
        private TimeSpan 比较时间戳;
        private TimeSpan span;
        public 数据平均处理(int 毫秒数)
        {
            基点时间 = System.DateTime.Now;
            比较时间戳 = new TimeSpan(0, 0, 0, 0, 毫秒数); // 性能试验,运转试验500毫秒,汽蚀试验100毫秒,启动试验实时
        }
        public float 取平均值(float d, int t)
        {
            span = System.DateTime.Now - 基点时间;
            int 比较值 = span.CompareTo(比较时间戳);
            if (比较值 > 0)
            {
                基点时间 = System.DateTime.Now;
                平均值 = (d + 平均值) / 2;
                return 平均值;
            }
            else
            {
                平均值 = (d + 平均值) / 2;
                return -1;
            }
        }
    }

    public class DataPvg
    {
        public static void LoadDataPvg(int 毫秒数)
        {
            foreach (DictionaryEntry item in 数据项哈希存储.数据项哈希集)
            {
                数据项 _数据项 = item.Value as 数据项;
                if (_数据项 != null)
                {
                    if (毫秒数 > 0)
                    {
                        _数据项._数据取平均值 = new 数据平均处理(毫秒数);
                    }
                    else
                    {
                        _数据项._数据取平均值 = null;
                    }
                }
            }
        }
    }
}
