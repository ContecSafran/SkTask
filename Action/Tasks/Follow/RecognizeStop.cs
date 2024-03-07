using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Input;
using System.Windows;
using Action.Controls;

namespace Action
{
    public class RecognizeStop : Task
    {
        public RecognizeStop()
        {
            StartKey.Add(Key.LeftShift);
            StartKey.Add(Key.A);
        }
        protected override bool isActive()
        {
            return Recognize.On;
        }
        public override void Start()
        {
            Log.WriteLog("Recognize 종료");
        }
        public override void Process()
        {
            Recognize.On = false;
        }
    }
}
