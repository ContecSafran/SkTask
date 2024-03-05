using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkTask.Property
{
    public partial class SettingDlg : Form
    {
        List<SkTask.Action.Task> actions = null;
        Dictionary<String,SkTask.Action.Task> actionItems;
        public SettingDlg(List<SkTask.Action.Task> actions)
        {
            InitializeComponent();
            this.actions = actions;
            if (this.actions != null)
            {
                this.actionItems = new Dictionary<String, SkTask.Action.Task>();
                for (int i = 0; i < this.actions.Count; i++)
                {
                    SkTask.Property.ActionItem item = new SkTask.Property.ActionItem(this.actions[i], true);
                    this.actionItems[this.actions[i].GetType().Name] = this.actions[i];
                    TaskSplitContainer.Panel1.Controls.Add(item);
                }
            }
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            this.StatusPropertyGrid.SelectedObject = SkTask.Setting.Status;

        }
        protected void InitAction()
        {
        }

        private void SettingDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
