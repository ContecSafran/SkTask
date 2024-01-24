using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SkTask.Action;
using SkTask.Data;

namespace SkTask.Component
{
    public partial class ActionItem : UserControl
    {
        SkTask.Action.Task action;
        public ActionItem()
        {
            InitializeComponent();
        }
        public ActionItem(SkTask.Action.Task action, bool active)
        {
            InitializeComponent();
            this.action = action;
            this.NameCheckBox.Text = action.GetType().Name;
            this.Name = action.GetType().Name;
            this.StartKey.Text = toString(action.StartKey);
            this.EndKey.Text = toString(action.EndKey);
            this.Dock = System.Windows.Forms.DockStyle.Top;
            NameCheckBox.Checked = ActionItemVisible.get(this.Name);
            setControlSize();
            action.actionItem = this;
        }
        public bool isActive()
        {
            return NameCheckBox.Checked;
        }
        private string toString(List<System.Windows.Input.Key> keys)
        {
            string s = "";
            for (int i = 0; i < keys.Count; i++)
            {
                s += keys[i].ToString();
                if (i < keys.Count - 1)
                {
                    s += " + ";
                }
            }
            return s;
        }

        private void NameCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ActionItemVisible.set(this.Name, isActive());
            setControlSize();
        }
        private void setControlSize()
        {

            if (isActive())
            {

                this.Size = new System.Drawing.Size(273, action.EndKey.Count != 0 ? 60 : 40);
            }
            else
            {
                this.Size = new System.Drawing.Size(273, 20);
            }
        }
    }
}
