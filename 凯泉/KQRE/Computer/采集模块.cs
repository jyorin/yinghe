using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using 数据库操作库;
using 全局缓存;
namespace Computer
{
    public class 时基值 : IValue
    {
        public object Value
        {
            get
            {
                return 水泵试验缓存.水泵试验时基;
            }
            set { }
        }
    }


    public class 日期值 : IValue
    {

        public object Value
        {
            get
            {
                return System.DateTime.Now.Date.ToShortDateString();
            }
            set { }
        }
    }

    public class 时间值 : IValue
    {

        public object Value
        {
            get
            {
                System.DateTime time = System.DateTime.Now;
                return time.Hour.ToString() + "-" + time.Minute.ToString() + "-" + time.Second.ToString() + "-" + time.Millisecond.ToString();
            }
            set { }
        }
    }

    public class 采集序号 : IValue
    {
        private DataTable tb;
        private int _index = 0;
        public object Value
        {
            get
            {
                return this.tb.Rows.Count + 1;
            }
            set { }
        }

        //用于GahterTable构建Tb时.
        public void FillTb(DataTable tb)
        {
            this.tb = tb;
        }
    }

    public class 采集ID : IValue
    {
        private decimal id;
        public void 加载ID(string tbName)
        {
            id = 数据库操作类.GetTableMaxIDByName(tbName);
        }

        public object Value
        {
            get
            {
                return  ++ this.id;
            }
            set{}
        }
    }

    public class GROUP组 : IValue
    {

        public object Value
        {
            get;

            set;

        }
    }

    public class 额定转速 : IValue
    {
        public object Value
        {
            get
            {
              return  当前试验组信息.水泵额定转速;
            }

            set { }

        }
    }

    public class 批次编号 : IValue
    {

        #region IValue 成员
        int 编号 = -1;
        public object Value
        {
            get
            {
                return this.编号;
            }
            set
            {
                this.编号 = Convert.ToInt32(value);
            }
        }

        #endregion
    }
}
