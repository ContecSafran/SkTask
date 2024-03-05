namespace SkTask
{
    partial class SkTaskFormBase
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkTaskFormBase));
            this.MainPanel = new System.Windows.Forms.ToolStripContainer();
            this.MainToolSctip = new System.Windows.Forms.ToolStrip();
            this.Setting = new System.Windows.Forms.ToolStripButton();
            this.FormClose = new System.Windows.Forms.ToolStripButton();
            this.trayicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.CommandLog = new SkTask.Log();
            this.PositionList = new SkTask.Position();
            this.MainPanel.TopToolStripPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.MainToolSctip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BottomToolStripPanelVisible = false;
            // 
            // MainPanel.ContentPanel
            // 
            this.MainPanel.ContentPanel.Size = new System.Drawing.Size(125, 326);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.LeftToolStripPanelVisible = false;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.RightToolStripPanelVisible = false;
            this.MainPanel.Size = new System.Drawing.Size(125, 351);
            this.MainPanel.TabIndex = 2;
            this.MainPanel.Text = "toolStripContainer1";
            // 
            // MainPanel.TopToolStripPanel
            // 
            this.MainPanel.TopToolStripPanel.Controls.Add(this.MainToolSctip);
            this.MainPanel.TopToolStripPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPanel_TopToolStripPanel_MouseDown);
            // 
            // MainToolSctip
            // 
            this.MainToolSctip.Dock = System.Windows.Forms.DockStyle.None;
            this.MainToolSctip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MainToolSctip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Setting,
            this.FormClose});
            this.MainToolSctip.Location = new System.Drawing.Point(3, 0);
            this.MainToolSctip.Name = "MainToolSctip";
            this.MainToolSctip.Size = new System.Drawing.Size(49, 25);
            this.MainToolSctip.TabIndex = 0;
            // 
            // Setting
            // 
            this.Setting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Setting.Image = ((System.Drawing.Image)(resources.GetObject("Setting.Image")));
            this.Setting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Setting.Name = "Setting";
            this.Setting.Size = new System.Drawing.Size(23, 22);
            this.Setting.Text = "toolStripButton1";
            this.Setting.Click += new System.EventHandler(this.Setting_Click);
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
            // trayicon
            // 
            this.trayicon.Text = "SkTask";
            this.trayicon.Visible = true;
            // 
            // CommandLog
            // 
            this.CommandLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CommandLog.Location = new System.Drawing.Point(0, 351);
            this.CommandLog.Name = "CommandLog";
            this.CommandLog.Size = new System.Drawing.Size(125, 119);
            this.CommandLog.TabIndex = 1;
            // 
            // PositionList
            // 
            this.PositionList.Dock = System.Windows.Forms.DockStyle.Right;
            this.PositionList.Location = new System.Drawing.Point(125, 0);
            this.PositionList.Name = "PositionList";
            this.PositionList.Size = new System.Drawing.Size(99, 470);
            this.PositionList.TabIndex = 0;
            // 
            // SkTaskFormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 470);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.CommandLog);
            this.Controls.Add(this.PositionList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SkTaskFormBase";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SK";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainPanel.TopToolStripPanel.ResumeLayout(false);
            this.MainPanel.TopToolStripPanel.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.MainToolSctip.ResumeLayout(false);
            this.MainToolSctip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public Position PositionList;
        public Log CommandLog;
        public System.Windows.Forms.ToolStripContainer MainPanel;
        public System.Windows.Forms.ToolStrip MainToolSctip;
        private System.Windows.Forms.ToolStripButton FormClose;
        public System.Windows.Forms.NotifyIcon trayicon;
        private System.Windows.Forms.ToolStripButton Setting;
    }
}

