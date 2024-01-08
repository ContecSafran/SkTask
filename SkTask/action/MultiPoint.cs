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

namespace SkTask.Action
{
    class MultiPoint : Task
    {
        public MultiPoint()
        {
            StartKey.Add(Key.LeftAlt);
            StartKey.Add(Key.D1);

            EndKey.Add(Key.LeftAlt);
            EndKey.Add(Key.D2);
        }
        public override void Process()
        {
            Click(Position.CurrentPosition, InputEvent.RIGHT);
            Sleep(200);
            Click(Position.CurrentPosition, InputEvent.LEFT);
            Sleep(200);
        }
    }
}
