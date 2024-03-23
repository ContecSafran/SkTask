using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Action.Tasks;
using SkUtil.Network;
namespace Action
{
    public class PortalMove : NetworkTask
    {
        //0.0102f, 0.2389f

        public PortalMove()
        {
            TaskType = Constants.TaskType.NetworkTask;
        }

        public override void Process()
        {
            Action.Tasks.Move.process(0.4945f, 0.3972f);
            

        }
    }
}
