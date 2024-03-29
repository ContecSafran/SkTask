﻿using SkTask.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using SkTask.constants;
using System.Windows.Input;
using System.Windows;
using System.Diagnostics;

namespace SkTask.action
{
    class MultiPointInsert : Action
    {
        public List<System.Drawing.Point> Points = new List<System.Drawing.Point>();
        public MultiPointInsert()
        {
            StartKey.Add(Key.LeftAlt);
            StartKey.Add(Key.Z);
        }
        public override void Process()
        {
            if (!Points.Contains(Position.CurrentPosition))
            {
                Points.Add(Position.CurrentPosition);
                Log.WriteLog("MultiPointInsert :" + Position.CurrentPosition.X + ", " + Position.CurrentPosition.Y);
                Sleep(1000);
            }
        }
    }
}
