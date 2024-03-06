using Action.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using Action.Constants;
using System.Windows.Input;
using System.Windows;
using System.Windows.Forms;
using Action.Controls;

namespace Action
{
    class MultiPointMove : Task
    {
        MultiPointInsert insert;
        public MultiPointMove(MultiPointInsert insert)
        {
            this.insert = insert;
            StartKey.Add(Key.LeftAlt);
            StartKey.Add(Key.X);

            EndKey.Add(Key.LeftAlt);
            EndKey.Add(Key.C);
        }
        int CurrentIndex = 0;
        
        public override void Start()
        {
            Log.WriteLog("MultiPointMove 시작");
            MouseDown(InputEvent.RIGHT);
            Sleep(1000);
            SendKeyDown(Action.Task.KeyCode.KEY_D);
        }
        public override void Process()
        {
            if (insert.Points.Count == 0)
            {
                ForcedStop();
            }
            if (CurrentIndex < insert.Points.Count)
            {
                Move(insert.Points[CurrentIndex]);
                Sleep(1000);
                CurrentIndex++;
            }
            else
            {
                CurrentIndex = 0;
            }
        }
        public override void End()
        {
            MouseUp(InputEvent.RIGHT);
            Sleep(1000);
            SendKeyUp(Action.Task.KeyCode.KEY_D);
            Log.WriteLog("MultiPointMove 종료");
        }
    }
}
