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
    class DebugDraw : SkTask.Action.Task
    {
        public DebugDraw()
        {
            StartKey.Add(Key.LeftAlt);
            StartKey.Add(Key.D5);
        }
        public override void Process()
        {
            FollowForm.DebugDraw = !FollowForm.DebugDraw;
        }
    }
}
