using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 辅助库;
using 全局缓存;

namespace Computer
{
    public class 汽蚀试验_临界值 : IComputerItem
    {
        public 汽蚀试验_临界值()
        {
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["扬程"];
            this.Items.Add(item1);
            item1._Notify += computerAction;
        }

        public void computerAction()
        {
            if (Items[0].数据值 == 0) { this.数据值 = 0; return; }
            double num = Items[0].数据值 * 0.97;
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 汽蚀试验_汽蚀余量 : IComputerItem
    {
        public 汽蚀试验_汽蚀余量()
        {
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["流量"];
            this.Items.Add(item1);
            IComputerItem item2 = (IComputerItem)tb["温度"];
            this.Items.Add(item2);
            IComputerItem item3 = (IComputerItem)tb["进口压力"];
            this.Items.Add(item3);

            item1._Notify += computerAction;
        }

        public void computerAction()
        {
            if (Items[0].数据值 == 0) { this.数据值 = 0; return; }
            double num = 辅助库.公共函数.f_计算NPSH的值(Items[1].数据值, Items[2].数据值, Items[0].数据值);
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 汽蚀试验_额定转速下汽蚀余量 : IComputerItem
    {
        public 汽蚀试验_额定转速下汽蚀余量()
        {
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["转速1_源数据"];
            this.Items.Add(item1);
            IComputerItem item2 = (IComputerItem)tb["流量"];
            this.Items.Add(item2);
            IComputerItem item3 = (IComputerItem)tb["温度"];
            this.Items.Add(item3);
            IComputerItem item4 = (IComputerItem)tb["进口压力"];
            this.Items.Add(item4);
            item1._Notify += computerAction;
        }

        //额定转速下汽蚀余量=(额定转速^2)/(转速^2)*汽蚀余量
        public void computerAction()
        { 
            if (Items[0].数据值 == 0) { this.数据值 = 0; return; }
            double n额定转速 = (float)全局缓存.当前试验组信息.水泵额定转速;
            double n汽蚀余量 = 辅助库.公共函数.f_计算NPSH的值(Items[2].数据值, Items[3].数据值, Items[1].数据值);
            double n额定转速下汽蚀余量 = n额定转速 * n额定转速 / Items[0].数据值 / Items[0].数据值 * n汽蚀余量;
            this.数据值 = 进制转换.f_保留N位小数((float)n额定转速下汽蚀余量, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 汽蚀试验_额定转速下流量 : IComputerItem
    {
        public 汽蚀试验_额定转速下流量()
        {
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["流量"];
            this.Items.Add(item1);
            IComputerItem item2 = (IComputerItem)tb["转速1_源数据"];
            this.Items.Add(item2);
            item1._Notify += computerAction;
        }

        //额定转速下流量=流量*额定转速/转速
        public void computerAction()
        {
            if ((Items[0].数据值 == 0) || (Items[1].数据值 == 0)){ this.数据值 = 0; return; }
            double n额定转速 = (float)全局缓存.当前试验组信息.水泵额定转速;
            double num = Items[0].数据值 * n额定转速 / Items[1].数据值;
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 汽蚀试验_额定转速下扬程 : IComputerItem
    {
        public 汽蚀试验_额定转速下扬程()
        {
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["出口压力"];
            this.Items.Add(item1);
            IComputerItem item2 = (IComputerItem)tb["进口压力"];
            this.Items.Add(item2);
            IComputerItem item3 = (IComputerItem)tb["流量"];
            this.Items.Add(item3);
            IComputerItem item4 = (IComputerItem)tb["流量"];
            this.Items.Add(item4);

            IComputerItem item5 = (IComputerItem)tb["转速1_源数据"];
            this.Items.Add(item5);
            item1._Notify += computerAction;
        }

        //额定扬程 = 标准泵扬程*(额定转速^2)/(转速^2)
        public void computerAction()
        {
            if (Items[4].数据值 == 0) { this.数据值 = 0; return; }
            double n额定转速 = (float)全局缓存.当前试验组信息.水泵额定转速;
            double 出口压力 = Items[0].数据值;
            double 进口压力 = Items[1].数据值;
            double 出口流量 = Items[2].数据值;
            double 进口流量 = Items[3].数据值;
            double 出口半径 = (当前试验组信息.水泵出口直径 / 1000) / 2;
            double 进口半径 = (当前试验组信息.水泵进口直径 / 1000) / 2;
            double 出口面积 = 3.1415926 * Math.Pow(出口半径, 2);
            double 进口面积 = 3.1415926 * Math.Pow(进口半径, 2);
            double 出口速度平方 = Math.Pow(((出口流量 / 3600) / 出口面积), 2);
            double 进口速度平方 = Math.Pow(((进口流量 / 3600) / 进口面积), 2);
            //标准泵扬程
            double 标准泵扬程 = (出口压力 - 进口压力) * 0.1023 + (当前试验组信息.出口压力表距 - 当前试验组信息.进口压力表距) + (出口速度平方 - 进口速度平方) / (2 * 9.81);

            double 额定扬程 = 标准泵扬程 * (n额定转速 * n额定转速) / (Items[4].数据值 * Items[4].数据值);
            this.数据值 = 进制转换.f_保留N位小数((float)额定扬程, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 汽蚀试验_额定转速下轴功率 : IComputerItem
    {
        public 汽蚀试验_额定转速下轴功率()
        {
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["输入功率"];
            this.Items.Add(item1);
            IComputerItem item2 = (IComputerItem)tb["转速1_源数据"];
            this.Items.Add(item2);
            item1._Notify += computerAction;
        }

        //额定转速下轴功率=轴功率*(额定转速^3)/(转速^3)
        public void computerAction()
        {
            if (Items[1].数据值 == 0) { this.数据值 = 0; return; }
            double n额定转速 = (float)全局缓存.当前试验组信息.水泵额定转速;
            //轴功率= a*(输入功率^2)+b*输入功率+c
            double 轴功率 = (Items[0].数据值 * Items[0].数据值) * 水泵试验缓存.变比 + 水泵试验缓存.偏移量 * Items[0].数据值 + 水泵试验缓存.常量;
            double 额定轴功率 = 轴功率 * (n额定转速 * n额定转速 * n额定转速) / (Items[1].数据值 * Items[1].数据值 * Items[1].数据值);
            this.数据值 = 进制转换.f_保留N位小数((float)额定轴功率, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 汽蚀试验_额定转速下泵效率 : IComputerItem
    {
        public 汽蚀试验_额定转速下泵效率()
        {
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["出口压力"];
            this.Items.Add(item1);
            IComputerItem item2 = (IComputerItem)tb["进口压力"];
            this.Items.Add(item2);
            IComputerItem item3 = (IComputerItem)tb["流量"];
            this.Items.Add(item3);
            IComputerItem item4 = (IComputerItem)tb["流量"];
            this.Items.Add(item4);
            IComputerItem item5 = (IComputerItem)tb["输入功率"];
            this.Items.Add(item5);

            IComputerItem item6 = (IComputerItem)tb["转速1_源数据"];
            this.Items.Add(item6);
            item1._Notify += computerAction;
        }

        //额定转速下流量=流量*额定转速/转速
        public void computerAction()
        {
            if (Items[5].数据值 == 0) { this.数据值 = 0; return; }
            double n额定转速 = (float)全局缓存.当前试验组信息.水泵额定转速;
            //额定转速下流量=流量*额定转速/转速
            double 额定转速下流量 = Items[2].数据值 * n额定转速 / Items[5].数据值;
            //额定扬程 = 标准泵扬程*(额定转速^2)/(转速^2)
            double 出口压力 = Items[0].数据值;
            double 进口压力 = Items[1].数据值;
            double 出口流量 = Items[2].数据值;
            double 进口流量 = Items[3].数据值;
            double 出口半径 = (当前试验组信息.水泵出口直径 / 1000) / 2;
            double 进口半径 = (当前试验组信息.水泵进口直径 / 1000) / 2;
            double 出口面积 = 3.1415926 * Math.Pow(出口半径, 2);
            double 进口面积 = 3.1415926 * Math.Pow(进口半径, 2);
            double 出口速度平方 = Math.Pow(((出口流量 / 3600) / 出口面积), 2);
            double 进口速度平方 = Math.Pow(((进口流量 / 3600) / 进口面积), 2);
            double 标准泵扬程 = (出口压力 - 进口压力) * 0.1023 + (当前试验组信息.出口压力表距 - 当前试验组信息.进口压力表距) + (出口速度平方 - 进口速度平方) / (2 * 9.81);
            double 额定扬程 = 标准泵扬程 * (n额定转速 * n额定转速) / (Items[5].数据值 * Items[5].数据值);
            //轴功率= a*(输入功率^2)+b*输入功率+c
            double 轴功率 = (Items[0].数据值 * Items[0].数据值) * 水泵试验缓存.变比 + 水泵试验缓存.偏移量 * Items[0].数据值 + 水泵试验缓存.常量;
            //额定转速下轴功率=轴功率*(额定转速^3)/(转速^3)
            double 额定转速下轴功率 = 轴功率 * (n额定转速 * n额定转速 * n额定转速) / (Items[5].数据值 * Items[5].数据值 * Items[5].数据值);

            //额定转速下泵效率 = 额定转速下流量/3.6*额定扬程/1.2/额定转速下轴功率
            double 额定转速下泵效率 = 额定转速下流量 / 3.6 * 额定扬程 / 1.02 / 额定转速下轴功率;
            this.数据值 = 进制转换.f_保留N位小数((float)额定转速下泵效率, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
}
