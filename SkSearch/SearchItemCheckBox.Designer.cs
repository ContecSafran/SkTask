
namespace SkSearch
{
    partial class SearchItemCheckBox
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
            this.NameCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // NameCheckBox
            // 
            this.NameCheckBox.AutoSize = true;
            this.NameCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameCheckBox.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NameCheckBox.Location = new System.Drawing.Point(0, 0);
            this.NameCheckBox.Name = "NameCheckBox";
            this.NameCheckBox.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.NameCheckBox.Size = new System.Drawing.Size(104, 24);
            this.NameCheckBox.TabIndex = 6;
            this.NameCheckBox.Text = "Name";
            this.NameCheckBox.UseVisualStyleBackColor = true;
            this.NameCheckBox.CheckedChanged += new System.EventHandler(this.NameCheckBox_CheckedChanged);
            this.NameCheckBox.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.NameCheckBox.MouseLeave += new System.EventHandler(this.Control_MouseLeave);
            // 
            // SearchItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NameCheckBox);
            this.Name = "SearchItem";
            this.Size = new System.Drawing.Size(104, 24);
            this.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Control_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox NameCheckBox;
    }
}
