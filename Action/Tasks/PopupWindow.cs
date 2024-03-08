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
using System.Diagnostics;
using System.Windows.Forms;

namespace Action
{
    public class PopupWindow : Task
    {
        //창이 열려 있으면 true
        //창이 열려진 상태에서 esc키 누르면 다시 tray icon으로 하고
        //그외에 나머지 수행하고 있는데 esc 누르면 취소가 된다
        Form MainWindow = null;
        public event EventHandler.FormViewModeChangedEventHandler ViewModeChanged;
        public static System.Drawing.Point popUpPos;
        public PopupWindow(Form mainWindow)
        {
            MainWindow = mainWindow;
            useMiddleMousebutton = true;
            /*
            StartKey.Add(Key.LeftShift);
            StartKey.Add(Key.LeftCtrl);
            StartKey.Add(Key.S);*/
        }

        public override void Start()
        {
        }
        public override void Process()
        {
            if (!MainWindow.Visible)
            {
                Action.TrayIcon.isOpened = true;
                System.Drawing.Point pt = System.Windows.Forms.Cursor.Position;
                popUpPos = pt;
                MainWindow.Location = pt;
                
                pt.X += (MainWindow.Size.Width - 10);
                pt.Y += 15;
                Click(pt);
                ViewModeChanged(this, true);
            }
        }
    }
}
