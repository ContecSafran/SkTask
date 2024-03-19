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
    public class InviteAccept : NetworkTask
    {
        //0.8410f, 0.7222f
        public InviteAccept()
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
            Action.Tasks.Move.process(0.8410f, 0.7222f);
        }
    }
}
