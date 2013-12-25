using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 辅助库;
using 全局缓存;

namespace Computer
{
    public class 性能试验_流量 : IComputerItem
    {
        电参数地址集合 电参量 = null;
        public 性能试验_流量()
        {
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            电参量 = new 电参数地址集合().获取电参数地址集合实例();
            IComputerItem item1 = (IComputerItem)tb["流量_源数据"];
            this.Items.Add(item1);
            item1._Notify += computerAction;
        }

        public void computerAction()
        {
            //double 最大量程 = System.Convert.ToDouble(电参量.获取电参数("流量最大量程"));
            double num = Items[0].数据值 * 全局缓存.水泵试验缓存.水泵流量最大量程 / 27648;
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_出口压力 : IComputerItem
    {
        电参数地址集合 电参量 = null;
        public 性能试验_出口压力()
        {
            电参量 = new 电参数地址集合().获取电参数地址集合实例();
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["出口压力_源数据"];
            this.Items.Add(item1);
            item1._Notify += computerAction;
        }

        public void computerAction()
        {
            // 缺少源数据的转换公式,仅对Items[0].数据值进行操作
            double 最大量程 = 全局缓存.水泵试验缓存.出口压力量程;
            double num = (Items[0].数据值 * 最大量程 / 27648) * System.Convert.ToDouble(1000);
            this.数据值 = 进制转换.f_保留N位小数((float)num, 5);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_进口压力 : IComputerItem
    {
        电参数地址集合 电参量 = null;
        public 性能试验_进口压力()
        {
            电参量 = new 电参数地址集合().获取电参数地址集合实例();
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["进口压力_源数据"];
            this.Items.Add(item1);
            item1._Notify += computerAction;
        }

        public void computerAction()
        {
            // 缺少源数据的转换公式,仅对Items[0].数据值进行操作
            double 最大量程 = 全局缓存.水泵试验缓存.进口压力量程;
            double num = 0;
            if (最大量程 > 0)
            {
                num = (Items[0].数据值 * 最大量程 / 27648) * System.Convert.ToDouble(1000);
            }
            else
            {
                num = (27648 - Items[0].数据值) / 27648 * 最大量程  * System.Convert.ToDouble(1000);
            }
            this.数据值 = 进制转换.f_保留N位小数((float)num, 5);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_扬程 : IComputerItem
    {
        public 性能试验_扬程()
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
            item1._Notify += computerAction;
        }

        public void computerAction()
        {
            double num = Items[0].数据值 * 0.1023 + 当前试验组信息.出口压力表距;
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_标准泵扬程 : IComputerItem
    {
        public 性能试验_标准泵扬程()
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
            item1._Notify += computerAction;
        }

        //H=(Z2-Z1)+(P2-P1)/(g*ρ)+(v2^2-v1^2)/(2*g)
        //Z2表示出口表矩
        //Z1表示进口表矩
        //g重力加速度
        //ρ水密度
        //v1进口流速
        //v2出口流速
        public void computerAction()
        {
            double 出口压力 = Items[0].数据值;
            double 进口压力 = Items[1].数据值;
            //double 进口压力 = 0;
            double 出口流量 = Items[2].数据值;
            double 进口流量 = Items[3].数据值;
            //double 出口半径 = (当前试验组信息.水泵出口直径 / 1000) / 2;
            //double 进口半径 = (当前试验组信息.水泵进口直径 / 1000) / 2;
            //double 出口面积 = 3.1415926 * Math.Pow(出口半径, 2);
            //double 进口面积 = 3.1415926 * Math.Pow(进口半径, 2);
            double 出口面积 = 3.1415926 * Math.Pow(当前试验组信息.水泵出口直径/1000, 2)*900;
            double 进口面积 = 3.1415926 * Math.Pow(当前试验组信息.水泵进口直径/1000, 2)*900;
            //double 出口速度平方 = Math.Pow(((出口流量 / 3600) / 出口面积), 2);
            //double 进口速度平方 = Math.Pow(((进口流量 / 3600) / 进口面积), 2);
            double 出口速度平方 = Math.Pow((出口流量 / 出口面积), 2);
            double 进口速度平方 = Math.Pow((进口流量 / 进口面积), 2);
            double 扬程 = (出口压力 - 进口压力) * 0.1023 + (当前试验组信息.出口压力表距 - 当前试验组信息.进口压力表距) + (出口速度平方 - 进口速度平方) / (2 * 9.81);
            //double num = Items[0].数据值 * 0.102 + 当前试验组信息.出口压力表距;
            this.数据值 = 进制转换.f_保留N位小数((float)扬程, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_额定转速下流量 : IComputerItem
    {
        public 性能试验_额定转速下流量()
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
            item1._Notify += computerAction;
        }

        public void computerAction()
        {
            double num = Items[0].数据值;
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_额定转速下扬程 : IComputerItem
    {
        public 性能试验_额定转速下扬程()
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
            double num =  Items[0].数据值;
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_电压 : IComputerItem
    {
        string 电压电参数 = null;
        public 性能试验_电压()
        {
            电压电参数 = System.Configuration.ConfigurationSettings.AppSettings["电压"].ToString();
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {

            IComputerItem item1 = (IComputerItem)tb[电压电参数];
            this.Items.Add(item1);
            item1._Notify += computerAction;
        }

        public void computerAction()
        {
            double num = Items[0].数据值;
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_电流 : IComputerItem
    {
        string 电流电参数 = null;
        public 性能试验_电流()
        {
            电流电参数 = System.Configuration.ConfigurationSettings.AppSettings["电流"].ToString();
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb[电流电参数];
            this.Items.Add(item1);
            item1._Notify += computerAction;
        }

        public void computerAction()
        {
            double num = Items[0].数据值;
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_功率因素 : IComputerItem
    {
        string 功率因素电参数 = null;
        public 性能试验_功率因素()
        {
            功率因素电参数 = System.Configuration.ConfigurationSettings.AppSettings["功率因素"].ToString();
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {

            IComputerItem item1 = (IComputerItem)tb[功率因素电参数];
            this.Items.Add(item1);
            item1._Notify += computerAction;
        }

        public void computerAction()
        {
            double num = Items[0].数据值;
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_输入功率 : IComputerItem
    {
        string 输入功率电参数 = null;
        public 性能试验_输入功率()
        {
            输入功率电参数 = System.Configuration.ConfigurationSettings.AppSettings["输入功率"].ToString();
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb[输入功率电参数];
            this.Items.Add(item1);
            item1._Notify += computerAction;
        }

        public void computerAction()
        {
            double num = Items[0].数据值;
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_轴功率 : IComputerItem
    {
        public 性能试验_轴功率()
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
            item1._Notify += computerAction;
        }

        //轴功率= a*(输入功率^2)+b*输入功率+c
        public void computerAction()
        {
            double num = (Items[0].数据值 * Items[0].数据值) * 水泵试验缓存.变比 + 水泵试验缓存.偏移量 * Items[0].数据值 + 水泵试验缓存.常量;
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_额定转速下轴功率 : IComputerItem
    {
        public 性能试验_额定转速下轴功率()
        {
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["轴功率"];
            this.Items.Add(item1);
            item1._Notify += computerAction;
        }

        public void computerAction()
        {
            // 额定转速下有个转差率.测试出的转速与额定转速的比值
            double num = Items[0].数据值 * 1 ;
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_额定转速下泵效率 : IComputerItem
    {
        public 性能试验_额定转速下泵效率()
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
            IComputerItem item2 = (IComputerItem)tb["扬程"];
            IComputerItem item3 = (IComputerItem)tb["轴功率"];
            this.Items.Add(item1);
            this.Items.Add(item2);
            this.Items.Add(item3);
            item1._Notify += computerAction;
        }

        public void computerAction()
        {
            if (Items[1].数据值 == 0 || Items[2].数据值 == 0) { this.数据值 = 0; return; }
            double num = (Items[0].数据值 * Items[1].数据值) / (102 * 3.6) / Items[2].数据值 * 100;
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_额定转速下机组效率 : IComputerItem
    {
        public 性能试验_额定转速下机组效率()
        {
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["额定转速下泵效率"];
            this.Items.Add(item1);     
            item1._Notify += computerAction;
        }

        public void computerAction()
        {
            if (Items[0].数据值 == 0) { this.数据值 = 0; return; }
            double num = Items[0].数据值 * 当前试验组信息.电机额定效率;
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_泵效率 : IComputerItem
    {
        public 性能试验_泵效率()
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
            IComputerItem item2 = (IComputerItem)tb["扬程"];
            IComputerItem item3 = (IComputerItem)tb["轴功率"];
            this.Items.Add(item1);
            this.Items.Add(item2);
            this.Items.Add(item3);
            item1._Notify += computerAction;
        }

        public void computerAction()
        {
            if (Items[1].数据值 == 0 || Items[2].数据值 == 0) { this.数据值 = 0; return; }
            double num = (Items[0].数据值 * Items[1].数据值) / (102 * 3.6) / Items[2].数据值 * 100;
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_机组效率 : IComputerItem
    {
        public 性能试验_机组效率()
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
            IComputerItem item2 = (IComputerItem)tb["扬程"];
            IComputerItem item3 = (IComputerItem)tb["输入功率"];
            this.Items.Add(item1);
            this.Items.Add(item2);
            this.Items.Add(item3);
            item1._Notify += computerAction;
        }

        public void computerAction()
        {
            if (Items[1].数据值 == 0 || Items[2].数据值 == 0) { this.数据值 = 0; return; }
            double num = (Items[0].数据值 * Items[1].数据值) / (102 * 3.6) / Items[2].数据值 * 100;
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);

            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_温度 : IComputerItem
    {
        string 电压电参数 = null;
        public 性能试验_温度()
        {
            电压电参数 = System.Configuration.ConfigurationSettings.AppSettings["电压"].ToString();
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["温度_源数据"];
            this.Items.Add(item1);
            item1._Notify += computerAction;

            IComputerItem item2 = (IComputerItem)tb[电压电参数];
            this.Items.Add(item2);
            item2._Notify += computerAction;
        }

        public void computerAction()
        {
            //如果没有温度计，则取手动输入的温度值
            if (全局缓存.当前试验组信息.温度测量仪表ID <0)
            {
                this.数据值 = 进制转换.f_保留N位小数((float)全局缓存.当前试验组信息.温度, 2);
                if (this._Notify != null) { this._Notify(); }
                if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
                辅助库.数据服务类.获取数据服务对象().DataValue.温度1 = this.数据值;
                return;
            }
            //如果有温度计，则取采集值
            if (Items[0].数据值 == 0) { this.数据值 = 0; return; }
            double num = Items[0].数据值 / System.Convert.ToSingle(10);
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
            辅助库.数据服务类.获取数据服务对象().DataValue.温度1 = this.数据值;
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_温度2 : IComputerItem
    {
        string 电压电参数 = null;
        public 性能试验_温度2()
        {
            电压电参数 = System.Configuration.ConfigurationSettings.AppSettings["电压"].ToString();
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["温度_源数据2"];
            this.Items.Add(item1);
            item1._Notify += computerAction;

            IComputerItem item2 = (IComputerItem)tb[电压电参数];
            this.Items.Add(item2);
            item2._Notify += computerAction;
        }

        public void computerAction()
        {
            if (全局缓存.当前试验组信息.温度测量仪表ID < 0)
            {
                this.数据值 = 进制转换.f_保留N位小数((float)全局缓存.当前试验组信息.温度, 2);
                if (this._Notify != null) { this._Notify(); }
                if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
                辅助库.数据服务类.获取数据服务对象().DataValue.温度2 = this.数据值;
                return;
            }
            if (Items[0].数据值 == 0) { this.数据值 = 0; return; }
            double num = Items[0].数据值 / System.Convert.ToSingle(10);
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
            辅助库.数据服务类.获取数据服务对象().DataValue.温度2 = this.数据值;
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_温度3 : IComputerItem
    {
        string 电压电参数 = null;
        public 性能试验_温度3()
        {
            电压电参数 = System.Configuration.ConfigurationSettings.AppSettings["电压"].ToString();
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["温度_源数据3"];
            this.Items.Add(item1);
            item1._Notify += computerAction;

            IComputerItem item2 = (IComputerItem)tb[电压电参数];
            this.Items.Add(item2);
            item2._Notify += computerAction;
        }

        public void computerAction()
        {
            if (全局缓存.当前试验组信息.温度测量仪表ID < 0)
            {
                this.数据值 = 进制转换.f_保留N位小数((float)全局缓存.当前试验组信息.温度, 2);
                if (this._Notify != null) { this._Notify(); }
                if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
                辅助库.数据服务类.获取数据服务对象().DataValue.温度3 = this.数据值;
                return;
            }
            if (Items[0].数据值 == 0) { this.数据值 = 0; return; }
            double num = Items[0].数据值 / System.Convert.ToSingle(10);
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
            辅助库.数据服务类.获取数据服务对象().DataValue.温度3 = this.数据值;
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_温度4 : IComputerItem
    {
        string 电压电参数 = null;
        public 性能试验_温度4()
        {
            电压电参数 = System.Configuration.ConfigurationSettings.AppSettings["电压"].ToString();
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["温度_源数据4"];
            this.Items.Add(item1);
            item1._Notify += computerAction;

            IComputerItem item2 = (IComputerItem)tb[电压电参数];
            this.Items.Add(item2);
            item2._Notify += computerAction;
        }

        public void computerAction()
        {
            if (全局缓存.当前试验组信息.温度测量仪表ID < 0)
            {
                this.数据值 = 进制转换.f_保留N位小数((float)全局缓存.当前试验组信息.温度, 2);
                if (this._Notify != null) { this._Notify(); }
                if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
                辅助库.数据服务类.获取数据服务对象().DataValue.温度4 = this.数据值;
                return;
            }
            if (Items[0].数据值 == 0) { this.数据值 = 0; return; }
            double num = Items[0].数据值 / System.Convert.ToSingle(10);
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
            辅助库.数据服务类.获取数据服务对象().DataValue.温度4 = this.数据值;
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_温度5 : IComputerItem
    {
        string 电压电参数 = null;
        public 性能试验_温度5()
        {
            电压电参数 = System.Configuration.ConfigurationSettings.AppSettings["电压"].ToString();
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["温度_源数据5"];
            this.Items.Add(item1);
            item1._Notify += computerAction;

            IComputerItem item2 = (IComputerItem)tb[电压电参数];
            this.Items.Add(item2);
            item2._Notify += computerAction;
        }

        public void computerAction()
        {
            if (全局缓存.当前试验组信息.温度测量仪表ID < 0)
            {
                this.数据值 = 进制转换.f_保留N位小数((float)全局缓存.当前试验组信息.温度, 2);
                if (this._Notify != null) { this._Notify(); }
                if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
                辅助库.数据服务类.获取数据服务对象().DataValue.温度5 = this.数据值;
                return;
            }
            if (Items[0].数据值 == 0) { this.数据值 = 0; return; }
            double num = Items[0].数据值 / System.Convert.ToSingle(10);
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
            辅助库.数据服务类.获取数据服务对象().DataValue.温度5 = this.数据值;
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_温度6 : IComputerItem
    {
        string 电压电参数 = null;
        public 性能试验_温度6()
        {
            电压电参数 = System.Configuration.ConfigurationSettings.AppSettings["电压"].ToString();
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["温度_源数据6"];
            this.Items.Add(item1);
            item1._Notify += computerAction;

            IComputerItem item2 = (IComputerItem)tb[电压电参数];
            this.Items.Add(item2);
            item2._Notify += computerAction;
        }

        public void computerAction()
        {
            if (全局缓存.当前试验组信息.温度测量仪表ID < 0)
            {
                this.数据值 = 进制转换.f_保留N位小数((float)全局缓存.当前试验组信息.温度, 2);
                if (this._Notify != null) { this._Notify(); }
                if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
                辅助库.数据服务类.获取数据服务对象().DataValue.温度6 = this.数据值;
                return;
            }
            if (Items[0].数据值 == 0) { this.数据值 = 0; return; }
            double num = Items[0].数据值 / System.Convert.ToSingle(10);
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
            辅助库.数据服务类.获取数据服务对象().DataValue.温度6 = this.数据值;
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_温度7 : IComputerItem
    {
        string 电压电参数 = null;
        public 性能试验_温度7()
        {
            电压电参数 = System.Configuration.ConfigurationSettings.AppSettings["电压"].ToString();
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["温度_源数据7"];
            this.Items.Add(item1);
            item1._Notify += computerAction;

            IComputerItem item2 = (IComputerItem)tb[电压电参数];
            this.Items.Add(item2);
            item2._Notify += computerAction;
        }

        public void computerAction()
        {
            if (全局缓存.当前试验组信息.温度测量仪表ID < 0)
            {
                this.数据值 = 进制转换.f_保留N位小数((float)全局缓存.当前试验组信息.温度, 2);
                if (this._Notify != null) { this._Notify(); }
                if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
                辅助库.数据服务类.获取数据服务对象().DataValue.温度7 = this.数据值;
                return;
            }
            if (Items[0].数据值 == 0) { this.数据值 = 0; return; }
            double num = Items[0].数据值 / System.Convert.ToSingle(10);
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
            辅助库.数据服务类.获取数据服务对象().DataValue.温度7 = this.数据值;
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_温度8 : IComputerItem
    {
        string 电压电参数 = null;
        public 性能试验_温度8()
        {
            电压电参数 = System.Configuration.ConfigurationSettings.AppSettings["电压"].ToString();
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["温度_源数据8"];
            this.Items.Add(item1);
            item1._Notify += computerAction;

            IComputerItem item2 = (IComputerItem)tb[电压电参数];
            this.Items.Add(item2);
            item2._Notify += computerAction;
        }

        public void computerAction()
        {
            if (全局缓存.当前试验组信息.温度测量仪表ID < 0)
            {
                this.数据值 = 进制转换.f_保留N位小数((float)全局缓存.当前试验组信息.温度, 2);
                if (this._Notify != null) { this._Notify(); }
                if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
                辅助库.数据服务类.获取数据服务对象().DataValue.温度8 = this.数据值;
                return;
            }
            if (Items[0].数据值 == 0) { this.数据值 = 0; return; }
            double num = Items[0].数据值 / System.Convert.ToSingle(10);
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
            辅助库.数据服务类.获取数据服务对象().DataValue.温度8 = this.数据值;
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_转速1 : IComputerItem
    {
        string 电压电参数 = null;
        public 性能试验_转速1()
        {
            电压电参数 = System.Configuration.ConfigurationSettings.AppSettings["电压"].ToString();
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
            item1._Notify += computerAction;

            IComputerItem item2 = (IComputerItem)tb[电压电参数];
            this.Items.Add(item2);
            item2._Notify += computerAction;
        }

        public void computerAction()
        {
            if (全局缓存.当前试验组信息.转速测量仪表ID < 0)
            {
                this.数据值 = 进制转换.f_保留N位小数((float)全局缓存.当前试验组信息.水泵额定转速, 2);
                if (this._Notify != null) { this._Notify(); }
                if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
                辅助库.数据服务类.获取数据服务对象().DataValue.转速1 = this.数据值;
                return;
            }
            if (Items[0].数据值 == 0) { this.数据值 = 0; return; }
            double num = Items[0].数据值;
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
            辅助库.数据服务类.获取数据服务对象().DataValue.转速1= this.数据值;
        }
        public event TODataShow DataShow;
    }
    public class 性能试验_转速2 : IComputerItem
    {
        string 电压电参数 = null;
        public 性能试验_转速2()
        {
            电压电参数 = System.Configuration.ConfigurationSettings.AppSettings["电压"].ToString();
            this.Items = new List<IComputerItem>();
        }

        public event Notify _Notify;
        public int 时基 { get; set; }
        public float 数据值 { get; set; }
        public List<IComputerItem> Items { get; set; }

        public void load(System.Collections.Hashtable tb)
        {
            IComputerItem item1 = (IComputerItem)tb["转速2_源数据"];
            this.Items.Add(item1);
            item1._Notify += computerAction;

            IComputerItem item2 = (IComputerItem)tb[电压电参数];
            this.Items.Add(item2);
            item2._Notify += computerAction;
        }

        public void computerAction()
        {
            if (全局缓存.当前试验组信息.转速测量仪表ID < 0)
            {
                this.数据值 = 进制转换.f_保留N位小数((float)全局缓存.当前试验组信息.水泵额定转速, 2);
                if (this._Notify != null) { this._Notify(); }
                if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
                辅助库.数据服务类.获取数据服务对象().DataValue.转速2 = this.数据值;
                return;
            }
            if (Items[0].数据值 == 0) { this.数据值 = 0; return; }
            double num = Items[0].数据值;
            this.数据值 = 进制转换.f_保留N位小数((float)num, 2);
            if (this._Notify != null) { this._Notify(); }
            if (this.DataShow != null) { this.DataShow(this.数据值, 0); }
            辅助库.数据服务类.获取数据服务对象().DataValue.转速2 = this.数据值;
        }
        public event TODataShow DataShow;
    }
}
