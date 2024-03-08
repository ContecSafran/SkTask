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
    public partial class ActionItem : UserControl
    {
        Action.Task action;
        public ActionItem()
        {
            InitializeComponent();
        }
        public ActionItem(Action.Task action, bool active)
        {
            InitializeComponent();
            this.action = action;
            this.NameLabel.Text = action.GetType().Name;
            this.Name = action.GetType().Name;
            this.StartKey.Text = toString(action.StartKey);
            this.EndKey.Text = toString(action.EndKey);
            this.Dock = System.Windows.Forms.DockStyle.Top;
            setControlSize();
            action.actionItem = this;
            for (int i = 0; i < Controls.Count; i++)
            {
                Controls[i].Click += ActionItem_Click;
                Controls[i].MouseLeave += new System.EventHandler(this.ActionItem_MouseLeave);
                Controls[i].MouseEnter += new System.EventHandler(this.ActionItem_MouseEnter);
            }
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

        private void setControlSize()
        {
            int y = 20 + (action.StartKey.Count > 0 ? 15 : 0) + (action.EndKey.Count > 0 ? 15 : 0);
            
            this.Size = new System.Drawing.Size(273, y);
        }


        private void ActionItem_Click(object sender, EventArgs e)
        {
            Task.ProcessTask.Enqueue(action);
        }


        private void ActionItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.Control;
        }


        private void ActionItem_MouseEnter(object sender, EventArgs e)
        {

            this.BackColor = System.Drawing.SystemColors.ControlDark;
        }
    }
}
