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
    public class FollowClick : Task
    {
        public static bool On = false;
        public FollowClick()
        {
            StartKey.Add(Key.D6);
        }

        protected override bool isActive()
        {
            return !FollowClick.On;
        }

        public override void Start()
        {
            Log.WriteLog("FollowClick 시작");
        }

        public override void End()
        {
            Log.WriteLog("FollowClick 종료");
        }
        public override void Process()
        {
            FollowClick.On = true;
        }
    }
}
