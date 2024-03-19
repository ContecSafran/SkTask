using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Action.Tasks
{
    public class Move
    {
        public static void process(float targetX, float targetY)
        {
            Random rand = new Random();

            System.Drawing.Point cursorPosition = System.Windows.Forms.Cursor.Position;
            float x = (float)cursorPosition.X / (float)Screen.PrimaryScreen.Bounds.Width;
            float y = (float)cursorPosition.Y / (float)Screen.PrimaryScreen.Bounds.Height;
            //Trace.WriteLine(x.ToString("F4") + "f, " + y.ToString("F4") + "f");
            for (float i = 0.05f; i < 1.0; i += 0.05f)
            {
                float currentX = x + ((targetX - x) * i);
                float currentY = y + ((targetY - y) * i);
                //Trace.WriteLine(currentX.ToString("F4") + "f, " + currentY.ToString("F4") + "f");

                Task.Move(Task.toPoint(new System.Drawing.PointF(currentX, currentY)));
                if ((Keyboard.GetKeyStates(System.Windows.Input.Key.Escape) & KeyStates.Down) > 0)
                {
                    return;
                }
                Thread.Sleep(rand.Next(10, 15));
            }
            Task.Click(Task.toPoint(new System.Drawing.PointF(targetX, targetY)));
            //현재 위치 가져오기
            //중간 값들 찍기
            //중간중간에 Esc 키 누르면 나가기
        }
    }
}
