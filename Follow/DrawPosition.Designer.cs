
namespace Follow
{
    partial class DrawPosition
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
            this.SelectAreaImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SelectAreaImage)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectAreaImage
            // 
            this.SelectAreaImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectAreaImage.Location = new System.Drawing.Point(0, 0);
            this.SelectAreaImage.Name = "SelectAreaImage";
            this.SelectAreaImage.Size = new System.Drawing.Size(800, 450);
            this.SelectAreaImage.TabIndex = 1;
            this.SelectAreaImage.TabStop = false;
            // 
            // DrawPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SelectAreaImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DrawPosition";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "DrawPosition";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.DrawPosition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SelectAreaImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox SelectAreaImage;
    }
}