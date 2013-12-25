using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 数据存储
{
    public class 波形时针计数
    {
        private int _计数器 = 0;
        数据项 _数据项 = null;
        public 波形时针计数(数据项 _数据项)
        {
            this._数据项 = _数据项;
        }

        public string 波形编号
        {
            get;
            set;
        }

        public int 计数器
        {
            get;
            set;
        }

        public void 响应波形时针处理()
        {
            _计数器 = _计数器 + 1;
            if (_计数器 < 计数器) { return; }
            _计数器 = 0;
            this._数据项.TheWChannelManager.响应波形时针处理();
        }
    }
}
