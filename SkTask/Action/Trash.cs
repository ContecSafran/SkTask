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
using System.Diagnostics;

namespace SkTask.Action
{
    class Trash : Task
    {
        public List<System.Drawing.Point> Points = new List<System.Drawing.Point>();
        public Trash()
        {
            StartKey.Add(Key.LeftCtrl);
            StartKey.Add(Key.Q);
        }
        public override void Process()
        {
            Random rand = new Random();
            Click(Position.CurrentPosition, InputEvent.LEFT);
            Thread.Sleep(rand.Next(100, 150));
            Move(toPoint(new System.Drawing.PointF(0.30f, 0.30f)));
            Thread.Sleep(rand.Next(100, 150));
            Move(Position.CurrentPosition);
        }
    }
}
