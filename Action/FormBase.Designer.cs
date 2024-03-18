
using Action.Controls;

namespace Action
{
    partial class FormBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBase));
            this.MainPanel = new System.Windows.Forms.ToolStripContainer();
            this.NetworkList = new System.Windows.Forms.Panel();
            this.QuickList = new System.Windows.Forms.Panel();
            this.SettingList = new System.Windows.Forms.Panel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.BottomSplitContainer = new System.Windows.Forms.SplitContainer();
            this.CommandLog = new Action.Controls.Log();
            this.PositionList = new Action.Controls.Position();
            this.MainToolSctip = new System.Windows.Forms.ToolStrip();
            this.SettingToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.TimerTaskSettingToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.FormClose = new System.Windows.Forms.ToolStripButton();
            this.trayicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MainPanel.ContentPanel.SuspendLayout();
            this.MainPanel.TopToolStripPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BottomSplitContainer)).BeginInit();
            this.BottomSplitContainer.Panel1.SuspendLayout();
            this.BottomSplitContainer.Panel2.SuspendLayout();
            this.BottomSplitContainer.SuspendLayout();
            this.MainToolSctip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BottomToolStripPanelVisible = false;
            // 
            // MainPanel.ContentPanel
            // 
            this.MainPanel.ContentPanel.Controls.Add(this.NetworkList);
            this.MainPanel.ContentPanel.Controls.Add(this.QuickList);
            this.MainPanel.ContentPanel.Controls.Add(this.SettingList);
            this.MainPanel.ContentPanel.Controls.Add(this.BottomPanel);
            this.MainPanel.ContentPanel.Size = new System.Drawing.Size(360, 445);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.LeftToolStripPanelVisible = false;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.RightToolStripPanelVisible = false;
            this.MainPanel.Size = new System.Drawing.Size(360, 470);
            this.MainPanel.TabIndex = 2;
            this.MainPanel.Text = "toolStripContainer1";
            // 
            // MainPanel.TopToolStripPanel
            // 
            this.MainPanel.TopToolStripPanel.Controls.Add(this.MainToolSctip);
            this.MainPanel.TopToolStripPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPanel_TopToolStripPanel_MouseDown);
            // 
            // NetworkList
            // 
            this.NetworkList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NetworkList.Dock = System.Windows.Forms.DockStyle.Left;
            this.NetworkList.Location = new System.Drawing.Point(240, 0);
            this.NetworkList.Name = "NetworkList";
            this.NetworkList.Size = new System.Drawing.Size(120, 345);
            this.NetworkList.TabIndex = 3;
            // 
            // QuickList
            // 
            this.QuickList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.QuickList.Dock = System.Windows.Forms.DockStyle.Left;
            this.QuickList.Location = new System.Drawing.Point(120, 0);
            this.QuickList.Name = "QuickList";
            this.QuickList.Size = new System.Drawing.Size(120, 345);
            this.QuickList.TabIndex = 2;
            // 
            // SettingList
            // 
            this.SettingList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SettingList.Dock = System.Windows.Forms.DockStyle.Left;
            this.SettingList.Location = new System.Drawing.Point(0, 0);
            this.SettingList.Name = "SettingList";
            this.SettingList.Size = new System.Drawing.Size(120, 345);
            this.SettingList.TabIndex = 1;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.BottomSplitContainer);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 345);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(360, 100);
            this.BottomPanel.TabIndex = 0;
            // 
            // BottomSplitContainer
            // 
            this.BottomSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.BottomSplitContainer.Name = "BottomSplitContainer";
            // 
            // BottomSplitContainer.Panel1
            // 
            this.BottomSplitContainer.Panel1.Controls.Add(this.CommandLog);
            // 
            // BottomSplitContainer.Panel2
            // 
            this.BottomSplitContainer.Panel2.Controls.Add(this.PositionList);
            this.BottomSplitContainer.Size = new System.Drawing.Size(360, 100);
            this.BottomSplitContainer.SplitterDistance = 217;
            this.BottomSplitContainer.TabIndex = 0;
            // 
            // CommandLog
            // 
            this.CommandLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommandLog.Location = new System.Drawing.Point(0, 0);
            this.CommandLog.Name = "CommandLog";
            this.CommandLog.Size = new System.Drawing.Size(217, 100);
            this.CommandLog.TabIndex = 1;
            // 
            // PositionList
            // 
            this.PositionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PositionList.Location = new System.Drawing.Point(0, 0);
            this.PositionList.Name = "PositionList";
            this.PositionList.Size = new System.Drawing.Size(139, 100);
            this.PositionList.TabIndex = 0;
            // 
            // MainToolSctip
            // 
            this.MainToolSctip.Dock = System.Windows.Forms.DockStyle.None;
            this.MainToolSctip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MainToolSctip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingToolStripButton,
            this.TimerTaskSettingToolStripButton,
            this.FormClose});
            this.MainToolSctip.Location = new System.Drawing.Point(3, 0);
            this.MainToolSctip.Name = "MainToolSctip";
            this.MainToolSctip.Size = new System.Drawing.Size(72, 25);
            this.MainToolSctip.TabIndex = 0;
            // 
            // SettingToolStripButton
            // 
            this.SettingToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SettingToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SettingToolStripButton.Image")));
            this.SettingToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SettingToolStripButton.Name = "SettingToolStripButton";
            this.SettingToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.SettingToolStripButton.Text = "toolStripButton1";
            this.SettingToolStripButton.Click += new System.EventHandler(this.Setting_Click);
            // 
            // TimerTaskSettingToolStripButton
            // 
            this.TimerTaskSettingToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TimerTaskSettingToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("TimerTaskSettingToolStripButton.Image")));
            this.TimerTaskSettingToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TimerTaskSettingToolStripButton.Name = "TimerTaskSettingToolStripButton";
            this.TimerTaskSettingToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.TimerTaskSettingToolStripButton.Text = "toolStripButton1";
            this.TimerTaskSettingToolStripButton.Click += new System.EventHandler(this.TimerTaskSettingToolStripButton_Click);
            // 
            // FormClose
            // 
            this.FormClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
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
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 470);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBase";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SK";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form_Load);
            this.MainPanel.ContentPanel.ResumeLayout(false);
            this.MainPanel.TopToolStripPanel.ResumeLayout(false);
            this.MainPanel.TopToolStripPanel.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.BottomSplitContainer.Panel1.ResumeLayout(false);
            this.BottomSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BottomSplitContainer)).EndInit();
            this.BottomSplitContainer.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripButton SettingToolStripButton;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.SplitContainer BottomSplitContainer;
        private System.Windows.Forms.Panel SettingList;
        private System.Windows.Forms.Panel QuickList;
        private System.Windows.Forms.Panel NetworkList;
        private System.Windows.Forms.ToolStripButton TimerTaskSettingToolStripButton;
    }
}