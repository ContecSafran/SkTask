
namespace SkSearch
{
    partial class SearchItem
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameLabel.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NameLabel.Location = new System.Drawing.Point(0, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.NameLabel.Size = new System.Drawing.Size(107, 29);
            this.NameLabel.TabIndex = 7;
            this.NameLabel.Text = "Name";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NameLabel.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.NameLabel.MouseLeave += new System.EventHandler(this.Control_MouseLeave);
            this.NameLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NameLabel_MouseUp);
            // 
            // SearchItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NameLabel);
            this.Name = "SearchItem";
            this.Size = new System.Drawing.Size(107, 29);
            this.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Control_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
    }
}
