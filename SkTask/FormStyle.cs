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

        private void Form1_Load(object sender, EventArgs e)
        {


            Thread TH = new Thread(MainThread);
            TH.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            TH.Start();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            isRunning = false;
        }



    }
}
