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
    public class TradeCheck : QuickMove
    {
        public TradeCheck()
        {
            StartKey.Add(Key.LeftCtrl);
            StartKey.Add(Key.D9);
            this.onlyMove = true;
        }
        public override void Start()
        {
            TopPoint = toPoint(new System.Drawing.PointF(0.67f, 0.57f));
            BottomPoint = toPoint(new System.Drawing.PointF(0.983f, 0.7874f));
            CountX = 12;
            CountY = 5;
            Log.WriteLog("TradeCheck 시작");
        }
        public override void Process()
        {
            base.Process();
        }


        public override void End()
        {
            Log.WriteLog("TradeCheck 종료");
        }
    }
}
