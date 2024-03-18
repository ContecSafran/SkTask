using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using Action.Constants;
using Action.Controls;
using System.Windows.Input;
using System.Windows;
using System.Diagnostics;

namespace Action
{
    public class Alter : Task
    {
        public List<System.Drawing.Point> Points = new List<System.Drawing.Point>();
        public Alter()
        {
            StartKey.Add(Key.D6);
            EndKey.Add(Key.D7);
        }

        public override void Start()
        {
            Log.WriteLog("Alter 시작");
        }
        public override void Process()
        {
            Random rand = new Random();
            //0.0552f, 0.2556f

            Move(toPoint(new System.Drawing.PointF(0.0723f, 0.2819f)));
            Thread.Sleep(rand.Next(50, 55));
            Move(toPoint(new System.Drawing.PointF(0.0552f, 0.2556f)));
            Thread.Sleep(rand.Next(50, 55));
            if ((Keyboard.GetKeyStates(System.Windows.Input.Key.Escape) & KeyStates.Down) > 0)
            {
                ForcedStop();
            }
            Click(toPoint(new System.Drawing.PointF(0.0552f, 0.2556f)), InputEvent.RIGHT);
            Thread.Sleep(rand.Next(50, 55));
            if ((Keyboard.GetKeyStates(System.Windows.Input.Key.Escape) & KeyStates.Down) > 0)
            {
                ForcedStop();
            }
            Move(toPoint(new System.Drawing.PointF(0.1613f, 0.3979f)));
            Thread.Sleep(rand.Next(50, 55));
            Move(toPoint(new System.Drawing.PointF(0.1734f, 0.4250f)));
            Thread.Sleep(rand.Next(50, 55));
            if ((Keyboard.GetKeyStates(System.Windows.Input.Key.Escape) & KeyStates.Down) > 0)
            {
                ForcedStop();
            }
            Click(toPoint(new System.Drawing.PointF(0.1734f, 0.4250f)), InputEvent.LEFT);
            Thread.Sleep(rand.Next(50, 55));
            if ((Keyboard.GetKeyStates(System.Windows.Input.Key.Escape) & KeyStates.Down) > 0)
            {
                ForcedStop();
            }
            SendKeyDown(Action.Task.KeyCode.CONTROL);
            Thread.Sleep(rand.Next(100, 150));
            SendKeyDown(Action.Task.KeyCode.ALT);
            Thread.Sleep(rand.Next(100, 150));
            SendKeyDown(Action.Task.KeyCode.KEY_C);
            Thread.Sleep(rand.Next(100, 150));
            SendKeyUp(Action.Task.KeyCode.CONTROL);
            Thread.Sleep(rand.Next(100, 150));
            SendKeyUp(Action.Task.KeyCode.ALT);
            Thread.Sleep(rand.Next(100, 150));
            SendKeyUp(Action.Task.KeyCode.KEY_C);
            if ((Keyboard.GetKeyStates(System.Windows.Input.Key.Escape) & KeyStates.Down) > 0)
            {
                ForcedStop();
            }
            /*
            string s = (string)Clipboard.GetData(DataFormats.Text);


            bool result = (s.Contains("25% increased effect") || s.Contains("(Tier: 1)"));
            if (result)
            {
                ForcedStop();
            }*/
        }
        public override void End()
        {
            Log.WriteLog("Alter 종료");
            Random rand = new Random();
            SendKeyDown(Action.Task.KeyCode.ALT);
            Thread.Sleep(rand.Next(100, 150));
            SendKeyDown(Action.Task.KeyCode.KEY_D);
            Thread.Sleep(rand.Next(100, 150));
            SendKeyUp(Action.Task.KeyCode.ALT);
            Thread.Sleep(rand.Next(100, 150));
            SendKeyUp(Action.Task.KeyCode.KEY_D);
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("alter.WAV");
            //player.PlaySync();
        }
    }
}
