using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Input;
using System.Windows;
using Action.Controls;

namespace Action
{
    public class FollowClickStop : Task
    {
        public FollowClickStop()
        {
            StartKey.Add(Key.D7);
        }


        protected override bool isActive()
        {
            return FollowClick.On;
        }

        public override void Start()
        {
            Log.WriteLog("FollowClick 종료");
        }

        public override void End()
        {
        }
        public override void Process()
        {
            FollowClick.On = false;
        }
    }
}
