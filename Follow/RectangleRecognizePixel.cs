using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace Follow
{
    public class RectangleRecognizePixel
    {
        static List<System.Drawing.Point> points = new List<System.Drawing.Point>();
        static Pen BluePen = new Pen(Color.Blue, 1);
        static Pen RedPen = new Pen(Color.Red, 1);
        const int AStarCount = 8;
        static bool[] AStarResult = new bool[AStarCount];
        static System.Drawing.Point[] AStarPoints = new System.Drawing.Point[AStarCount];
        public static int CollisionOffset = 10;
        public static void init()
        {
            //초기화 시 인식 경로 생성
            System.Drawing.Point center = SkUtil.Draw.ToCenter(ScreenCapture.ProcessRectangle);
            for (int r = CollisionOffset; r < ScreenCapture.ProcessRectangle.Width/2; r += CollisionOffset)
            {
                for (double angle = 0; angle <= 2 * Math.PI + 0.1f; angle += 0.1)
                {
                    points.Add(new System.Drawing.Point(center.X + (int)(r * Math.Cos(angle)), center.Y + (int)(r * Math.Sin(angle))));
                }
            }
        }
        public static Bitmap Process(Bitmap inputBmp)
        {
            //충돌 픽셀 그리기
            if (points.Count > 2)
            {

                BitmapData sourceData = null;
                try
                {
                    sourceData = inputBmp.LockBits(
                      new Rectangle(0, 0, inputBmp.Width, inputBmp.Height),
                      ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                    using (var graphics = Graphics.FromImage(inputBmp))
                    {
                        for (int i = 1; i <= points.Count - 1; i++)
                        {
                            graphics.DrawLine(BluePen, points[i - 1], points[i]);
                            if (recognizeColor(sourceData, Color.FromArgb(165, 248, 13), points[i]))
                            {
                                List<System.Drawing.Point> AstarResult = AStar(sourceData, Color.FromArgb(165, 248, 13), points[i]);
                                if(AstarResult.Count != 0)
                                {
                                    System.Drawing.Rectangle resultArea = SkUtil.Draw.ToRectangle(AstarResult);
                                    System.Drawing.Point center = System.Drawing.Point.Add(ScreenCapture.CaptureStartPoint,(SkUtil.Draw.ToCenterSize(resultArea)));
                                    resultArea.Inflate(10, 10);

                                    graphics.DrawRectangle(RedPen, resultArea);
                                    center.X -= 100;
                                    center.Y += 100;
                                    for (int move = 0; move < 10; move++)
                                    {
                                        SkTask.Action.Task.Move(center);

                                        center.X += 10;
                                        center.Y -= 10;
                                        Thread.Sleep(10);
                                    }

                                    SkTask.Action.Task.Click(center, SkTask.Constants.InputEvent.LEFT);
                                    break;
                                    //Click 동작 해줌
                                    //종료
                                }
                            }
                        }
                    }
                }
                finally
                {
                    if (sourceData != null)
                        inputBmp.UnlockBits(sourceData);
                }

                return inputBmp;
            }
            return inputBmp;
            //픽셀 충돌 위치 검색
            //픽셀 충돌 위치 기준으로 star 알고리즘을 만들어서 충돌 위치까지 돌아오는 픽셀들의 합을 구한다.
            //충돌 픽셀 범위 계산
            //충돌 픽셀 중간 값 계산
        }

        static unsafe bool recognizeColor(BitmapData sourceData,
                                Color toReplace, System.Drawing.Point currentPt)
        {
            return recognizeColor(sourceData, toReplace, currentPt.X, currentPt.Y);
        }

        static unsafe bool recognizeColor(BitmapData sourceData,
                                Color toReplace, int x, int y)
        {
            const int pixelSize = 4; // 32 bits per pixel
            byte* sourceRow = (byte*)sourceData.Scan0 + (y * sourceData.Stride);
            bool b = (toReplace.R == sourceRow[x * pixelSize + 2] &&
               toReplace.G == sourceRow[x * pixelSize + 1] &&
               toReplace.B == sourceRow[x * pixelSize + 0]);
            return b;
        }
        static List<System.Drawing.Point> AStar(BitmapData sourceData, Color toReplace, System.Drawing.Point currentPt)
        {
            int distanceFlag = 0;
            List<System.Drawing.Point> points = new List<System.Drawing.Point>();
            points.Add(currentPt);

            System.Drawing.Point point = currentPt;
            point = AStarNextPoint(sourceData, toReplace, currentPt);
            while (!point.IsEmpty)
            {
                points.Add(point);
                float distance = SkUtil.MathUtil.DistanceToPoint(currentPt, point);
                //다음꺼 처리 했는데 거리가 CollisionOffset * 20이면 잘못 처리하고있는거다 나와야 한다.
                if(distance > CollisionOffset * 20)
                {
                    points.Clear();
                    return points;
                }
                if (distanceFlag == 0)
                {
                    if(distance > CollisionOffset)
                    {
                        distanceFlag++;
                    }
                }
                if(distanceFlag == 1)
                {
                    if (distance < CollisionOffset)
                    {
                        distanceFlag++;
                    }
                }
                if(distanceFlag == 2)
                {
                    break;
                }
                point = AStarNextPoint(sourceData, toReplace, currentPt);
            }
            return points;
        }
        static System.Drawing.Point AStarNextPoint(BitmapData sourceData, Color toReplace, System.Drawing.Point currentPt)
        {
            for (int moveOffset = 1; moveOffset < CollisionOffset * 10; moveOffset += CollisionOffset)
            {
                for (int i = 0; i < AStarCount; i++)
                {
                    AStarPoints[i] = GetProcessPoint(i, sourceData, currentPt, moveOffset);
                    if (!AStarPoints[i].IsEmpty)
                    {
                        AStarResult[i] = recognizeColor(sourceData, toReplace, AStarPoints[i]);
                    }
                }
                //Astar 알고리즘에 맞는것을 리턴
                for (int i = 0; i < AStarCount; i++)
                {
                    if (i == 0 && (!AStarResult[AStarCount - 1] || !AStarResult[1]) && AStarResult[i])
                    {
                        return AStarPoints[i];
                    }
                    else if (i == AStarCount - 1 && (!AStarResult[AStarCount - 2] || !AStarResult[0]) && AStarResult[i])
                    {
                        return AStarPoints[i];
                    }
                    else if ((!AStarResult[i - 1] || !AStarResult[i + 1]) && AStarResult[i])
                    {
                        return AStarPoints[i];
                    }
                }
                //중간값으로 처리 했으면 범위 넓혀서 다시 처리
            }
            return System.Drawing.Point.Empty;
        }
        static System.Drawing.Point GetProcessPoint(int index, BitmapData sourceData, System.Drawing.Point currentPt, int moveOffset) 
        {
            System.Drawing.Point processPoint = currentPt;
            if(index == 0 || index == 7 || index == 6)
            {
                processPoint.X -= 1; 
            }
            if (index == 2 || index == 3 || index == 4)
            {
                processPoint.X += 1;
            }
            if (index == 0 || index == 1 || index == 2)
            {
                processPoint.Y -= 1;
            }
            if (index == 6 || index == 5 || index == 4)
            {
                processPoint.Y += 1;
            }
            if (processPoint.X < 0 || processPoint.Y < 0 || processPoint.X >= sourceData.Width || processPoint.Y >= sourceData.Height)
            {
                return System.Drawing.Point.Empty;
            }
            return processPoint;
        }
    }
}
