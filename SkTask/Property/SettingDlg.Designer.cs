
namespace SkTask.Property
{
    partial class SettingDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingDlg));
            this.SettingTab = new System.Windows.Forms.TabControl();
            this.Status = new System.Windows.Forms.TabPage();
            this.StatusPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.TaskPage = new System.Windows.Forms.TabPage();
            this.TaskSplitContainer = new System.Windows.Forms.SplitContainer();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.TimerTaskTab = new System.Windows.Forms.TabPage();
            this.TimerTaskToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.TimerTaskToolStrip = new System.Windows.Forms.ToolStrip();
            this.TimerTaskSplitContainer = new System.Windows.Forms.SplitContainer();
            this.AddTimerTaskStripButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteTimerTaskStripButton = new System.Windows.Forms.ToolStripButton();
            this.SettingTab.SuspendLayout();
            this.Status.SuspendLayout();
            this.TaskPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaskSplitContainer)).BeginInit();
            this.TaskSplitContainer.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.TimerTaskTab.SuspendLayout();
            this.TimerTaskToolStripContainer.ContentPanel.SuspendLayout();
            this.TimerTaskToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.TimerTaskToolStripContainer.SuspendLayout();
            this.TimerTaskToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimerTaskSplitContainer)).BeginInit();
            this.TimerTaskSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingTab
            // 
            this.SettingTab.Controls.Add(this.Status);
            this.SettingTab.Controls.Add(this.TaskPage);
            this.SettingTab.Controls.Add(this.TimerTaskTab);
            this.SettingTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingTab.Location = new System.Drawing.Point(0, 0);
            this.SettingTab.Name = "SettingTab";
            this.SettingTab.SelectedIndex = 0;
            this.SettingTab.Size = new System.Drawing.Size(790, 447);
            this.SettingTab.TabIndex = 0;
            // 
            // Status
            // 
            this.Status.Controls.Add(this.StatusPropertyGrid);
            this.Status.Location = new System.Drawing.Point(4, 22);
            this.Status.Name = "Status";
            this.Status.Padding = new System.Windows.Forms.Padding(3);
            this.Status.Size = new System.Drawing.Size(782, 421);
            this.Status.TabIndex = 0;
            this.Status.Text = "Status";
            this.Status.UseVisualStyleBackColor = true;
            // 
            // StatusPropertyGrid
            // 
            this.StatusPropertyGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.StatusPropertyGrid.Location = new System.Drawing.Point(3, 3);
            this.StatusPropertyGrid.Name = "StatusPropertyGrid";
            this.StatusPropertyGrid.Size = new System.Drawing.Size(256, 415);
            this.StatusPropertyGrid.TabIndex = 0;
            // 
            // TaskPage
            // 
            this.TaskPage.Controls.Add(this.TaskSplitContainer);
            this.TaskPage.Location = new System.Drawing.Point(4, 22);
            this.TaskPage.Name = "TaskPage";
            this.TaskPage.Padding = new System.Windows.Forms.Padding(3);
            this.TaskPage.Size = new System.Drawing.Size(782, 421);
            this.TaskPage.TabIndex = 1;
            this.TaskPage.Text = "Task";
            this.TaskPage.UseVisualStyleBackColor = true;
            // 
            // TaskSplitContainer
            // 
            this.TaskSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.TaskSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.TaskSplitContainer.Name = "TaskSplitContainer";
            this.TaskSplitContainer.Size = new System.Drawing.Size(776, 415);
            this.TaskSplitContainer.SplitterDistance = 223;
            this.TaskSplitContainer.TabIndex = 0;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(790, 422);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(790, 447);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // TimerTaskTab
            // 
            this.TimerTaskTab.Controls.Add(this.TimerTaskToolStripContainer);
            this.TimerTaskTab.Location = new System.Drawing.Point(4, 22);
            this.TimerTaskTab.Name = "TimerTaskTab";
            this.TimerTaskTab.Padding = new System.Windows.Forms.Padding(3);
            this.TimerTaskTab.Size = new System.Drawing.Size(782, 421);
            this.TimerTaskTab.TabIndex = 2;
            this.TimerTaskTab.Text = "TimerTask";
            this.TimerTaskTab.UseVisualStyleBackColor = true;
            // 
            // TimerTaskToolStripContainer
            // 
            // 
            // TimerTaskToolStripContainer.ContentPanel
            // 
            this.TimerTaskToolStripContainer.ContentPanel.Controls.Add(this.TimerTaskSplitContainer);
            this.TimerTaskToolStripContainer.ContentPanel.Size = new System.Drawing.Size(776, 390);
            this.TimerTaskToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimerTaskToolStripContainer.Location = new System.Drawing.Point(3, 3);
            this.TimerTaskToolStripContainer.Name = "TimerTaskToolStripContainer";
            this.TimerTaskToolStripContainer.Size = new System.Drawing.Size(776, 415);
            this.TimerTaskToolStripContainer.TabIndex = 0;
            this.TimerTaskToolStripContainer.Text = "toolStripContainer2";
            // 
            // TimerTaskToolStripContainer.TopToolStripPanel
            // 
            this.TimerTaskToolStripContainer.TopToolStripPanel.Controls.Add(this.TimerTaskToolStrip);
            // 
            // TimerTaskToolStrip
            // 
            this.TimerTaskToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.TimerTaskToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTimerTaskStripButton,
            this.DeleteTimerTaskStripButton});
            this.TimerTaskToolStrip.Location = new System.Drawing.Point(3, 0);
            this.TimerTaskToolStrip.Name = "TimerTaskToolStrip";
            this.TimerTaskToolStrip.Size = new System.Drawing.Size(121, 25);
            this.TimerTaskToolStrip.TabIndex = 0;
            // 
            // TimerTaskSplitContainer
            // 
            this.TimerTaskSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimerTaskSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.TimerTaskSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.TimerTaskSplitContainer.Name = "TimerTaskSplitContainer";
            this.TimerTaskSplitContainer.Size = new System.Drawing.Size(776, 390);
            this.TimerTaskSplitContainer.SplitterDistance = 223;
            this.TimerTaskSplitContainer.TabIndex = 1;
            // 
            // AddTimerTaskStripButton
            // 
            this.AddTimerTaskStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddTimerTaskStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddTimerTaskStripButton.Image")));
            this.AddTimerTaskStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddTimerTaskStripButton.Name = "AddTimerTaskStripButton";
            this.AddTimerTaskStripButton.Size = new System.Drawing.Size(33, 22);
            this.AddTimerTaskStripButton.Text = "Add";
            // 
            // DeleteTimerTaskStripButton
            // 
            this.DeleteTimerTaskStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DeleteTimerTaskStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteTimerTaskStripButton.Image")));
            this.DeleteTimerTaskStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteTimerTaskStripButton.Name = "DeleteTimerTaskStripButton";
            this.DeleteTimerTaskStripButton.Size = new System.Drawing.Size(45, 22);
            this.DeleteTimerTaskStripButton.Text = "Delete";
            // 
            // SettingDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 447);
            this.Controls.Add(this.SettingTab);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "SettingDlg";
            this.Text = "Setting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingDlg_FormClosed);
            this.Load += new System.EventHandler(this.Setting_Load);
            this.SettingTab.ResumeLayout(false);
            this.Status.ResumeLayout(false);
            this.TaskPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TaskSplitContainer)).EndInit();
            this.TaskSplitContainer.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.TimerTaskTab.ResumeLayout(false);
            this.TimerTaskToolStripContainer.ContentPanel.ResumeLayout(false);
            this.TimerTaskToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.TimerTaskToolStripContainer.TopToolStripPanel.PerformLayout();
            this.TimerTaskToolStripContainer.ResumeLayout(false);
            this.TimerTaskToolStripContainer.PerformLayout();
            this.TimerTaskToolStrip.ResumeLayout(false);
            this.TimerTaskToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimerTaskSplitContainer)).EndInit();
            this.TimerTaskSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl SettingTab;
        private System.Windows.Forms.TabPage Status;
        private System.Windows.Forms.PropertyGrid StatusPropertyGrid;
        private System.Windows.Forms.TabPage TaskPage;
        private System.Windows.Forms.SplitContainer TaskSplitContainer;
        private System.Windows.Forms.TabPage TimerTaskTab;
        private System.Windows.Forms.ToolStripContainer TimerTaskToolStripContainer;
        private System.Windows.Forms.SplitContainer TimerTaskSplitContainer;
        private System.Windows.Forms.ToolStrip TimerTaskToolStrip;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripButton AddTimerTaskStripButton;
        private System.Windows.Forms.ToolStripButton DeleteTimerTaskStripButton;
    }
}