using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 数据存储
{
    public class 波形时针
    {
        System.Threading.Thread thead = null;
        List<波形时针计数> list = new List<波形时针计数>();
        波形时针计数 _计数 = null;
        private object obj = new object();

        public void 新增波形时针计数(波形时针计数 _计数)
        {
                this._计数 = _计数;
                list.Add(_计数);            
        }


        public void 删除波形时针计数(波形时针计数 _计数)
        {
            this._计数 = _计数;
            list.Remove(_计数);
        }

        public void 开启波形线程()
        {
            thead = new System.Threading.Thread(this.Run);
            thead.IsBackground = true;
            thead.Start();
        }

        bool 是否允许操作 = false;
        public void Run()
        {
            int len = 0;
            while (true)
            {              
                    len = list.Count;
                    for (int i = 0; i < len; i++)
                    {
                        list[i].响应波形时针处理();
                    }
                
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
