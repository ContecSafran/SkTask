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
    class Recognize : SkTask.Action.Task
    {
        public Recognize()
        {
            //StartKey.Add(Key.LeftAlt);
            StartKey.Add(Key.A);
        }
        public override void Start()
        {
            Log.WriteLog("Recognize 시작");
        }

        public override void End()
        {
            Log.WriteLog("Recognize 종료");
        }
        public override void Process()
        {
            FollowForm.Recognize = true;
        }
    }
}
