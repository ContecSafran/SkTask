using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using Action.Constants;
using System.Windows.Input;
using System.Windows;
using Action.Info;

namespace Action
{
    public class MouseLog : Task
    {
        public MouseLog()
        {
            StartKey.Add(Key.F6);
        }
        public override void Process()
        {
            Setting.MouseLog = !Setting.MouseLog;
        }
    }
}
