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
    class Follow : SkTask.Action.Task
    {
        public Follow()
        {
            StartKey.Add(Key.LeftAlt);
            StartKey.Add(Key.D2);
        }

        public override void Start()
        {
            Log.WriteLog("Follow 시작");
        }

        public override void End()
        {
            Log.WriteLog("Follow 종료");
        }
        public override void Process()
        {
            FollowForm.FollowMove = true;
            
        }
    }
}
