using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action.TimerAction
{
    public class TimerTask : Task
    {
        public string Name
        {
            get;
            set;
        }
        public float second
        {
            get;
            set;
        }
        public System.Windows.Input.Key key
        {
            get;
            set;
        }
        public override void Process()
        {
            base.Process();
        }

    }
}
