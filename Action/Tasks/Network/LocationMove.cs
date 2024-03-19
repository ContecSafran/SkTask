using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action.Tasks;
using SkUtil.Network;
namespace Action
{
    public class LocationMove : NetworkTask
    {
        //0.0102f, 0.2389f

        public LocationMove()
        {
            TaskType = Constants.TaskType.NetworkTask;
        }

        public override void Process()
        {
            Action.Tasks.Move.process(0.0102f, 0.2389f);
        }
    }
}
