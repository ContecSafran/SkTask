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
    class QuickMove : Task
    {
        public System.Drawing.Point TopPoint;
        public System.Drawing.Point BottomPoint;

        public int CountX = 0;
        public int CountY = 0;
        public QuickMove()
        {
        }


        public override void Process()
        {

            Random rand = new Random();
            int MarginX = (BottomPoint.X - TopPoint.X) / CountX;
            int MarginY = (BottomPoint.Y - TopPoint.Y) / CountY;
            System.Drawing.Point startPoint = Position.CurrentPosition;

            int x = startPoint.X;
            int y = startPoint.Y;
            for (; x < BottomPoint.X; x += MarginX)
            {
                for (; y < BottomPoint.Y; y += MarginY)
                {
                    Click(x, y, InputEvent.LEFT);
                    //Move(x, y);
                    Thread.Sleep(rand.Next(10, 20));
                    Click(x, y, InputEvent.LEFT);

                    if (!((Keyboard.GetKeyStates(Key.LeftCtrl) & KeyStates.Down) > 0))
                    {
                        return;
                    }
                }
                y = TopPoint.Y;
            }
        }
    }
}
