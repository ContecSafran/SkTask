
namespace SkTask.Property
{
    partial class ActionItem
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
            this.NameCheckBox.Location = new System.Drawing.Point(3, 3);
            this.NameCheckBox.Name = "NameCheckBox";
            this.NameCheckBox.Size = new System.Drawing.Size(58, 16);
            this.NameCheckBox.TabIndex = 4;
            this.NameCheckBox.Text = "Name";
            this.NameCheckBox.UseVisualStyleBackColor = true;
            // 
            // ActionItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NameCheckBox);
            this.Name = "ActionItem";
            this.Size = new System.Drawing.Size(273, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox NameCheckBox;
    }
}
