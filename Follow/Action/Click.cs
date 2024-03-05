using SkTask;
using SkTask.Constants;
using SkTask.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Follow.Action
{
    class Click : SkTask.Action.Task
    {
        public System.Drawing.Point TopPoint;
        public System.Drawing.Point BottomPoint;

        public int CountX = 0;
        public int CountY = 0;
        public Click()
        {

            SkTask.Setting.Status.MouseClick = true;
            StartKey.Add(Key.LeftCtrl);
            StartKey.Add(Key.A);
            EndKey.Add(Key.LeftCtrl);
            EndKey.Add(Key.D);
        }


        public override void Process()
        {
            if (!((Keyboard.GetKeyStates(Key.LeftCtrl) & KeyStates.Down) > 0))
            {
                

                Thread.Sleep(50);
                return;
            }

            Random rand = new Random();
            System.Drawing.Point startPoint = System.Windows.Forms.Cursor.Position;

            int x = startPoint.X;
            int y = startPoint.Y;
            Click_NoRandom(x, y, InputEvent.LEFT);;
            //Move(x, y);
            Thread.Sleep(rand.Next(10, 20));
            Click_NoRandom(x, y, InputEvent.LEFT);

        }
        
        public override void Start()
        {
            Log.WriteLog("Click 시작");
        }

        public override void End()
        {
            Log.WriteLog("Click 종료");
        }
    }
}
