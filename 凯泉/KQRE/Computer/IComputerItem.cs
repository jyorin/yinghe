using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Computer
{ 
    public delegate void Notify();
    public delegate void TODataShow(float d,int t);
    public interface IComputerItem
    {
        List<IComputerItem> Items { get; set; }
        int 时基 { get; set; }
        float 数据值 { get; set; }
        event Notify _Notify;
        event TODataShow DataShow;
        void load(Hashtable tb);
        void computerAction();
    }
}
