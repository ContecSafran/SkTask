
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rMaxScrollbarText = new System.Windows.Forms.TextBox();
            this.gMaxScrollbarText = new System.Windows.Forms.TextBox();
            this.bMaxScrollbarText = new System.Windows.Forms.TextBox();
            this.rMaxScrollbar = new System.Windows.Forms.HScrollBar();
            this.gMaxScrollbar = new System.Windows.Forms.HScrollBar();
            this.bMaxScrollbar = new System.Windows.Forms.HScrollBar();
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
            this.bScrollbar.LargeChange = 1;
            this.bScrollbar.Location = new System.Drawing.Point(107, 758);
            this.bScrollbar.Maximum = 255;
            this.bScrollbar.Minimum = 1;
            this.bScrollbar.Name = "bScrollbar";
            this.bScrollbar.Size = new System.Drawing.Size(689, 21);
            this.bScrollbar.TabIndex = 2;
            this.bScrollbar.Value = 1;
            this.bScrollbar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.bScrollbar_Scroll);
            // 
            // gScrollbar
            // 
            this.gScrollbar.LargeChange = 1;
            this.gScrollbar.Location = new System.Drawing.Point(107, 732);
            this.gScrollbar.Maximum = 255;
            this.gScrollbar.Minimum = 1;
            this.gScrollbar.Name = "gScrollbar";
            this.gScrollbar.Size = new System.Drawing.Size(689, 21);
            this.gScrollbar.TabIndex = 3;
            this.gScrollbar.Value = 1;
            this.gScrollbar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gScrollbar_Scroll);
            // 
            // rScrollbar
            // 
            this.rScrollbar.LargeChange = 1;
            this.rScrollbar.Location = new System.Drawing.Point(107, 706);
            this.rScrollbar.Maximum = 255;
            this.rScrollbar.Minimum = 1;
            this.rScrollbar.Name = "rScrollbar";
            this.rScrollbar.Size = new System.Drawing.Size(689, 21);
            this.rScrollbar.TabIndex = 4;
            this.rScrollbar.Value = 1;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(806, 762);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "G";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(806, 736);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(806, 710);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "R";
            // 
            // rMaxScrollbarText
            // 
            this.rMaxScrollbarText.Location = new System.Drawing.Point(830, 706);
            this.rMaxScrollbarText.Name = "rMaxScrollbarText";
            this.rMaxScrollbarText.ReadOnly = true;
            this.rMaxScrollbarText.Size = new System.Drawing.Size(65, 21);
            this.rMaxScrollbarText.TabIndex = 16;
            // 
            // gMaxScrollbarText
            // 
            this.gMaxScrollbarText.Location = new System.Drawing.Point(830, 732);
            this.gMaxScrollbarText.Name = "gMaxScrollbarText";
            this.gMaxScrollbarText.ReadOnly = true;
            this.gMaxScrollbarText.Size = new System.Drawing.Size(65, 21);
            this.gMaxScrollbarText.TabIndex = 15;
            // 
            // bMaxScrollbarText
            // 
            this.bMaxScrollbarText.Location = new System.Drawing.Point(830, 758);
            this.bMaxScrollbarText.Name = "bMaxScrollbarText";
            this.bMaxScrollbarText.ReadOnly = true;
            this.bMaxScrollbarText.Size = new System.Drawing.Size(65, 21);
            this.bMaxScrollbarText.TabIndex = 14;
            // 
            // rMaxScrollbar
            // 
            this.rMaxScrollbar.LargeChange = 1;
            this.rMaxScrollbar.Location = new System.Drawing.Point(900, 706);
            this.rMaxScrollbar.Maximum = 255;
            this.rMaxScrollbar.Minimum = 1;
            this.rMaxScrollbar.Name = "rMaxScrollbar";
            this.rMaxScrollbar.Size = new System.Drawing.Size(689, 21);
            this.rMaxScrollbar.TabIndex = 13;
            this.rMaxScrollbar.Value = 1;
            this.rMaxScrollbar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.rMaxScrollbar_Scroll);
            // 
            // gMaxScrollbar
            // 
            this.gMaxScrollbar.LargeChange = 1;
            this.gMaxScrollbar.Location = new System.Drawing.Point(900, 732);
            this.gMaxScrollbar.Maximum = 255;
            this.gMaxScrollbar.Minimum = 1;
            this.gMaxScrollbar.Name = "gMaxScrollbar";
            this.gMaxScrollbar.Size = new System.Drawing.Size(689, 21);
            this.gMaxScrollbar.TabIndex = 12;
            this.gMaxScrollbar.Value = 1;
            this.gMaxScrollbar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gMaxScrollbar_Scroll);
            // 
            // bMaxScrollbar
            // 
            this.bMaxScrollbar.LargeChange = 1;
            this.bMaxScrollbar.Location = new System.Drawing.Point(900, 758);
            this.bMaxScrollbar.Maximum = 255;
            this.bMaxScrollbar.Minimum = 1;
            this.bMaxScrollbar.Name = "bMaxScrollbar";
            this.bMaxScrollbar.Size = new System.Drawing.Size(689, 21);
            this.bMaxScrollbar.TabIndex = 11;
            this.bMaxScrollbar.Value = 1;
            this.bMaxScrollbar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.bMaxScrollbar_Scroll);
            // 
            // Image
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1815, 788);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rMaxScrollbarText);
            this.Controls.Add(this.gMaxScrollbarText);
            this.Controls.Add(this.bMaxScrollbarText);
            this.Controls.Add(this.rMaxScrollbar);
            this.Controls.Add(this.gMaxScrollbar);
            this.Controls.Add(this.bMaxScrollbar);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox rMaxScrollbarText;
        private System.Windows.Forms.TextBox gMaxScrollbarText;
        private System.Windows.Forms.TextBox bMaxScrollbarText;
        private System.Windows.Forms.HScrollBar rMaxScrollbar;
        private System.Windows.Forms.HScrollBar gMaxScrollbar;
        private System.Windows.Forms.HScrollBar bMaxScrollbar;
    }
}