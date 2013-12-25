using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Computer;

namespace Gather
{
    public interface IGatherItem
    {
        IComputerItem GetComputerItem(string key);
        IValue GetIValue(string key);
    }
}
