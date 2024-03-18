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
    public class PcChange : Task
    {

        //창이 열려 있으면 true
        //창이 열려진 상태에서 esc키 누르면 다시 tray icon으로 하고
        //그외에 나머지 수행하고 있는데 esc 누르면 취소가 된다
        Form MainWindow = null;
        TrayIcon trayIcon;
        public PcChange(Form mainWindow, TrayIcon trayIcon, System.Windows.Input.Key key, KeyCode inputKey)
        {
            MainWindow = mainWindow;
            this.trayIcon = trayIcon;
            StartKey.Add(key);
            this.isMenuDraw = false;
            //KeyCode.KEY_1
            EnterKey.Add(new KeyCode[] { KeyCode.CONTROL, KeyCode.ALT, inputKey });

            //this.EnterKey = EnterKey;
            /*
            EnterKey.Add(new KeyCode[] { KeyCode.KEY_T});
            EnterKey.Add(new KeyCode[] { KeyCode.KEY_E });
            EnterKey.Add(new KeyCode[] { KeyCode.KEY_S });
            EnterKey.Add(new KeyCode[] { KeyCode.KEY_T });*/
        }

        public override void Start()
        {
        }
        protected override bool isActive()
        {
            return Action.TrayIcon.isOpened;
        }
        public override void Process()
        {
            if (Action.TrayIcon.isOpened)
            {
                this.trayIcon.Process();
            }
            EnterKeyProcess();
        }
    }
}
