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

namespace Action
{
    public class QuickMove : Task
    {
        public System.Drawing.Point TopPoint;
        public System.Drawing.Point BottomPoint;
        public bool onlyMove = false;

        public bool ManualAction = false;

        public int CountX = 0;
        public int CountY = 0;
        public QuickMove()
        {
            StartKey.Add(Key.LeftCtrl);
        }

        protected override bool isActive()
        {
            ManualAction = true;
            return true;
        }

        public override void Process()
        {

            Random rand = new Random();
            int MarginX = (BottomPoint.X - TopPoint.X) / CountX;
            int MarginY = (BottomPoint.Y - TopPoint.Y) / CountY;
            System.Drawing.Point startPoint = System.Windows.Forms.Cursor.Position;

            int x = startPoint.X;
            int y = startPoint.Y;
            for (; x < BottomPoint.X; x += MarginX)
            {
                for (; y < BottomPoint.Y; y += MarginY)
                {
                    if (onlyMove)
                    {
                        Move(x, y);
                    }
                    else
                    {
                        Click(x, y, InputEvent.LEFT);
                    }
                    //Move(x, y);
                    Thread.Sleep(rand.Next(10, 20));
                    if (onlyMove)
                    {
                        Move(x, y);
                    }
                    else
                    {
                        Click(x, y, InputEvent.LEFT);
                    }

                    if ((!((Keyboard.GetKeyStates(Key.LeftCtrl) & KeyStates.Down) > 0)) && ManualAction)
                    {
                        ManualAction = false;
                        return;
                    }
                }
                y = TopPoint.Y;
            }
        }
    }
}
