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
        public static bool On = false;
        public Thread RecognizeThread
        {
            get;
            set;
        }
        public RecognizeStop()
        {
            StartKey.Add(Key.LeftShift);
            StartKey.Add(Key.A);
        }
        protected override bool isActive()
        {
            if (RecognizeThread == null)
            {
                return On;
            }
            return RecognizeThread.ThreadState != ThreadState.Suspended;
        }
        public override void Start()
        {
            Log.WriteLog("Recognize 종료");
        }
        public override void Process()
        {
            if (RecognizeThread != null)
            {
                RecognizeThread.Suspend();
            }
            Recognize.On = false;
        }
    }
}
