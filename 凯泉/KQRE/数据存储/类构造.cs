using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 数据存储
{
    public class 类构造
    {
        private static 采集管理 采集管理缓存 = null;
        private static 采集时针 采集时针缓存 = null;
        private static PLC集合 PLC集合缓存 = null;
        private static ANYWAY集合 ANYWAY集合缓存 = null;
        private static IP集合 IP集合缓存 = null;
        private static 配置信息 配置信息缓存 = null;
        private static 波形时针 波形时针缓存 = null;

        public static 波形时针 获取波形时针()
        {
            if (波形时针缓存 == null)
            {
                波形时针 _波形时针 = new 波形时针();
                _波形时针.开启波形线程();
                波形时针缓存 = _波形时针;
                return _波形时针;
            }
            else
            {
                波形时针 _波形时针 = (波形时针)波形时针缓存;
                return _波形时针;
            }
        }

        public static 采集管理 获取采集管理()
        {
            if (采集管理缓存 == null)
            {
                采集管理 _采集管理 = new 采集管理();
                采集管理缓存 = _采集管理;
                return _采集管理;
            }
            else
            {
                采集管理 _采集管理 = (采集管理)采集管理缓存;
                return _采集管理;
            }
        }

        public static 采集时针 获取采集时针()
        {
            if (采集时针缓存 == null)
            {
                采集管理 _采集管理 = 获取采集管理();
                采集时针 _采集时针 = new 采集时针(_采集管理);
                采集时针缓存 = _采集时针;
                return _采集时针;
            }
            else
            {
                采集时针 _采集时针 = (采集时针)采集时针缓存;
                return _采集时针;
            }
        }

        public static 数据项 获取数据项()
        {
            数据项 _数据项 = new 数据项();
            采集时针 _采集时针 = 获取采集时针();
            _数据项.时针 = _采集时针;
            return _数据项;
            
        }

        public static PLC集合 获取PLC集合()
        {
             PLC集合 plc = null;
            if (PLC集合缓存 == null)
            {
                plc = new PLC集合();
                plc.填充List();
                PLC集合缓存 = plc;
            }
            else
            {
                plc = PLC集合缓存;
            }
            return plc;
        }

        public static IP集合 获取IP集合()
        {
            IP集合 ips = null;
            if (IP集合缓存 == null)
            {
                ips = new IP集合();
                ips.填充List();
                IP集合缓存 = ips;
            }
            else
            {
                ips = IP集合缓存;
            }
            return ips;
        }

        public static ANYWAY集合 获取ANYWAY集合()
        {
            ANYWAY集合 anyways = null;
            if (ANYWAY集合缓存 == null)
            {
                anyways = new ANYWAY集合();
                anyways.填充List();
                ANYWAY集合缓存 = anyways;
            }
            else
            {
                anyways = ANYWAY集合缓存;
            }
            return anyways;
        }

        public static 配置信息 获取配置信息()
        {
            配置信息 _配置信息 = null;
            if (配置信息缓存 == null)
            {
                _配置信息 = new 配置信息();
                配置信息缓存 = _配置信息;
            }
            else
            {
                _配置信息 = 配置信息缓存;
            }
            return _配置信息;
        }
    }
}
