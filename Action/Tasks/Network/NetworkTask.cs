using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkUtil.Network;
namespace Action
{
    public class NetworkTask : Task
    {
        public SkServer skServer;
        public override void Process()
        {
            if(skServer == null)
            {
                return;
            }
        }
    }
}
