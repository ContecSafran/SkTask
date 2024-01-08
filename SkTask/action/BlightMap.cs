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

namespace SkTask.action
{
    class BlightMap : Action
    {
        public BlightMap()
        {
            StartKey.Add(Key.LeftCtrl);
            StartKey.Add(Key.D3);
        }

        public override void Start()
        {
            Log.WriteLog("Inventory 시작");
        }
        public override void Process()
        {

            Random rand = new Random();

            System.Drawing.Point TopPoint = new System.Drawing.Point(95,700);
            System.Drawing.Point BottomPoint = new System.Drawing.Point(795,957);

            int CountX = 12;
            int CountY = 5;
            int MarginX = (BottomPoint.X - TopPoint.X) / CountX;
            int MarginY = (BottomPoint.Y - TopPoint.Y) / CountY;
            System.Drawing.Point startPoint = Position.CurrentPosition;

            int x = startPoint.X;
            int y = startPoint.Y;
            for (; x < BottomPoint.X; x += MarginX)
            {
                for (; y < BottomPoint.Y; y += MarginY)
                {
                    Click(x,y,InputEvent.LEFT);
                    
                    Thread.Sleep(rand.Next(10, 20));
                    Click(x,y,InputEvent.LEFT);
                    //Log.WriteLog("Inventory :" + x + ", " + y);

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
