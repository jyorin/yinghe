using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 数据存储;
using Computer;

namespace SITE数据源管理
{
    internal class 转速集合 : IListDataNode
    {
        public 转速集合(int ID) : base(ID) {  }
        

        public override void FillNode()
        {
            数据项 node = new 数据项();
            node.来源类型 = 数据来源类型.SITE;
            node.时针 = 类构造.获取采集时针();
            node.数据编码 = "FREQ"; // 频率测试结果
            list.Add(node);
            数据项哈希存储.AddItem(数据来源编码规则.GetSITE(this.ID.ToString(), "FREQ"), node);
            node.来源类型 = 数据来源类型.SITE;
            node.时针 = 类构造.获取采集时针();
            node.数据编码 = "FREQ2";// 频率测试结果2
            list.Add(node);
            数据项哈希存储.AddItem(数据来源编码规则.GetSITE(this.ID.ToString(), "FREQ2"), node);
        }
    }

    internal class 转速结构 : SiteBody
    {
        //SEMPTYO,MODE,URNG,IRNG,VOLT,CARRENT,POWER,FREQ

        float FREQ;
        float FREQ2;
        public void FillData(IListDataNode ListData, byte[] bytes, int StartLen)
        {
            int len = StartLen;

            this.FREQ = System.BitConverter.ToSingle(bytes, len); len = len + 4;
            this.FREQ2 = System.BitConverter.ToSingle(bytes, len); len = len + 4;

            ListData.GetDataNode(0).AddData(this.FREQ, -1);
            ListData.GetDataNode(1).AddData(this.FREQ2, -1);
        }

        public object GetStruct()
        {
            return this;
        }
    }

    internal class 转速子站 : SiteBase
    {
        public 转速子站(int ID,SiteBody body, IListDataNode ListData) : base(ID,body, ListData) { }
    }

}
