using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Action.Controls
{
    public partial class TimerTaskSetting : UserControl
    {
        Action.TimerAction.TimerTask TimerTaskValue;
        public Action.TimerAction.TimerTask TimerTask
        {
            get
            {
                return TimerTaskValue;
            }
            set
            {
                if (value != null)
                {
                    TimerTaskValue = value;
                    NameCheckBox.Checked = TimerTask.Visible;
                    this.NameCheckBox.Text = TimerTask.key.ToString();
                    this.secondTextBox.Text = (TimerTask.Second / 100 * 0.1).ToString();
                }
            }
        }
        public TimerTaskSetting()
        {
            InitializeComponent();
            this.MouseWheel += TimerTaskSetting_MouseWheel;
            this.secondTextBox.MouseWheel += SecondTextBox_MouseWheel;

        }

        private void TimerTaskSetting_MouseWheel(object sender, MouseEventArgs e)
        {
            SecondTextBox_MouseWheel(sender, e);
        }

        private void SecondTextBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta < 0 && TimerTask.Second > 0)
            {
                TimerTask.Second -= 100;
                if(TimerTask.Second <= 0)
                {
                    NameCheckBox.Checked = false;
                    TimerTask.Second = 0;
                }
            }
            else
            {
                if (TimerTask.Second == 0)
                {
                    NameCheckBox.Checked = true;
                }
                TimerTask.Second += 100;
            }
            this.secondTextBox.Text = (TimerTask.Second / 100 * 0.1).ToString();
        }

        private void NameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TimerTask != null)
            {
                TimerTask.Visible = NameCheckBox.Checked;
            }
        }

        private void TimerTaskSetting_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.Control;
        }

        private void TimerTaskSetting_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.ControlDark;

        }

        private void secondTextBox_MouseLeave(object sender, EventArgs e)
        {

            this.BackColor = System.Drawing.SystemColors.Control;
        }

        private void secondTextBox_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.ControlDark;
        }
    }
}
