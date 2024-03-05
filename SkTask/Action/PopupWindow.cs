﻿using SkTask.Dto;
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
    public class PopupWindow : Task
    {
        //창이 열려 있으면 true
        //창이 열려진 상태에서 esc키 누르면 다시 tray icon으로 하고
        //그외에 나머지 수행하고 있는데 esc 누르면 취소가 된다
        SkTaskFormBase MainWindow = null;
        public PopupWindow(SkTaskFormBase mainWindow)
        {
            MainWindow = mainWindow;
            StartKey.Add(Key.LeftShift);
            StartKey.Add(Key.LeftCtrl);
            StartKey.Add(Key.S);
        }

        public override void Start()
        {
        }
        public override void Process()
        {
            if (!MainWindow.Visible)
            {
                MainWindow.Visible = true;
                MainWindow.trayicon.Visible = false;
                SkTask.Action.TrayIcon.isOpened = true;
                MainWindow.Location = System.Windows.Forms.Cursor.Position;
            }
        }
    }
}
