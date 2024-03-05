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
using SkTask.Property;

namespace SkTask.Property
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
            this.Dock = System.Windows.Forms.DockStyle.Top;
        }
    }
}
