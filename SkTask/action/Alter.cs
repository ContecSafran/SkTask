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
    class Alter : Task
    {
        public List<System.Drawing.Point> Points = new List<System.Drawing.Point>();
        public Alter()
        {
            StartKey.Add(Key.D6);
            EndKey.Add(Key.D7);
        }
        public override void Process()
        {
            Random rand = new Random();
            //0.0552f, 0.2556f

           // Move(toPoint(new System.Drawing.PointF(0.1734f, 0.4250f)));
            Click(toPoint(new System.Drawing.PointF(0.0552f, 0.2556f)), InputEvent.RIGHT);
            Thread.Sleep(rand.Next(500, 550));
            //0.1734f, 0.4250f

            Move(toPoint(new System.Drawing.PointF(0.1734f, 0.4250f)));
            Thread.Sleep(rand.Next(500, 550));
           // Move(toPoint(new System.Drawing.PointF(0.1734f, 0.4250f)));
            Click(toPoint(new System.Drawing.PointF(0.1734f, 0.4250f)), InputEvent.LEFT);
            Thread.Sleep(rand.Next(500, 550));

            SendKeyDown(SkTask.Action.Task.KeyCode.CONTROL);
            Thread.Sleep(rand.Next(100, 150));
            SendKeyDown(SkTask.Action.Task.KeyCode.ALT);
            Thread.Sleep(rand.Next(100, 150));
            SendKeyDown(SkTask.Action.Task.KeyCode.KEY_C);
            Thread.Sleep(rand.Next(100, 150));
            SendKeyUp(SkTask.Action.Task.KeyCode.CONTROL);
            Thread.Sleep(rand.Next(100, 150));
            SendKeyUp(SkTask.Action.Task.KeyCode.ALT);
            Thread.Sleep(rand.Next(100, 150));
            SendKeyUp(SkTask.Action.Task.KeyCode.KEY_C);
            string s = (string)Clipboard.GetData(DataFormats.Text);

            bool result = (s.Contains("25% increased effect") || s.Contains("(Tier: 1)"));
            if (result)
            {
                ForcedStop();
            }
        }
        public override void End()
        {
            Random rand = new Random();
            SendKeyDown(SkTask.Action.Task.KeyCode.ALT);
            Thread.Sleep(rand.Next(100, 150));
            SendKeyDown(SkTask.Action.Task.KeyCode.KEY_D);
            Thread.Sleep(rand.Next(100, 150));
            SendKeyUp(SkTask.Action.Task.KeyCode.ALT);
            Thread.Sleep(rand.Next(100, 150));
            SendKeyUp(SkTask.Action.Task.KeyCode.KEY_D);
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("alter.WAV");
            player.PlaySync();
        }
    }
}
