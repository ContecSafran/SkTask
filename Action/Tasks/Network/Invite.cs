using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Action.Controls;
using SkUtil.Network;
namespace Action
{
    public class Invite : NetworkTask
    {
        public Invite()
        {
            TaskType = Constants.TaskType.NetworkTask;
            StartKey.Add(Key.D1);
        }
        public override void Start()
        {
            Log.WriteLog("Invite 시작");
        }
        public override void Process()
        {
            Task.Sleep(10);
            Clipboard.SetText("/invite " + Info.Setting.MainID);
            Task.Sleep(10);
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
