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
        public Recognize()
        {
            StartKey.Add(Key.LeftCtrl);
            StartKey.Add(Key.A);
        }
        protected override bool isActive()
        {
            return !Recognize.On;
        }
        public override void Start()
        {
            Log.WriteLog("Recognize 시작");
        }
        public override void Process()
        {
            Recognize.On = true;
        }
    }
}
