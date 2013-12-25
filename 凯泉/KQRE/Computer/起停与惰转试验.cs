using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 辅助库;
namespace Computer
{
    public class 起停与惰转试验_轴功率 : IComputerItem
    {
        public 起停与惰转试验_轴功率()
        {
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["192-168-1-98-320"];
            this.Items.Add(item1);
            item1._Notify += computerAction;
        }

        public void computerAction()
        {
            this.数据值 = 进制转换.f_保留N位小数(Items[0].数据值, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
}
