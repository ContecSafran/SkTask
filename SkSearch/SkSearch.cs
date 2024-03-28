using Action;
using Action.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkSearch
{
    public partial class SkSearch : FormBase
    {
        TaskClient taskClient = new TaskClient();
        public SkSearch()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PositionList
            // 
            this.PositionList.Size = new System.Drawing.Size(139, 100);
            // 
            // CommandLog
            // 
            this.CommandLog.Size = new System.Drawing.Size(217, 100);
            // 
            // MainPanel
            // 
            // 
            // MainPanel.ContentPanel
            // 
            this.MainPanel.ContentPanel.Size = new System.Drawing.Size(360, 465);
            this.MainPanel.Size = new System.Drawing.Size(360, 465);
            // 
            // FollowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(360, 465);
            this.Name = "FollowForm";
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        protected override void Form_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        protected override void InitForm()
        {
            base.InitForm();
            Action.Info.Setting.IsServer = false;
            this.InitializeComponent();
            taskClient.ClientStart();
        }
        protected override void AddAction()
        {
            AddAction(new Action.Alter());
            base.AddAction();
        }
    }
}
