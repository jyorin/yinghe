using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gather
{
    public delegate void ActionData();
    public interface IThreadAction
    {
        bool isAction();
        void Action(ActionData _action);
    }
}
