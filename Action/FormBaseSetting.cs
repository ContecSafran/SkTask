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
        private void Setting_Click(object sender, EventArgs e)
        {
            ShowSettingDlg(new SettingDlg(this.actions));
        }

        private void TimerTaskSettingToolStripButton_Click(object sender, EventArgs e)
        {
            ShowSettingDlg(new TimerTaskSettingDlg());
        }
        private void ShowSettingDlg(Form form)
        {
            form.Show();
            form.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            form.FormClosed += Setting_FormClosed;
            this.TopMost = false;
            Setting.Mode = Action.Constants.Mode.SETTING;
        }
        private void Setting_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.TopMost = true;
            Setting.Mode = Action.Constants.Mode.WAITING;
        }
    }
}
