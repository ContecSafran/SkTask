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
    public class Recognize : Task
    {
        public static bool On = false;
        public Thread RecognizeThread
        {
            get;
            set;
        }
        public Recognize()
        {
            StartKey.Add(Key.LeftCtrl);
            StartKey.Add(Key.A);
            TaskType = Constants.TaskType.NetworkTask;
        }
        protected override bool isActive()
        {
            if(RecognizeThread == null)
            {
                return !On;
            }
            return (RecognizeThread.ThreadState == ThreadState.Suspended) || (RecognizeThread.ThreadState == ThreadState.Unstarted);
        }
        public override void Start()
        {
            Log.WriteLog("Recognize 시작");
        }

        public override void Process()
        {
            if (RecognizeThread != null)
            {
                if (!RecognizeThread.IsAlive)
                {
                    RecognizeThread.Start();
                }
                else if(RecognizeThread.ThreadState == ThreadState.Suspended)
                {
                    RecognizeThread.Resume();
                }
            }
            Action.TimerAction.TimerTaskUtil.Running = true;
            Recognize.On = true;
        }
    }
}
