using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Action.Tasks;
using SkUtil.Network;
namespace Action
{
    public class ServerLocationMove : NetworkTask
    {
        //0.0102f, 0.2389f

        public ServerLocationMove()
        {
            StartKey.Add(Key.P);
        }

        public override void Process()
        {
            Action.Info.Setting.TrayIcon.Process();
            Action.Tasks.Move.process(0.0102f, 0.2389f);
        }
    }
}
