using Action.Info;
using Action.TimerAction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Action.Dlg
{
    public partial class TimerTaskSettingDlg : Form
    {
        public TimerTaskSettingDlg()
        {
            InitializeComponent();
            InvalidTimerTaskInfo();
            this.KeyPreview = true;
        }
        private void InvalidTimerTaskInfo()
        {
            Key1TaskSetting.TimerTask = TimerTaskUtil.Num1TimerTask;
            Key2TaskSetting.TimerTask = TimerTaskUtil.Num2TimerTask;
            Key3TaskSetting.TimerTask = TimerTaskUtil.Num3TimerTask;
            Key4TaskSetting.TimerTask = TimerTaskUtil.Num4TimerTask;
            Key5TaskSetting.TimerTask = TimerTaskUtil.Num5TimerTask;

            KeyQTaskSetting.TimerTask = TimerTaskUtil.QTimerTask;
            KeyWTaskSetting.TimerTask = TimerTaskUtil.WTimerTask;
            KeyETaskSetting.TimerTask = TimerTaskUtil.ETimerTask;
            KeyRTaskSetting.TimerTask = TimerTaskUtil.RTimerTask;
            KeyTTaskSetting.TimerTask = TimerTaskUtil.TTimerTask;
        }
        private void Setting_Load(object sender, EventArgs e)
        {
            Setting setting = new Setting();
        }
        protected void InitAction()
        {
        }

        private void SettingDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            TimerTaskUtil.SaveTimerTask(false);
        }

        private void TimerTaskSettingDlg_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            TimerTaskUtil.SaveTimerTask(true);
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            string s = TimerTaskUtil.SelectLoadFile();
            if(s != "")
            {
                TimerTaskUtil.LoadTimerTask(s);

                InvalidTimerTaskInfo();
            }
        }
    }
}
