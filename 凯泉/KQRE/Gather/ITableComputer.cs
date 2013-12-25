using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Gather
{
    public interface ITableComputer
    {
        float Computer(float d, DataRowView row);
    }
}
