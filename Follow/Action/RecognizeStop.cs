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
    class RecognizeStop : SkTask.Action.Task
    {
        public RecognizeStop()
        {
            StartKey.Add(Key.LeftShift);
            StartKey.Add(Key.A);
        }
        protected override bool isActive()
        {
            return !FollowForm.Recognize;
        }
        public override void Start()
        {
            Log.WriteLog("Recognize 종료");
        }
        public override void Process()
        {
            FollowForm.Recognize = false;
        }
    }
}
