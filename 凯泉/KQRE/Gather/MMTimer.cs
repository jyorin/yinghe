using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Gather
{
    public class MMTimer 
    {
    
        [DllImport("Winmm.dll", CharSet = CharSet.Auto)]
        public static extern uint timeGetTime();
     
        /// <summary>
        /// The timer elapsed event 
        /// </summary>
        public event EventHandler Timer;
        private System.Threading.Thread thead = null;
        public int ms = 0;

        protected virtual void OnTimer(EventArgs e)
        {
            if (Timer != null)
            {
                Timer(this, e);
            }
        }

        public MMTimer()
        {
            //Initialize the API callback
        }

        /// <summary>
        /// Stop the current timer instance (if any)
        /// </summary>
        public void Stop()
        {
            this.flag = false;
            thead.Abort();
        }

        /// <summary>
        /// Start a timer instance
        /// </summary>
        /// <param name="ms">Timer interval in milliseconds</param>
        /// <param name="repeat">If true sets a repetitive event, otherwise sets a one-shot</param>
        public void Start()
        {
            //Kill any existing timer
            this.flag = true;
            thead = new System.Threading.Thread(this.Run);
            thead.IsBackground = true;
            thead.Start();
        }

        bool flag = false;
        void Run()
        {
            while (flag)
            {
                try
                {
                    Timer(this, null);
                    System.Threading.Thread.Sleep(this.ms);
                }
                catch { }
            }
        }
    }
}
