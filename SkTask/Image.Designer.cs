
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
            // Image
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1815, 680);
            this.Controls.Add(this.OutputImage);
            this.Controls.Add(this.InputImage);
            this.Name = "Image";
            this.Text = "Image";
            ((System.ComponentModel.ISupportInitialize)(this.InputImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox InputImage;
        private System.Windows.Forms.PictureBox OutputImage;
    }
}