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
    class Inventory : QuickMove
    {
        public Inventory()
        {
            StartKey.Add(Key.LeftAlt);
            StartKey.Add(Key.D1);
        }
        public override void Start()
        {
            TopPoint = toPoint(new System.Drawing.PointF(0.40f, 0.17f));
            BottomPoint = toPoint(new System.Drawing.PointF(0.90f, 0.57f));
            CountX = 12;
            CountY = 5;
            Log.WriteLog("Inventory 시작");
        }
        public override void Process()
        {
            base.Process();
        }


        public override void End()
        {
            Log.WriteLog("Inventory 종료");
        }
    }
}
