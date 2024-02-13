using SkTask.Data;
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
        private void init()
        {
            this.PositionList.Visible = this.MouseClickEnableBtn.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            Thread TH = new Thread(MainThread);
            TH.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            TH.Start();
            init();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            isRunning = false;
        }

        private void MouseLogEnableBtn_Click(object sender, EventArgs e)
        {
            MouseLog(!Status.MouseLog);
        }
        private void MouseLog(bool enable)
        {
            MouseLogEnableBtn.Checked = enable;
            PositionList.Visible = enable;
            Status.MouseLog = enable;
        }

        private void MouseClickEnableBtn_Click(object sender, EventArgs e)
        {
            MouseClickEnable(!Status.MouseClick);
        }

        private void MouseClickEnable(bool enable)
        {
            MouseClickEnableBtn.Checked = enable;
            MouseClickEnableBtn.Text = enable ? "Click Enable" : "Click Disable";
            Status.MouseClick = enable;
        }
    }
}
