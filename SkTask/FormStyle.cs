using SkTask.Property;
using SkTask.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkTask
{
    partial class SkTaskFormBase
    {
        Thread TaskThread = null;
        Thread TimerTaskThread = null;

        private void Form1_Load(object sender, EventArgs e)
        {


            TaskThread = new Thread(MainThread);
            TaskThread.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            TaskThread.Start();

            TimerTaskThread = new Thread(TimerThread);
            TimerTaskThread.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            TimerTaskThread.Start();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            isRunning = false;
        }



    }
}
