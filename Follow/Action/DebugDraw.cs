using SkTask.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using SkTask.Constants;
using System.Windows.Input;
using System.Windows;
using SkTask;

namespace Follow.Action
{
    class DebugDraw : SkTask.Action.Task
    {
        public DebugDraw()
        {
            StartKey.Add(Key.LeftCtrl);
            StartKey.Add(Key.D5);
        }

        public override void Start()
        {
            Log.WriteLog("DebugDraw 시작");
        }

        public override void End()
        {
            Log.WriteLog("DebugDraw 종료");
        }
        public override void Process()
        {
            FollowForm.DebugDraw = !FollowForm.DebugDraw;
        }
    }
}
