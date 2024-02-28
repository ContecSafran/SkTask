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
        public static Bitmap Process(Bitmap inputBmp)
        {
            return inputBmp;
            //초기화 시 인식 경로 생성
            //픽셀 충돌 위치 검색
            //픽셀 충돌 위치 기준으로 star 알고리즘을 만들어서 충돌 위치까지 돌아오는 픽셀들의 합을 구한다.
            //충돌 픽셀 그리기
            //충돌 픽셀 범위 계산
            //충돌 픽셀 중간 값 계산
        }
    }
}
