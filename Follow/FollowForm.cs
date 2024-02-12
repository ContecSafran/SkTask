using SkTask;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Follow
{
    public partial class FollowForm : SkTaskFormBase
    {
        SkTask.Image image = new SkTask.Image();
        ScreenCapture screenCapture = new ScreenCapture();
        System.Windows.Forms.ToolStripComboBox comboBox;
        public FollowForm() : base()
        {
            //Toolstrip에 combo box 넣어두고 모니터 개수 확인해서 넣어두고 창 이동하게 하고 상태 설정 저장
            comboBox = Follow.MonitorInfo.SelectMonitor.GetButton();

            comboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged_Monitor);
            AddToolSctipButton(comboBox);
            this.InitializeComponent();
            screenCapture.Init();
            image.Show();
        }

        private void SelectedIndexChanged_Monitor(object sender, EventArgs e)
        {
            int SelectedIndex = ((ToolStripComboBox)sender).SelectedIndex;
            Follow.MonitorInfo.SelectMonitor.index = SelectedIndex;
            this.Location = new Point {
                X = Screen.AllScreens[SelectedIndex].Bounds.Right - this.ClientSize.Width,
                Y = Screen.AllScreens[SelectedIndex].Bounds.Height / 2 - this.ClientSize.Height / 2
            };
        }

        private void InitializeComponent()
        {
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandLog
            // 
            this.CommandLog.Size = new System.Drawing.Size(353, 119);
            // 
            // MainPanel
            // 
            // 
            // MainPanel.ContentPanel
            // 
            this.MainPanel.ContentPanel.Size = new System.Drawing.Size(353, 351);
            this.MainPanel.Size = new System.Drawing.Size(353, 351);
            // 
            // FollowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(353, 470);
            this.Name = "FollowForm";
            this.Load += new System.EventHandler(this.FollowForm_Load);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private void FollowForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point { X = 0, Y = 0 };
            comboBox.SelectedIndex = 1;
            Thread TH = new Thread(FollowThread);
            TH.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            TH.Start();
        }
        void FollowThread()
        {
            while (this.isRunning)
            {
                try
                {


                    Thread.Sleep(40); //minimum CPU usage

                    screenCapture.Capture();
                    image.InputImage.Image = (Bitmap)screenCapture.bmp.Clone();
                    image.OutputImage.Image = FollowImageProcess.Process(screenCapture.bmp);
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
