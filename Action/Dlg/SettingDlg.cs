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
    public partial class SettingDlg : Form
    {
        List<Action.Task> actions = null;
        Dictionary<String, Action.Task> actionItems;
        public SettingDlg(List<Action.Task> actions)
        {
            InitializeComponent();
            this.actions = actions;
            if (this.actions != null)
            {
                this.actionItems = new Dictionary<String, Action.Task>();
                for (int i = 0; i < this.actions.Count; i++)
                {
                    Action.Controls.ActionPropertyItem item = new Action.Controls.ActionPropertyItem(this.actions[i], true);
                    this.actionItems[this.actions[i].GetType().Name] = this.actions[i];
                    TaskSplitContainer.Panel1.Controls.Add(item);
                }
            }
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            

        }
        protected void InitAction()
        {
        }

        private void SettingDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
