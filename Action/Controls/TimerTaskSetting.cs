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
        Action.TimerAction.TimerTask TimerTask;
        public TimerTaskSetting(Action.TimerAction.TimerTask timerTask)
        {
            this.TimerTask = timerTask;
            InitializeComponent();

            this.NameCheckBox.Text = timerTask.key.ToString();
        }

        private void NameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TimerTask.Visible = NameCheckBox.Checked;
        }
    }
}
