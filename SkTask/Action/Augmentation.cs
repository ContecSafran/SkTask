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
    class Augmentation : Task
    {
        public Augmentation()
        {
            StartKey.Add(Key.LeftShift);
            StartKey.Add(Key.S);
        }
        public override void Process()
        {
            Click(toPoint(new System.Drawing.PointF(0.10f, 0.17f)), InputEvent.RIGHT);
            Sleep(50);
            Click(toPoint(new System.Drawing.PointF(0.10f, 0.17f)), InputEvent.LEFT);
            Sleep(50);
        }
    }
}
