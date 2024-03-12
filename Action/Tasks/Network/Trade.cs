using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using SkUtil.Network;
namespace Action
{
    public class Trade : NetworkTask
    {
        Form MainWindow = null;
        public Trade(Form mainWindow)
        {
            MainWindow = mainWindow;
            TaskType = Constants.TaskType.NetworkTask;
            StartKey.Add(Key.D2);
        }
        public override void Process()
        {
            Task.Sleep(10);
            System.Windows.Clipboard.SetText("/invite " + Info.Setting.MainID);
            Task.Sleep(10);
            Click(MainWindow.Location.X-100, MainWindow.Location.Y - 100,Constants.InputEvent.LEFT);
            Task.Sleep(100);
            SendKeyDown(Action.Task.KeyCode.ENTER);
            SendKeyUp(Action.Task.KeyCode.ENTER);
            Task.Sleep(10);
            SendKeyDown(Action.Task.KeyCode.CONTROL);
            Task.Sleep(10);
            SendKeyDown(Action.Task.KeyCode.KEY_V);
            Task.Sleep(10);
            SendKeyUp(Action.Task.KeyCode.CONTROL);
            Task.Sleep(10);
            SendKeyUp(Action.Task.KeyCode.KEY_V);
            Task.Sleep(10);
            SendKeyDown(Action.Task.KeyCode.ENTER);
            SendKeyUp(Action.Task.KeyCode.ENTER);
        }
    }
}
