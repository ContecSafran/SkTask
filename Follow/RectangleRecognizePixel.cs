using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Follow
{
    public class RectangleRecognizePixel
    {
        //아이템 필터
        //static Color RecognizeColor = Color.FromArgb(165, 248, 13);
        //follow 녹색
        //static Color RecognizeColor = Color.FromArgb(98, 249, 98);
        //보라색
        static Color RecognizeColor = Color.FromArgb(150,150,249);
        //static Color RecognizeColor = Col5ㄳor.FromArgb(0, 0, 0);
        static List<System.Drawing.Point> points = new List<System.Drawing.Point>();
        static Pen BluePen = new Pen(Color.Blue, 1);
        static Pen YellowPen = new Pen(Color.Yellow, 2);
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
        public static void Click() {
            Action.Task.Click(Cursor.Position);
        }
        public static Bitmap Process(Bitmap inputBmp)
        {

            
            
            //List<System.Drawing.Point> AstarResult = null;
            Rectangle RecognizeResult = Rectangle.Empty;
            //충돌 픽셀 그리기
            if (points.Count > 2)
            {

                BitmapData sourceData = null;
                try
                {
                    sourceData = inputBmp.LockBits(
                      new Rectangle(0, 0, inputBmp.Width, inputBmp.Height),
                      ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                    for (int i = 1; i <= points.Count - 1; i++)
                    {
                        if (recognizeColor(sourceData, RecognizeColor, points[i]))
                        {
                            RecognizeResult = GetBoundary(sourceData, RecognizeColor, points[i]);
                            /*
                            AstarResult = AStar(sourceData, RecognizeColor, points[i]);
                            if (AstarResult.Count > 1)
                            {
                                break;
                            }*/
                        }
                    }
                }
                finally
                {
                    if (sourceData != null)
                        inputBmp.UnlockBits(sourceData);
                }
                if (RecognizeResult.IsEmpty)
                {
                    Action.Task.Move(Cursor.Position);
                    return inputBmp;
                }
                /*
                if(AstarResult == null)
                {
                    return inputBmp;
                }*/
                using (var graphics = Graphics.FromImage(inputBmp))
                {
                    for (int i = 1; i <= points.Count - 1; i++)
                    {
                        graphics.DrawLine(BluePen, points[i - 1], points[i]);
                    }/*
                    if (AstarResult.Count > 0)
                    {
                        graphics.DrawLine(YellowPen, points[0], AstarResult[0]);
                        for (int i = 1; i <= AstarResult.Count - 1; i++)
                        {
                            graphics.DrawLine(YellowPen, AstarResult[i - 1], AstarResult[i]);
                        }
                    }
                    if (AstarResult.Count > 1)
                    {
                        System.Drawing.Rectangle resultArea = SkUtil.Draw.ToRectangle(AstarResult);
                        System.Drawing.Point center = System.Drawing.Point.Add(ScreenCapture.CaptureStartPoint, (SkUtil.Draw.ToCenterSize(resultArea)));
                        resultArea.Inflate(10, 10);

                        graphics.DrawRectangle(RedPen, resultArea);
                        if (FollowForm.FollowClick)
                        {
                            SkTask.Action.Task.Move(center);
                            SkTask.Action.Task.Click(center, SkTask.Constants.InputEvent.LEFT);
                        }
                        //Click 동작 해줌
                        //종료
                    }
                    */

                    System.Drawing.Point center = System.Drawing.Point.Add(ScreenCapture.CaptureStartPoint, (SkUtil.Draw.ToCenterSize(RecognizeResult)));

                    RecognizeResult.Inflate(10, 10);
                    graphics.DrawRectangle(RedPen, RecognizeResult);
                    //if (FollowForm.FollowClick)
                    {
                        //SkTask.Action.Task.Move(center);
                        Action.Task.Move(center);
                    }
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
        static  Rectangle GetBoundary(BitmapData sourceData, Color toReplace, System.Drawing.Point currentPt)
        {
            Rectangle result = Rectangle.FromLTRB(
                GetMinMax(sourceData, toReplace, currentPt.X, currentPt.Y,true,true),
                GetMinMax(sourceData, toReplace, currentPt.X, currentPt.Y, false, true),
                GetMinMax(sourceData, toReplace, currentPt.X, currentPt.Y, true, false),
                GetMinMax(sourceData, toReplace, currentPt.X, currentPt.Y, false, false));
            return result;
        }
        static int GetMinMax(BitmapData sourceData, Color toReplace, int CurrentX, int CurrentY, bool CheckXY, bool Min)
        {
            int StartX = CurrentX + (CheckXY ? (Min ? -100 : 100) : -100);
            int EndX = CurrentX + (CheckXY ? 0 : 100);
            int offsetX = (StartX < EndX) ? +1 : -1;
            int StartY = CurrentY + (!CheckXY ? (Min ? -100 : 100) : -100);
            int EndY = CurrentY + (!CheckXY ? 0 : 100);
            int offsetY = (StartY < EndY) ? +1 : -1;
            int i;
            i = +1;

            for (int x = StartX; (StartX < EndX) ? x < EndX : x > EndX; x += offsetX)
            {
                for (int y = StartY; (StartY < EndY) ? y < EndY : y > EndY; y += offsetY)
                {
                    if(recognizeColor(sourceData, RecognizeColor, x, y))
                    {
                        return CheckXY ? x : y;
                    }
                }
            }
            return (CheckXY ? CurrentX : CurrentY) + (Min ? -1 : 1);
        }
        static List<System.Drawing.Point> AStar(BitmapData sourceData, Color toReplace, System.Drawing.Point currentPt)
        {
            int distanceFlag = 0;
            List<System.Drawing.Point> points = new List<System.Drawing.Point>();
            points.Add(currentPt);

            System.Drawing.Point point = currentPt;
            int direction = -1;
            point = AStarNextPoint(sourceData, toReplace, currentPt, points, ref direction);
            while (!point.IsEmpty)
            {
                points.Add(point);
                float distance = SkUtil.MathUtil.DistanceToPoint(currentPt, point);
                //다음꺼 처리 했는데 거리가 CollisionOffset * 20이면 잘못 처리하고있는거다 나와야 한다.
                if(distance > 1000)
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
                else if(distanceFlag == 1)
                {
                    if (distance < 3)
                    {
                        distanceFlag++;
                    }
                }
                if(distanceFlag == 2)
                {
                    break;
                }
                point = AStarNextPoint(sourceData, toReplace, point, points, ref direction);
            }
            if(points.Count == 1)
            {
                int dd = 0;
            }
            return points;
        }
        static void AStarNextDirection(List<System.Drawing.Point> points, ref int direction) {
            direction--;
            for (int cnt = 0; cnt < AStarCount-1; cnt++)
            {
                if (AStarResult[direction] && !AStarPoints.Contains(AStarPoints[direction]))
                {
                    return;
                }
                if (direction == 0)
                {
                    direction = 7;
                }
                else
                {
                    direction--;
                }
            }
            direction = -1;
        }
        static System.Drawing.Point AStarNextPoint(
            BitmapData sourceData,
            Color toReplace, 
            System.Drawing.Point currentPt, 
            List<System.Drawing.Point> points,
            ref int direction)
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
                if (direction != -1)
                {
                    AStarPoints[direction] = GetProcessPoint(direction, sourceData, currentPt, moveOffset);
                    if (!AStarPoints[direction].IsEmpty)
                    {
                        AStarResult[direction] = recognizeColor(sourceData, toReplace, AStarPoints[direction]);
                        if (AStarResult[direction] && !points.Contains(AStarPoints[direction]))
                        {
                            return AStarPoints[direction];
                        }
                        else
                        {
                            AStarNextDirection(points, ref direction); 
                            if(direction == -1)
                            {
                                continue;
                            }
                            return AStarPoints[direction];
                        }
                       
                    }
                }
                else
                {
                    int das = 0;
                    //Astar 알고리즘에 맞는것을 리턴
                    //새로 검색 하는 로직일때
                    for (int i = 0; i < AStarCount; i++)
                    {
                        if (points.Contains(AStarPoints[i]))
                        {
                            continue;
                        }
                        if (i == 0)
                        {
                            if ((!AStarResult[AStarCount - 1] || !AStarResult[1]) && AStarResult[i])
                            {
                                direction = i;
                                return AStarPoints[i];
                            }
                        }
                        else if (i == AStarCount - 1)
                        {
                            if ((!AStarResult[AStarCount - 2] || !AStarResult[0]) && AStarResult[i])
                            {
                                direction = i;
                                return AStarPoints[i];
                            }
                        }
                        else if ((!AStarResult[i - 1] || !AStarResult[i + 1]) && AStarResult[i])
                        {
                            direction = i;
                            return AStarPoints[i];
                        }
                    }
                }
                //중간값으로 처리 했으면 범위 넓혀서 다시 처리
            }
            direction = -1;
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
