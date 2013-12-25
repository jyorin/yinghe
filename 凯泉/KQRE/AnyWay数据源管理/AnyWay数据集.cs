using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 数据存储;

namespace AnyWay数据源管理
{
    public class AnyWay数据集
    {
        public System.Threading.Thread thead = null;
        public 配置信息 _配置信息;
        public AnyWay数据集()
        {
            _配置信息 = 数据存储.类构造.获取配置信息();
        }
        public void 加载ANYWAY数据项()
        {
            数据项 item = null;
            int count = _配置信息._ANYWAY.list.Count;
            for (int i = 0; i < count; i++)
            {
                item = new 数据项();
                item.来源类型 = 数据来源类型.AnyWay;
                item.时针 = 类构造.获取采集时针();
                item.数据序号 = 100 + i;
                item.数据编码 = _配置信息._ANYWAY.list[i].获取规则编码();
                数据项哈希存储.AddItem(item.数据编码, item);
              
            }
        }

        public void 发送数据请求()
        {
            DLL解析源.initSocket();
            string ip = string.Empty;
            int ipCount = _配置信息._ANYWAY.IPS.list.Count;
            for (int k = 0; k < ipCount; k++)
            {
                ip = _配置信息._ANYWAY.IPS.list[k].IP;
                
                DLL解析源.ConnetW(ip);
                DLL解析源.closeW();
                DLL解析源.ConnetW(ip);
                DLL解析源.WriteW(1, 1);
                int count = _配置信息._ANYWAY.list.Count;
                for (int i = 0; i < count; i++)
                {
                    if (_配置信息._ANYWAY.list[i].IP == ip)
                    {
                        DLL解析源.readW(_配置信息._ANYWAY.list[i].ADDRESS);
                    }
                }
                AnyWay类构造.获取功率分析仪(ip);
            }
        }    
    }
}
