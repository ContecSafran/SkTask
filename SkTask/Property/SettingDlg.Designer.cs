
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
            this.SettingTab = new System.Windows.Forms.TabControl();
            this.Status = new System.Windows.Forms.TabPage();
            this.StatusPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.TaskPage = new System.Windows.Forms.TabPage();
            this.TaskSplitContainer = new System.Windows.Forms.SplitContainer();
            this.SettingTab.SuspendLayout();
            this.Status.SuspendLayout();
            this.TaskPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TaskSplitContainer)).BeginInit();
            this.TaskSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingTab
            // 
            this.SettingTab.Controls.Add(this.Status);
            this.SettingTab.Controls.Add(this.TaskPage);
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
            // SettingDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 447);
            this.Controls.Add(this.SettingTab);
            this.Name = "SettingDlg";
            this.Text = "Setting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingDlg_FormClosed);
            this.Load += new System.EventHandler(this.Setting_Load);
            this.SettingTab.ResumeLayout(false);
            this.Status.ResumeLayout(false);
            this.TaskPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TaskSplitContainer)).EndInit();
            this.TaskSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl SettingTab;
        private System.Windows.Forms.TabPage Status;
        private System.Windows.Forms.PropertyGrid StatusPropertyGrid;
        private System.Windows.Forms.TabPage TaskPage;
        private System.Windows.Forms.SplitContainer TaskSplitContainer;
    }
}