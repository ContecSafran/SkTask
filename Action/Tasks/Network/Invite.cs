using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkUtil.Network;
namespace Action
{
    public class Invite : NetworkTask
    {
        public Invite()
        {
            TaskType = Constants.TaskType.NetworkTask;
        }
        public override void Process()
        {
        }
    }
}
