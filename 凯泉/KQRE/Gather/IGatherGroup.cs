using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gather
{
    public interface IGatherGroup
    {
        void LoadGroupInfo(decimal groupid);
        decimal GetGroupId();
    }
}
