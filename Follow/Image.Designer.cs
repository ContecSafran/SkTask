
namespace SkTask
{
    partial class Image
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
            this.InputImage = new System.Windows.Forms.PictureBox();
            this.OutputImage = new System.Windows.Forms.PictureBox();
            this.bScrollbar = new System.Windows.Forms.HScrollBar();
            this.gScrollbar = new System.Windows.Forms.HScrollBar();
            this.rScrollbar = new System.Windows.Forms.HScrollBar();
            this.bScrollbarText = new System.Windows.Forms.TextBox();
            this.gScrollbarText = new System.Windows.Forms.TextBox();
            this.rScrollbarText = new System.Windows.Forms.TextBox();
            this.RLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputImage)).BeginInit();
            this.SuspendLayout();
            // 
            // InputImage
            // 
            this.InputImage.Location = new System.Drawing.Point(12, 12);
            this.InputImage.Name = "InputImage";
            this.InputImage.Size = new System.Drawing.Size(804, 658);
            this.InputImage.TabIndex = 0;
            this.InputImage.TabStop = false;
            // 
            // OutputImage
            // 
            this.OutputImage.Location = new System.Drawing.Point(822, 12);
            this.OutputImage.Name = "OutputImage";
            this.OutputImage.Size = new System.Drawing.Size(981, 656);
            this.OutputImage.TabIndex = 1;
            this.OutputImage.TabStop = false;
            // 
            // bScrollbar
            // 
            this.bScrollbar.Location = new System.Drawing.Point(107, 758);
            this.bScrollbar.Maximum = 255;
            this.bScrollbar.Name = "bScrollbar";
            this.bScrollbar.Size = new System.Drawing.Size(689, 21);
            this.bScrollbar.TabIndex = 2;
            this.bScrollbar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.bScrollbar_Scroll);
            // 
            // gScrollbar
            // 
            this.gScrollbar.Location = new System.Drawing.Point(107, 732);
            this.gScrollbar.Maximum = 255;
            this.gScrollbar.Name = "gScrollbar";
            this.gScrollbar.Size = new System.Drawing.Size(689, 21);
            this.gScrollbar.TabIndex = 3;
            this.gScrollbar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gScrollbar_Scroll);
            // 
            // rScrollbar
            // 
            this.rScrollbar.Location = new System.Drawing.Point(107, 706);
            this.rScrollbar.Maximum = 255;
            this.rScrollbar.Name = "rScrollbar";
            this.rScrollbar.Size = new System.Drawing.Size(689, 21);
            this.rScrollbar.TabIndex = 4;
            this.rScrollbar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.rScrollbar_Scroll);
            // 
            // bScrollbarText
            // 
            this.bScrollbarText.Location = new System.Drawing.Point(37, 758);
            this.bScrollbarText.Name = "bScrollbarText";
            this.bScrollbarText.ReadOnly = true;
            this.bScrollbarText.Size = new System.Drawing.Size(65, 21);
            this.bScrollbarText.TabIndex = 5;
            // 
            // gScrollbarText
            // 
            this.gScrollbarText.Location = new System.Drawing.Point(37, 732);
            this.gScrollbarText.Name = "gScrollbarText";
            this.gScrollbarText.ReadOnly = true;
            this.gScrollbarText.Size = new System.Drawing.Size(65, 21);
            this.gScrollbarText.TabIndex = 6;
            // 
            // rScrollbarText
            // 
            this.rScrollbarText.Location = new System.Drawing.Point(37, 706);
            this.rScrollbarText.Name = "rScrollbarText";
            this.rScrollbarText.ReadOnly = true;
            this.rScrollbarText.Size = new System.Drawing.Size(65, 21);
            this.rScrollbarText.TabIndex = 7;
            // 
            // RLabel
            // 
            this.RLabel.AutoSize = true;
            this.RLabel.Location = new System.Drawing.Point(13, 710);
            this.RLabel.Name = "RLabel";
            this.RLabel.Size = new System.Drawing.Size(13, 12);
            this.RLabel.TabIndex = 8;
            this.RLabel.Text = "R";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 736);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "B";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 762);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "G";
            // 
            // Image
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1815, 788);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RLabel);
            this.Controls.Add(this.rScrollbarText);
            this.Controls.Add(this.gScrollbarText);
            this.Controls.Add(this.bScrollbarText);
            this.Controls.Add(this.rScrollbar);
            this.Controls.Add(this.gScrollbar);
            this.Controls.Add(this.bScrollbar);
            this.Controls.Add(this.OutputImage);
            this.Controls.Add(this.InputImage);
            this.Name = "Image";
            this.Text = "Image";
            this.Load += new System.EventHandler(this.Image_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox InputImage;
        public System.Windows.Forms.PictureBox OutputImage;
        private System.Windows.Forms.HScrollBar bScrollbar;
        private System.Windows.Forms.HScrollBar gScrollbar;
        private System.Windows.Forms.HScrollBar rScrollbar;
        private System.Windows.Forms.TextBox bScrollbarText;
        private System.Windows.Forms.TextBox gScrollbarText;
        private System.Windows.Forms.TextBox rScrollbarText;
        private System.Windows.Forms.Label RLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}