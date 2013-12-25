using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Computer
{
    public class TestClass : IComputerItem
    {
        public TestClass()
        {
            this.Items = new List<IComputerItem>();
        }
        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["33"];
            IComputerItem item2 = (IComputerItem)tb["44"];
            IComputerItem item3 = (IComputerItem)tb["55"];
            this.Items.Add((IComputerItem)tb["33"]);
            this.Items.Add((IComputerItem)tb["44"]);
            this.Items.Add((IComputerItem)tb["55"]);
            item1._Notify += new Notify(computerAction);
            item2._Notify += new Notify(computerAction);
            item3._Notify += new Notify(computerAction); 
        }

        public void computerAction()
        {
            this.数据值 = (float)Math.Atan2((double)Items[0].数据值, (double)Items[1].数据值) * Items[2].数据值;
        }
        public event TODataShow DataShow;     
    }
}
