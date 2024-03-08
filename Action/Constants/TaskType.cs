using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action.Constants
{
    public enum TaskType
    {
        Task = 0x01,
        NetworkTask = (0x01 << 1),
        QuickTask = (0x01 << 2),
        TimerTask = (0x01 << 3),
        TextTask = (0x01 << 4)
    }
}
