using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static bool check = false;
        public static void Process(Bitmap inputBmp)
        {
            check = false;
            DrawPosition.targetPoint = ReplaceColor(inputBmp, Color.FromArgb(165, 248, 13), Color.FromArgb(0, 0, 0));
            if (check)
            {

                int index = Follow.MonitorInfo.SelectMonitor.Index;
                SkTask.Action.Task.Click(
                    (Screen.AllScreens[index].Bounds.X + Screen.AllScreens[index].Bounds.Width / 4) + DrawPosition.targetPoint.X,
                    (Screen.AllScreens[index].Bounds.Y + Screen.AllScreens[index].Bounds.Height / 4) + DrawPosition.targetPoint.Y,
                    SkTask.Constants.InputEvent.LEFT);
                //SkTask.Action.Task.Click(DrawPosition.targetPoint, SkTask.Constants.InputEvent.LEFT);
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
        static unsafe System.Drawing.Point ReplaceColor(Bitmap source,
                                  Color toReplace,
                                  Color replacement)
        {
            const int pixelSize = 4; // 32 bits per pixel

            BitmapData sourceData = null, targetData = null;
            int corner = 0;//2회씩 2배수로 꺽는다
            int moveOffset = 4;
            int move = 2;
            int direction = 0;
            DrawPosition.DrawPoint.Clear();
            DrawPosition.targetPoint.X = 0;
            DrawPosition.targetPoint.Y = 0;
            try
            {
                sourceData = source.LockBits(
                  new Rectangle(0, 0, source.Width, source.Height),
                  ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                System.Drawing.Point currentPt = new System.Drawing.Point(source.Width / 2, source.Height / 2);
                DrawPosition.DrawPoint.Add(currentPt);
                GraphicsUnit pageUnit = GraphicsUnit.Pixel;
                RectangleF area = new RectangleF(moveOffset, moveOffset, source.Width- moveOffset, source.Height- moveOffset);//source.GetBounds(ref pageUnit);
                while (area.Contains(currentPt))
                {
                    corner++;
                    switch(direction)
                    {
                        case 0:
                            for (int offset = 0; offset <= move; offset += 5)
                            {
                                currentPt.X += moveOffset;
                                DrawPosition.DrawPoint.Add(currentPt);
                                if (recognizeColor(sourceData, toReplace, currentPt))
                                {
                                    check = true;
                                    return currentPt;
                                }
                            }
                            break;
                        case 1:
                            for (int offset = 0; offset <= move; offset += 5)
                            {
                                currentPt.Y -= moveOffset;
                                DrawPosition.DrawPoint.Add(currentPt);
                                if (recognizeColor(sourceData, toReplace, currentPt))
                                {
                                    check = true;
                                    return currentPt;
                                }
                            }
                            break;
                        case 2:
                            for (int offset = 0; offset <= move; offset += 5)
                            {
                                currentPt.X -= moveOffset;
                                DrawPosition.DrawPoint.Add(currentPt);
                                if (recognizeColor(sourceData, toReplace, currentPt))
                                {
                                    check = true;
                                    return currentPt;
                                }
                            }
                            break;
                        case 3:
                            for (int offset = 0; offset <= move; offset += 5)
                            {
                                currentPt.Y += moveOffset;
                                DrawPosition.DrawPoint.Add(currentPt);
                                if (recognizeColor(sourceData, toReplace, currentPt))
                                {
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
            }
            return new System.Drawing.Point(source.Width / 2, source.Height/2);

        }
        static unsafe bool recognizeColor(BitmapData sourceData,
                                Color toReplace, System.Drawing.Point currentPt)
        {
            const int pixelSize = 4; // 32 bits per pixel
            byte* sourceRow = (byte*)sourceData.Scan0 + (currentPt.Y * sourceData.Stride);
            bool b = (toReplace.R == sourceRow[currentPt.X * pixelSize + 2] &&
               toReplace.G == sourceRow[currentPt.X * pixelSize + 1] &&
               toReplace.B == sourceRow[currentPt.X * pixelSize + 0]);
            return b;
        }
    }

}
