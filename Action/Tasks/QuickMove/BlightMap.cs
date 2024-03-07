using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using Action.Constants;
using System.Windows.Input;
using System.Windows;
using Action.Controls;

namespace Action
{
    public class BlightMap : QuickMove
    {
        public BlightMap()
        {
            StartKey.Add(Key.LeftCtrl);
            StartKey.Add(Key.D3);
        }

        public override void Start()
        {
            TopPoint = toPoint(new System.Drawing.PointF(0.40f, 0.17f));
            BottomPoint = toPoint(new System.Drawing.PointF(0.90f, 0.57f));
            CountX = 12;
            CountY = 5;
            Log.WriteLog("BlightMap 시작");
        }
        public override void Process()
        {
            base.Process();
        }


        public override void End()
        {
            Log.WriteLog("BlightMap 종료");
        }
    }
}
