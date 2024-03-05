﻿using SkTask;
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
        DrawPosition DrawPosition = new DrawPosition();
        ScreenCapture screenCapture = new ScreenCapture();
        System.Windows.Forms.ToolStripComboBox comboBox;
        public static bool Recognize = false;
        public static bool FollowMove = false;
        public static bool FollowClick= false;
        public static bool DebugDraw = false;
        public FollowForm() : base()
        {
            //Toolstrip에 combo box 넣어두고 모니터 개수 확인해서 넣어두고 창 이동하게 하고 상태 설정 저장
            comboBox = Follow.MonitorInfo.SelectMonitor.GetButton();
            comboBox.SelectedIndex = -1;
            comboBox.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged_Monitor);
            AddToolSctipButton(comboBox);
            this.InitializeComponent();
            screenCapture.Init();
            RectangleRecognizePixel.init();
            image.Show();
        }

        private void SelectedIndexChanged_Monitor(object sender, EventArgs e)
        {
            int SelectedIndex = ((ToolStripComboBox)sender).SelectedIndex;
            Follow.MonitorInfo.SelectMonitor.Index = SelectedIndex;

            Follow.MonitorInfo.SelectMonitor.OtherIndex = Follow.MonitorInfo.SelectMonitor.GetOtherIndex();
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
            comboBox.SelectedIndex = Follow.MonitorInfo.SelectMonitor.GetProcessIndex();
            
            Thread TH = new Thread(FollowThread);
            TH.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            SkTask.Dto.Status.MouseClick = true;
            TH.Start();
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

                    if (FollowForm.Recognize)
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
            AddAction(new Follow.Action.Recognize());
            AddAction(new Follow.Action.RecognizeStop());
            AddAction(new Follow.Action.FollowClick());
            AddAction(new Follow.Action.FollowClickStop());
        }
    }
}
