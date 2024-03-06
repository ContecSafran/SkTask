using Action.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action.Dto
{
    public class Status
    {
        public static Mode mode = Mode.WAITING;
        public static bool MouseLog
        {
            get;
            set;
        }
        public static bool MouseClick
        {
            get;
            set;
        }
    }
}
