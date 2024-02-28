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
    public class FollowImageProcess
    {

        static List<string> SearchList = new List<string>() { "Wayne", "Wayn", "ayne", "Way", "ayn", "yne", "wayne", "wayn" };

        //ocr thread
        static Tesseract.TesseractEngine tesseractEngine = new Tesseract.TesseractEngine("../resource/tessdata-main", "eng");
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

            int index = Follow.MonitorInfo.SelectMonitor.Index;
            using (var img = PixConverter.ToPix((Bitmap)bmp))
            {

                using (var page = tesseractEngine.Process(img))
                {
                    //var str = page.GetText();
                    using (var iter = page.GetIterator())
                    {
                        iter.Begin();
                        do
                        {
                            Tesseract.Rect symbolBounds;
                            if (iter.TryGetBoundingBox(PageIteratorLevel.Word, out symbolBounds))
                            {
                                // do whatever you want with bounding box for the symbol
                                var curText = iter.GetText(PageIteratorLevel.Word);
                                OpenCvSharp.Rect rect = new OpenCvSharp.Rect(symbolBounds.X1, symbolBounds.Y1, symbolBounds.Width, symbolBounds.Height);
                                if (FollowForm.FollowMove)
                                {

                                    //Wayne
                                    //Wayn
                                    //ayne
                                    //Way
                                    //ayn
                                    //yne
                                    //확인해서 검출
                                    string s = SearchList.Find(x => curText.Contains(x));
                                    if(s != null)
                                    {
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
                                }

                            }
                        } while (iter.Next(PageIteratorLevel.Word));
                    }
                }
            }
            return (Bitmap)BitmapConverter.ToBitmap(src).Clone();
        }
        private static void ImageProcess(Mat src)
        {

            Mat[] mv = new Mat[3];
            Mat mask = new Mat();

            Cv2.CvtColor(src, src, ColorConversionCodes.BGR2HSV);
            mv = Cv2.Split(src);
            Cv2.CvtColor(src, src, ColorConversionCodes.HSV2BGR);

            Cv2.InRange(mv[0], RectangleRecognizeOcr.MaskScalar, RectangleRecognizeOcr.MaskMaxScalar, mask);
            Cv2.BitwiseAnd(src, mask.CvtColor(ColorConversionCodes.GRAY2BGR), src);
        }
    }
}
