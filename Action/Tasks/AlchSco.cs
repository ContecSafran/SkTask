﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using Action.Constants;
using System.Windows.Input;
using System.Windows;

namespace Action
{
    public class AlchSco : Task
    {
        public AlchSco()
        {
            StartKey.Add(Key.LeftAlt);
            StartKey.Add(Key.D);
        }
        public override void Process()
        {
            Click(toPoint(new System.Drawing.PointF(0.10f, 0.17f)), InputEvent.RIGHT);
            Sleep(50);
            Click(toPoint(new System.Drawing.PointF(0.10f, 0.17f)), InputEvent.LEFT);
            Sleep(50);

            Click(toPoint(new System.Drawing.PointF(0.10f, 0.17f)), InputEvent.RIGHT);
            Sleep(50);
            Click(toPoint(new System.Drawing.PointF(0.10f, 0.17f)), InputEvent.LEFT);
            Sleep(50);
        }
    }
}