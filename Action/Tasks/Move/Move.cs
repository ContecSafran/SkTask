using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action.Tasks
{
    public class Move
    {

        public System.Drawing.Point point
        {
            get;
            set;
        }
        public void process()
        {
            Task.Move(point);
        }
    }
}
