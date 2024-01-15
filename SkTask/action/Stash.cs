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

namespace SkTask.Action
{
    class Stash : QuickMove
    {
        public Stash()
        {
            StartKey.Add(Key.LeftCtrl);
            StartKey.Add(Key.D2);
        }


        public override void Start()
        {
            TopPoint = toPoint(new System.Drawing.PointF(0.10f, 0.17f));
            BottomPoint = toPoint(new System.Drawing.PointF(0.50f, 0.57f));
            CountX = 12;
            CountY = 12;
            Log.WriteLog("Stash 시작");
        }
        public override void Process()
        {
            base.Process();
        }


        public override void End()
        {
            Log.WriteLog("Stash 종료");
        }
    }
}
