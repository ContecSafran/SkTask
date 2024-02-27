using SkUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Follow
{
    public partial class DrawPosition : Form
    {
        Bitmap BackGround;
        public static ConcurrentList<System.Drawing.Point> DrawPoint = new ConcurrentList<System.Drawing.Point>();
        public static System.Drawing.Point targetPoint = new System.Drawing.Point(0, 0);
        public static System.Drawing.Point centerPoint = new System.Drawing.Point(0, 0);
        private static bool update = true;
        Pen targetPen;
        Pen redPen;
        Pen bluePen;
        System.Drawing.SolidBrush targetBrush;
        public DrawPosition()
        {
            InitializeComponent();



        }
        /*
        public void SetPosition(System.Drawing.Point pt)
        {
            if (!pt.Equals(targetPoint))
            {
                targetPoint = pt;
                update = true;
            }
        }*/
        public Bitmap ReDraw(Bitmap inputBmp)
        {
           // Cv2.Rectangle(clone, new OpenCvSharp.Rect(0, 0, this.Size.Width, this.Size.Height), Scalar.Red);

          //  if (update)
            {
               // Bitmap bmp = (Bitmap)Back Ground.Clone();

                using (var graphics = Graphics.FromImage(inputBmp))
                {
                    int cnt = 0;
                    if (DrawPoint.Count > 2)
                    {
                        for (int i = 1; i < DrawPoint.Count; i++)
                        {
                            graphics.DrawLine(bluePen, DrawPoint[i-1], DrawPoint[i]);
                        }
                    }
                    graphics.DrawLine(redPen, targetPoint, centerPoint);

                    graphics.FillRectangle(targetBrush, new Rectangle(targetPoint.X-2, targetPoint.Y-2, 4, 4)); // whatever
                                                                                    // and so on...
                }
                return inputBmp;
                //update = true;
                //this.SelectAreaImage.Image = inputBmp;
            }
        }

        private void DrawPosition_Load(object sender, EventArgs e)
        {
            
            int index = Follow.MonitorInfo.SelectMonitor.Index;
            this.Location = new System.Drawing.Point{
                    X = Screen.AllScreens[index].Bounds.X + Screen.AllScreens[index].Bounds.Width / 4,
                    Y = Screen.AllScreens[index].Bounds.Y + Screen.AllScreens[index].Bounds.Height / 4};
            this.Size = new System.Drawing.Size(Screen.AllScreens[index].Bounds.Size.Width/2, Screen.AllScreens[index].Bounds.Size.Height / 2);
            centerPoint = new Point(this.Size.Width / 2, this.Size.Height / 2);
            BackGround = new Bitmap(Screen.AllScreens[index].Bounds.Size.Width / 2, Screen.AllScreens[index].Bounds.Size.Height / 2);
            using (Graphics graphics = Graphics.FromImage(BackGround))
            {
                using (System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(240, 240, 240)))
                {
                    graphics.FillRectangle(myBrush, new Rectangle(0, 0, 200, 300)); // whatever
                                                                                    // and so on...
                }
            }
            redPen = new Pen(Color.Red, 1);
            bluePen = new Pen(Color.Blue, 1);
            targetPen = new Pen(Color.FromArgb(165, 248, 13), 1);
            targetBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(165, 248, 13));
            //ReDraw();
        }
    }
}
