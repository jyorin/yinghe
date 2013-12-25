using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace 辅助库
{
    public class 信号量管理
    {
        private static bool m_b实例 = false;
        private Semaphore m_软启多任务信号量;
        private Semaphore m_命令信号量;
        private static 信号量管理 m_信号量实例;
        private 信号量管理()
        {
            m_b实例 = true;
            m_信号量实例 = null;
            m_软启多任务信号量 = new Semaphore(0, 1);
            m_命令信号量 = new Semaphore(0, 1);
        }

        public static 信号量管理 信号量实例()
        {
            if (!m_b实例)
            {
                m_信号量实例 = new 信号量管理();    
            }
            return m_信号量实例;
        }
        public void 开始运行命令()
        {
             m_命令信号量.WaitOne();
        }
        public void 结束运行命令()
        {
            m_命令信号量.Release();
        }
        public void 开始运行软启()
        {
            m_软启多任务信号量.WaitOne();
        }
        public void 结束运行软启()
        {
            m_软启多任务信号量.Release();
        }
    }
}