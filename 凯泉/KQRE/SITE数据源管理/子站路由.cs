using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SITE数据源管理
{
    internal class 子站路由
    {
        public static System.Collections.Hashtable tb = new System.Collections.Hashtable();

        public void 子站转发(byte[] bytes)
        {
            int id = (int)bytes[3];
            if (bytes[4] == 83) // 读应答
            {
                if (bytes[10] == 6) // 转速类型
                {
                    if (子站路由.tb.ContainsKey(id.ToString()))
                    {
                        转速子站 _site = (转速子站)tb[id.ToString()];
                        _site.FillData(bytes);
                    }
                    else
                    {
                        SiteBody body = new 转速结构();
                        转速集合 list = new 转速集合(id);
                        list.FillNode();
                        转速子站 site = new 转速子站(id, body, list);
                        site.FillData(bytes);
                        子站路由.tb.Add(site.head.ID.ToString(), site);
                    }       
                }
            }
        }
    }
}
