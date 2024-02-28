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
    public class RectangleRecognizePixel
    {
        static List<System.Drawing.Point> points = new List<System.Drawing.Point>();
        static Pen BluePen = new Pen(Color.Blue, 1);

        public static void init()
        {
            //초기화 시 인식 경로 생성
            System.Drawing.Point center = SkUtil.Draw.ToCenter(ScreenCapture.ProcessRectangle);
            for (int r = 10; r < ScreenCapture.ProcessRectangle.Width/2; r += 10)
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
                using (var graphics = Graphics.FromImage(inputBmp))
                {
                    for (int i = 1; i <= points.Count-1; i++)
                    {
                        graphics.DrawLine(BluePen, points[i-1], points[i]);
                    }
                }
            }
            return inputBmp;
            //픽셀 충돌 위치 검색
            //픽셀 충돌 위치 기준으로 star 알고리즘을 만들어서 충돌 위치까지 돌아오는 픽셀들의 합을 구한다.
            //충돌 픽셀 범위 계산
            //충돌 픽셀 중간 값 계산
        }
    }
}
