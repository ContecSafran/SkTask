namespace SkTask
{
    partial class SkTaskForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkTaskForm));
            this.MainPanel = new System.Windows.Forms.ToolStripContainer();
            this.CommandLog = new SkTask.Log();
            this.PositionList = new SkTask.Position();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.MouseLogEnableBtn = new System.Windows.Forms.ToolStripButton();
            this.MouseClickEnableBtn = new System.Windows.Forms.ToolStripButton();
            this.FormClose = new System.Windows.Forms.ToolStripButton();
            this.MainPanel.ContentPanel.SuspendLayout();
            this.MainPanel.TopToolStripPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BottomToolStripPanelVisible = false;
            // 
            // MainPanel.ContentPanel
            // 
            this.MainPanel.ContentPanel.Controls.Add(this.CommandLog);
            this.MainPanel.ContentPanel.Controls.Add(this.PositionList);
            this.MainPanel.ContentPanel.Size = new System.Drawing.Size(491, 445);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.LeftToolStripPanelVisible = false;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.RightToolStripPanelVisible = false;
            this.MainPanel.Size = new System.Drawing.Size(491, 470);
            this.MainPanel.TabIndex = 2;
            this.MainPanel.Text = "toolStripContainer1";
            // 
            // MainPanel.TopToolStripPanel
            // 
            this.MainPanel.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.MainPanel.TopToolStripPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPanel_TopToolStripPanel_MouseDown);
            // 
            // CommandLog
            // 
            this.CommandLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CommandLog.Location = new System.Drawing.Point(0, 326);
            this.CommandLog.Name = "CommandLog";
            this.CommandLog.Size = new System.Drawing.Size(392, 119);
            this.CommandLog.TabIndex = 1;
            // 
            // PositionList
            // 
            this.PositionList.Dock = System.Windows.Forms.DockStyle.Right;
            this.PositionList.Location = new System.Drawing.Point(392, 0);
            this.PositionList.Name = "PositionList";
            this.PositionList.Size = new System.Drawing.Size(99, 445);
            this.PositionList.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MouseLogEnableBtn,
            this.MouseClickEnableBtn,
            this.FormClose});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(204, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // MouseLogEnableBtn
            // 
            this.MouseLogEnableBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MouseLogEnableBtn.Image = ((System.Drawing.Image)(resources.GetObject("MouseLogEnableBtn.Image")));
            this.MouseLogEnableBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MouseLogEnableBtn.Name = "MouseLogEnableBtn";
            this.MouseLogEnableBtn.Size = new System.Drawing.Size(71, 22);
            this.MouseLogEnableBtn.Text = "Mouse Log";
            this.MouseLogEnableBtn.Click += new System.EventHandler(this.MouseLogEnableBtn_Click);
            // 
            // MouseClickEnableBtn
            // 
            this.MouseClickEnableBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MouseClickEnableBtn.Image = ((System.Drawing.Image)(resources.GetObject("MouseClickEnableBtn.Image")));
            this.MouseClickEnableBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MouseClickEnableBtn.Name = "MouseClickEnableBtn";
            this.MouseClickEnableBtn.Size = new System.Drawing.Size(76, 22);
            this.MouseClickEnableBtn.Text = "Click Enable";
            this.MouseClickEnableBtn.ToolTipText = "Click Enable";
            this.MouseClickEnableBtn.Click += new System.EventHandler(this.MouseClickEnableBtn_Click);
            // 
            // FormClose
            // 
            this.FormClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FormClose.Image = ((System.Drawing.Image)(resources.GetObject("FormClose.Image")));
            this.FormClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormClose.Name = "FormClose";
            this.FormClose.Size = new System.Drawing.Size(23, 22);
            this.FormClose.Text = "X";
            this.FormClose.Click += new System.EventHandler(this.FormClose_Click);
            // 
            // SkTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 470);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SkTaskForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SK";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainPanel.ContentPanel.ResumeLayout(false);
            this.MainPanel.TopToolStripPanel.ResumeLayout(false);
            this.MainPanel.TopToolStripPanel.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public Position PositionList;
        public Log CommandLog;
        public System.Windows.Forms.ToolStripContainer MainPanel;
        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton MouseClickEnableBtn;
        public System.Windows.Forms.ToolStripButton MouseLogEnableBtn;
        private System.Windows.Forms.ToolStripButton FormClose;
    }
}

