using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace Follow
{
    public class RectangleRecognize
    {
        public static Scalar MaskScalar = new Scalar(41,1,1);
        public static Scalar MaskMaxScalar = new Scalar(42, 1, 1);
        //ocr thread
        static Tesseract.TesseractEngine tesseractEngine = new Tesseract.TesseractEngine("../resource/tessdata-main", "eng");
        public static Bitmap Process(Bitmap inputBmp)
        {
            inputBmp = ReplaceColor(inputBmp, Color.FromArgb(165, 248, 13), Color.FromArgb(0, 0, 0));
            /*
            for (int i =0; i < inputBmp.Width; i++)
            {
                for(int j = 0; j < inputBmp.Height; j++)
                {
                    if (!inputBmp.GetPixel(i, j).Equals(Color.FromArgb(165, 248, 13)))
                    {
                        inputBmp.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                }
            }
           */ 
            Mat src = OpenCvSharp.Extensions.BitmapConverter.ToMat(inputBmp);
            //ImageProcess(src);
            
            Mat gray = new Mat();
            Mat dest = new Mat();
            Mat binary = new Mat();
            // Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            //Cv2.Threshold(gray, binary, 100, 200, ThresholdTypes.Binary);
            dest = src;
            Bitmap bmp = BitmapConverter.ToBitmap(src);


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

                                    SkTask.Action.Task.Move(
                                        (Screen.AllScreens[index].Bounds.X + Screen.AllScreens[index].Bounds.Width / 4) + (rect.Left + rect.Width / 2),
                                        (Screen.AllScreens[index].Bounds.Y + Screen.AllScreens[index].Bounds.Height / 4) + (rect.Top + rect.Height / 2));

                                    SkTask.Action.Task.Click(
                                        (Screen.AllScreens[index].Bounds.X + Screen.AllScreens[index].Bounds.Width / 4) + (rect.Left + rect.Width / 2),
                                        (Screen.AllScreens[index].Bounds.Y + Screen.AllScreens[index].Bounds.Height / 4) + (rect.Top + rect.Height / 2),
                                        SkTask.Constants.InputEvent.LEFT);
                                }
                               // if (FollowForm.DebugDraw)
                                {
                                    DrawPosition.DrawPoint.Add(new OpenCvSharp.Point(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2));
                                    Cv2.Rectangle(src, rect, Scalar.Red);
                                }

                            }
                        } while (iter.Next(PageIteratorLevel.Word));
                    }
                }
            }
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
        static private unsafe void UsingIterator(Mat image)
        {
            image.ForEachAsVec3b((ptrValue, ptrPosition) =>
            {
                //if((ptrValue->Item0 == 165 && ptrValue->Item1 == 248 && ptrValue->Item2 == 13))
                {
                    ptrValue->Item0 = 255;
                    ptrValue->Item1 = 0;
                    ptrValue->Item2 = 0;
                }
            });
        }
        static unsafe Bitmap ReplaceColor(Bitmap source,
                                  Color toReplace,
                                  Color replacement)
        {
            const int pixelSize = 4; // 32 bits per pixel

            Bitmap target = new Bitmap(
              source.Width,
              source.Height,
              PixelFormat.Format32bppArgb);

            BitmapData sourceData = null, targetData = null;

            int direction = 0;
            DrawPosition.DrawPoint.Clear();
            DrawPosition.targetPoint.X = 0;
            DrawPosition.targetPoint.Y = 0;
            try

                targetData = target.LockBits(
                  new Rectangle(0, 0, target.Width, target.Height),
                  ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                for (int y = 0; y < source.Height; ++y)
                {
                    byte* sourceRow = (byte*)sourceData.Scan0 + (y * sourceData.Stride);
                    byte* targetRow = (byte*)targetData.Scan0 + (y * targetData.Stride);

                    for (int x = 0; x < source.Width; ++x)
                    {
                        byte b = sourceRow[x * pixelSize + 0];
                        byte g = sourceRow[x * pixelSize + 1];
                        byte r = sourceRow[x * pixelSize + 2];
                        byte a = sourceRow[x * pixelSize + 3];

                        if (!(toReplace.R == r && toReplace.G == g && toReplace.B == b))
                        {
                            r = replacement.R;
                            g = replacement.G;
                            b = replacement.B;
                        }

                        targetRow[x * pixelSize + 0] = b;
                        targetRow[x * pixelSize + 1] = g;
                        targetRow[x * pixelSize + 2] = r;
                        targetRow[x * pixelSize + 3] = a;
                                    check = true;
                                    return currentPt;
                                }
                            }
                            break;
                    }
                    if (!area.Contains(currentPt))
                    {
                        break;
                    }
                    if (recognizeColor(sourceData, toReplace, currentPt))
                    {
                        check = true;
                        return currentPt;
                    }
                    if (corner == 2)
                    {
                        move += moveOffset;
                        corner = 0;
                    }
                    DrawPosition.DrawPoint.Add(currentPt);
                    direction++;
                    if(direction == 4)
                    {
                        direction = 0;
                    }
                }
            }
            finally
            {
                if (sourceData != null)
                    source.UnlockBits(sourceData);

                if (targetData != null)
                    target.UnlockBits(targetData);
            }

            return target;
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
