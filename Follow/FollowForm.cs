using Action;
using Action.Controls;
using Action.Info;
using Action.Network;
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
    public partial class FollowForm : FormBase
    {
        SkTask.Image image = new SkTask.Image();
        //DrawPosition DrawPosition = new DrawPosition();
        ScreenCapture screenCapture = new ScreenCapture();
        TaskClient taskClient = new TaskClient();
        System.Windows.Forms.ToolStripComboBox comboBox;

        Thread RecognizeThread;
        public FollowForm() : base()
        {
            //Toolstrip에 combo box 넣어두고 모니터 개수 확인해서 넣어두고 창 이동하게 하고 상태 설정 저장
            comboBox = Action.Info.MonitorArea.GetButton();
            comboBox.SelectedIndex = -1;
            comboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged_Monitor);
            AddToolSctipButton(comboBox);
            this.InitializeComponent();
            screenCapture.Init();
            RectangleRecognizePixel.init();
            image.Show();
            taskClient.ClientStart();
        }

        private void SelectedIndexChanged_Monitor(object sender, EventArgs e)
        {
            int SelectedIndex = ((ToolStripComboBox)sender).SelectedIndex;
            Action.Info.MonitorArea.Index = SelectedIndex;

            Action.Info.MonitorArea.OtherIndex = Action.Info.MonitorArea.GetOtherIndex();
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
            this.CommandLog.Location = new System.Drawing.Point(0, 346);
            this.CommandLog.Size = new System.Drawing.Size(353, 119);
            // 
            // MainPanel
            // 
            // 
            // MainPanel.ContentPanel
            // 
            this.MainPanel.ContentPanel.Size = new System.Drawing.Size(353, 346);
            this.MainPanel.Size = new System.Drawing.Size(353, 346);
            // 
            // FollowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(353, 465);
            this.Name = "SkClient";
            this.Load += new System.EventHandler(this.FollowForm_Load);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        private void FollowForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point { X = 0, Y = 0 };
            comboBox.SelectedIndex = Action.Info.MonitorArea.GetProcessIndex();

            this.Hide();
            image.init();
            // DrawPosition.Show();
        }
        void FollowThread()
        {
            while (this.isRunning)
            {
                try
                {
                    Thread.Sleep(200); //minimum CPU usage

                    //if (FollowForm.Recognize)
                    {
                        //기존 OCR 방법으로 검출 하던 방법
                        /*
                        screenCapture.Capture();
                        Bitmap bmp = (Bitmap)screenCapture.bmp.Clone();
                        RectangleRecognizeOcr.Process(bmp);
                        image.InputImage.Image = bmp;*/

                        screenCapture.Capture();
                        //Bitmap bmp = (Bitmap)screenCapture.bmp.Clone();
                        image.InputImage.Image = RectangleRecognizePixel.Process(screenCapture.bmp);
                    }
                }
                catch (Exception e)
                {

                }
            }
        }

        protected override void AddAction()
        {
            RecognizeThread = new Thread(FollowThread);
            RecognizeThread.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            base.AddAction();
            recognizeTask.RecognizeThread = RecognizeThread;
            recognizeStopTask.RecognizeThread = RecognizeThread;
        }

        protected override void MainThreadProcessed()
        {
            int index;
            while (this.taskClient.DataQueue.TryDequeue(out index))
            {
                if (index > 0 && index < NetworkActions.Count) {
                    NetworkActions[index].Process();
                    Thread.Sleep(100);
                }
                else
                {
                    Log.WriteLog("Client Error Index : " + index.ToString());
                }
            }
        }
    }
}
