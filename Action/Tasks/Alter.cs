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

            EnterKey.Add(new KeyCode[] { KeyCode.CONTROL, KeyCode.ALT, KeyCode.KEY_C });
        }

        public override void Start()
        {
            Log.WriteLog("Alter 시작");
        }
        public override void Process()
        {
            Random rand = new Random();
            Action.Tasks.Move.process(0.0552f, 0.2556f, InputEvent.RIGHT);
            Action.Tasks.Move.process(0.1734f, 0.4250f);
            EnterKeyProcess();

            /*
            string s = (string)Clipboard.GetData(DataFormats.Text);


            bool result = (s.Contains("25% increased effect") || s.Contains("(Tier: 1)"));
            if (result)
            {
                ForcedStop();
            }*/
        }
        public override void End()
        {/*
            Log.WriteLog("Alter 종료");
            Random rand = new Random();
            SendKeyDown(Action.Task.KeyCode.ALT);
            Thread.Sleep(rand.Next(100, 150));
            SendKeyDown(Action.Task.KeyCode.KEY_D);
            Thread.Sleep(rand.Next(100, 150));
            SendKeyUp(Action.Task.KeyCode.ALT);
            Thread.Sleep(rand.Next(100, 150));
            SendKeyUp(Action.Task.KeyCode.KEY_D);
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("alter.WAV");*/
            //player.PlaySync();
        }
    }
}
