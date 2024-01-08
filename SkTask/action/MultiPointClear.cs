using SkTask.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using SkTask.constants;
using System.Windows.Input;
using System.Windows;

namespace SkTask.action
{
    class MultiPointClear : Action
    {
        MultiPointInsert insert;
        public MultiPointClear(MultiPointInsert insert)
        {
            this.insert = insert;
            StartKey.Add(Key.LeftAlt);
            StartKey.Add(Key.V);
        }
        public override void Process()
        {
            insert.Points.Clear();
            Log.WriteLog("MultiPointClear");
            Sleep(1000);
        }
    }
}
