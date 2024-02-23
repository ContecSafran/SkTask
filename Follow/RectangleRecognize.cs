using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace Follow
{
    public class RectangleRecognize
    {
        public static Scalar MaskScalar = new Scalar(0,0,0);
        public static Scalar MaskMaxScalar = new Scalar(0, 0, 0);
        public static Bitmap Process(Bitmap inputBmp)
        {
            
            Mat src = OpenCvSharp.Extensions.BitmapConverter.ToMat(inputBmp);
            ImageProcess(src);

            Mat gray = new Mat();
            Mat binary = new Mat();

            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(gray, binary, 100, 200, ThresholdTypes.Binary);
            Bitmap bmp = BitmapConverter.ToBitmap(binary);
            
            DrawPosition.DrawPoint.Clear();

            return (Bitmap)BitmapConverter.ToBitmap(src).Clone();
        }
        private static void SelectedArea(Mat src, OpenCvSharp.Rect rect)
        {
            int index = Follow.MonitorInfo.SelectMonitor.Index;
            SkTask.Action.Task.Move(
                (Screen.AllScreens[index].Bounds.X + Screen.AllScreens[index].Bounds.Width / 4) + (rect.Left + rect.Width / 2),
                (Screen.AllScreens[index].Bounds.Y + Screen.AllScreens[index].Bounds.Height / 4) + (rect.Top + rect.Height / 2));
            if (FollowForm.FollowClick)
            {
                SkTask.Action.Task.SendKeyDown(SkTask.Action.Task.KeyCode.KEY_T);
            }
            if (FollowForm.DebugDraw)
            {
                DrawPosition.DrawPoint.Add(new OpenCvSharp.Point(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2));
                Cv2.Rectangle(src, rect, Scalar.Red);
            }
        }
        private static void ImageProcess(Mat src)
        {

            Mat[] mv = new Mat[3];
            Mat mask = new Mat();

            Cv2.CvtColor(src, src, ColorConversionCodes.BGR2HSV);
            mv = Cv2.Split(src);
            Cv2.CvtColor(src, src, ColorConversionCodes.HSV2BGR);

            //BGR
            Cv2.InRange(mv[0], RectangleRecognize.MaskScalar, RectangleRecognize.MaskMaxScalar, mask);
            Cv2.BitwiseAnd(src, mask.CvtColor(ColorConversionCodes.GRAY2BGR), src);
        }
    }
}
