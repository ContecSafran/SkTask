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

namespace Follow.Action
{
    class FollowStop : SkTask.Action.Task
    {
        public FollowStop()
        {
            StartKey.Add(Key.LeftCtrl);
            StartKey.Add(Key.D4);
        }
        public override void Process()
        {
            FollowForm.Recognize = false;
            FollowForm.FollowMove = false;
        }
    }
}
