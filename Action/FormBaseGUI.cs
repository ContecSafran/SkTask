using Action.Controls;
using Action.Dlg;
using Action.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Action
{
    public partial class FormBase : Form
    {
        [Obsolete]
        private void Tray_ViewModeChanged(object sender, bool isPopup)
        {
            this.trayicon.Visible = !isPopup;
            this.Visible = isPopup;
            if (isPopup)
            {
                TimerTaskRunning = true;
                // TimerTaskThread.Resume();
            }
            else
            {
                TimerTaskRunning = false;
                // TimerTaskThread.Suspend();
            }
        }

        private void Status_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.PositionList.Visible != Setting.MouseLog)
            {
                this.PositionList.Visible = Setting.MouseLog;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitThread();
            InitForm();
        }

        protected void AddToolSctipButton(ToolStripItem toolStripItem)
        {
            MainToolSctip.Items.Insert(0, toolStripItem);
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            isRunning = false;
        }


        private void FormClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("close?", "close", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MainPanel_TopToolStripPanel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
