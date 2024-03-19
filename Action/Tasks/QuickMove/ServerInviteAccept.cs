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
    public class ServerInviteAccept : NetworkTask
    {
        //0.8410f, 0.7222f
        //클라이언트가 받는거
        public ServerInviteAccept()
        {
            StartKey.Add(Key.T);
        }
        protected override bool isActive()
        {
            return Action.TrayIcon.isOpened;
        }
        public override void Start()
        {
            Log.WriteLog("InviteAccept 시작");
        }
        public override void Process()
        {
            Action.Info.Setting.TrayIcon.Process();
            Action.Tasks.Move.process(0.8410f, 0.7222f);
        }
    }
}
