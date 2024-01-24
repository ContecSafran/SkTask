
namespace SkTask.Component
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
            this.StartKey = new System.Windows.Forms.Label();
            this.EndKey = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameCheckBox
            // 
            this.NameCheckBox.AutoSize = true;
            this.NameCheckBox.Location = new System.Drawing.Point(3, 3);
            this.NameCheckBox.Name = "NameCheckBox";
            this.NameCheckBox.Size = new System.Drawing.Size(58, 16);
            this.NameCheckBox.TabIndex = 0;
            this.NameCheckBox.Text = "Name";
            this.NameCheckBox.UseVisualStyleBackColor = true;
            this.NameCheckBox.CheckedChanged += new System.EventHandler(this.NameCheckBox_CheckedChanged);
            // 
            // StartKey
            // 
            this.StartKey.AutoSize = true;
            this.StartKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartKey.Location = new System.Drawing.Point(5, 24);
            this.StartKey.Name = "StartKey";
            this.StartKey.Size = new System.Drawing.Size(52, 12);
            this.StartKey.TabIndex = 1;
            this.StartKey.Text = "StartKey";
            // 
            // EndKey
            // 
            this.EndKey.AutoSize = true;
            this.EndKey.Location = new System.Drawing.Point(5, 43);
            this.EndKey.Name = "EndKey";
            this.EndKey.Size = new System.Drawing.Size(49, 12);
            this.EndKey.TabIndex = 2;
            this.EndKey.Text = "EndKey";
            // 
            // ActionItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EndKey);
            this.Controls.Add(this.StartKey);
            this.Controls.Add(this.NameCheckBox);
            this.Name = "ActionItem";
            this.Size = new System.Drawing.Size(273, 60);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox NameCheckBox;
        private System.Windows.Forms.Label StartKey;
        private System.Windows.Forms.Label EndKey;
    }
}
