
namespace SkSearch
{
    partial class SeachLayout
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
            this.ItemPanel = new System.Windows.Forms.Panel();
            this.PrefixPanel = new System.Windows.Forms.Panel();
            this.SuffixPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.AffixPanel = new System.Windows.Forms.Panel();
            this.SelectPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemPanel
            // 
            this.ItemPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ItemPanel.Location = new System.Drawing.Point(0, 0);
            this.ItemPanel.Name = "ItemPanel";
            this.ItemPanel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ItemPanel.Size = new System.Drawing.Size(176, 608);
            this.ItemPanel.TabIndex = 0;
            // 
            // PrefixPanel
            // 
            this.PrefixPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.PrefixPanel.Location = new System.Drawing.Point(176, 0);
            this.PrefixPanel.Name = "PrefixPanel";
            this.PrefixPanel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.PrefixPanel.Size = new System.Drawing.Size(305, 608);
            this.PrefixPanel.TabIndex = 1;
            // 
            // SuffixPanel
            // 
            this.SuffixPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SuffixPanel.Location = new System.Drawing.Point(481, 0);
            this.SuffixPanel.Name = "SuffixPanel";
            this.SuffixPanel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.SuffixPanel.Size = new System.Drawing.Size(305, 608);
            this.SuffixPanel.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(786, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.SelectPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.AffixPanel);
            this.splitContainer1.Size = new System.Drawing.Size(381, 608);
            this.splitContainer1.SplitterDistance = 71;
            this.splitContainer1.TabIndex = 3;
            // 
            // AffixPanel
            // 
            this.AffixPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AffixPanel.Location = new System.Drawing.Point(0, 0);
            this.AffixPanel.Name = "AffixPanel";
            this.AffixPanel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.AffixPanel.Size = new System.Drawing.Size(381, 533);
            this.AffixPanel.TabIndex = 3;
            // 
            // SelectPanel
            // 
            this.SelectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectPanel.Location = new System.Drawing.Point(0, 0);
            this.SelectPanel.Name = "SelectPanel";
            this.SelectPanel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.SelectPanel.Size = new System.Drawing.Size(381, 71);
            this.SelectPanel.TabIndex = 4;
            // 
            // SeachLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 608);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.SuffixPanel);
            this.Controls.Add(this.PrefixPanel);
            this.Controls.Add(this.ItemPanel);
            this.Name = "SeachLayout";
            this.Text = "SeachLayout";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ItemPanel;
        private System.Windows.Forms.Panel PrefixPanel;
        private System.Windows.Forms.Panel SuffixPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel AffixPanel;
        private System.Windows.Forms.Panel SelectPanel;
    }
}