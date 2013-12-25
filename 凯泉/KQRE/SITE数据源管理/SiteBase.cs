using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 数据存储;

namespace SITE数据源管理
{
    internal class SiteBase
    {
        public SiteHead head;
        public SiteEnd end;
        public SiteBody body;
        public IListDataNode ListData;
        public int ID;

        public SiteBase(int ID,SiteBody body, IListDataNode ListData)
        {
            this.ID = ID;
            this.body = body;
            this.ListData = ListData;
        }

        public void FillData(byte[] bytes)
        {
            // 填充头
            head.FillHead(bytes);
            // 填充体
            body.FillData(ListData, bytes, 13);
            // 填充尾
            end.FillEnd(null);
        }
    }

    internal interface SiteBody
    {
        void FillData(IListDataNode ListData, byte[] bytes, int StartLen);
        object GetStruct();
    }

    internal abstract class IListDataNode
    {
        public List<数据项> list = null;
        protected  int ID;
        public IListDataNode(int ID)
        {
            this.ID = ID;
            list = new List<数据项>();
        }
        public abstract void FillNode();
        public 数据项 GetDataNode(string no)
        {
            int len = list.Count;
            for (int i = 0; i < len; i++)
            {
                if (this.list[i].数据编码 == no)
                {
                    return list[i];
                }
            }
            return null;
        }

        public 数据项 GetDataNode(int index)
        {
            return this.list[index];
        }
    }

    internal struct SiteHead
    {
        //STA,SLONGL,SLONGH,ID,RACK,ADDRL，ADDRH，DLONGL，DLONGH，CTLREG，DEVTYPE,VERSIONL，VERSIONH
        public byte STA;
        public byte SLONGL;
        public byte SLONGH;
        public byte ID;
        public byte BACK;
        public byte ADDRL;
        public byte ADDRH;
        public byte DLONGL;
        public byte DLONGH;
        public byte CTLREG;
        public byte DEVTYPE;
        public byte VERSIONL;
        public byte VERSIONH;

        public void FillHead(byte[] bytes)
        {
            this.STA = bytes[0];
            this.SLONGL = bytes[1];
            this.SLONGH = bytes[2];
            this.ID = bytes[3];
            this.BACK = bytes[4];
            this.ADDRL = bytes[5];
            this.ADDRH = bytes[6];
            this.DLONGL = bytes[7];
            this.DLONGH = bytes[8];
            this.CTLREG = bytes[9];
            this.DEVTYPE = bytes[10];
            this.VERSIONL = bytes[11];
            this.VERSIONH = bytes[12];
        }
    }

    internal struct SiteEnd
    {
        public void FillEnd(byte[] bytes)
        {
        }
    }

}
