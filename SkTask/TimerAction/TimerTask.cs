using SkTask.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using SkTask.Constants;
using System.Windows.Input;
using System.Windows;
using System.Windows.Forms;

namespace SkTask.Action
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
