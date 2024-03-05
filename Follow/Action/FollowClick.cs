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
    class FollowClick : SkTask.Action.Task
    {
        public FollowClick()
        {
            StartKey.Add(Key.D6);
        }

        protected override bool isActive()
        {
            return !FollowForm.FollowClick;
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
            FollowForm.FollowClick = true;
            SkTask.Setting.Status.MouseClick = true;
        }
    }
}
