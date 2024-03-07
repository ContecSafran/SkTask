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
        Mat BackGround;
        public static ConcurrentList<OpenCvSharp.Point> DrawPoint = new ConcurrentList<OpenCvSharp.Point>();
        public DrawPosition()
        {
            DrawPoint.Add(new OpenCvSharp.Point(100, 100));
            InitializeComponent();



        }
        public void ReDraw()
        {
            Mat clone = BackGround.Clone();
           // Cv2.Rectangle(clone, new OpenCvSharp.Rect(0, 0, this.Size.Width, this.Size.Height), Scalar.Red);

            if (DrawPoint.Count() > 0)
            {
                OpenCvSharp.Point pt = DrawPoint.First();
                Cv2.Rectangle(clone, new OpenCvSharp.Rect(pt.X - 50, pt.Y - 20, 100, 40), Scalar.Red);
            }
            this.SelectAreaImage.Image = BitmapConverter.ToBitmap(clone);
        }

        private void DrawPosition_Load(object sender, EventArgs e)
        {
            
            int index = Action.Info.MonitorArea.OtherIndex;
            this.Location = new System.Drawing.Point{
                    X = Screen.AllScreens[index].Bounds.X + Screen.AllScreens[index].Bounds.Width / 4,
                    Y = Screen.AllScreens[index].Bounds.Y + Screen.AllScreens[index].Bounds.Height / 4};
            this.Size = new System.Drawing.Size(Screen.AllScreens[index].Bounds.Size.Width/2, Screen.AllScreens[index].Bounds.Size.Height / 2);

            OpenCvSharp.Size size = new OpenCvSharp.Size(this.Size.Width, this.Size.Height);
            BackGround = new Mat(size, MatType.CV_8UC3);
            Cv2.Rectangle(BackGround, new OpenCvSharp.Rect(new OpenCvSharp.Point(0, 0), size), new Scalar(240, 240, 240), -1);
            ReDraw();
        }
    }
}
