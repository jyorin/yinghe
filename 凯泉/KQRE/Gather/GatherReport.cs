using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gather
{
    public class GatherReport
    {
        public static GatherReport _Report;
        System.Collections.Hashtable tb = null;
        public GatherReport()
        {
           
        }

        public void Init()
        {
            tb = new System.Collections.Hashtable();
            GatherReport._Report = this;
        }

        public void Load(string reportName,IGatherDB db,GatherInfo info, IGatherItem IItem,int 间隔时间,int 延时时间,IThreadAction _action)
        {
            if (GatherReport._Report == null) { Init(); }
            GatherTimer _timer = new GatherTimer();
            _timer.间隔时间 = 间隔时间;
            _timer.延时时间 = (uint)延时时间;
            GatherTable tab = new GatherTable();
            tab.LoadGatherTable(info,_timer, IItem,db,_action);
            if (!GatherReport._Report.tb.ContainsKey(reportName))
            {
                GatherReport._Report.tb.Add(reportName, tab);
            }
            else
            {
                GatherReport._Report.tb.Remove(reportName);
                GatherReport._Report.tb.Add(reportName, tab);
            }
        }

        public GatherTable GetReportTable(string tab)
        {
            return (GatherTable)GatherReport._Report.tb[tab];
        }
    }
}
