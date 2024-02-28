using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Follow
{
    public class ScreenCapture
    {
        public Rectangle rect;
        public Size size;
        public int imageData_Stride;
        public PixelFormat pixelFormat;
        public bool IsCaptureStart = true;   //false : Receive
        public bool Stop = true;
        public Bitmap bmp;
        public byte[] Buffer = null;
        public static System.Drawing.Point CaptureStartPoint;
        public static System.Drawing.Size CaptureSize;
        public static Rectangle CaptureBound;
        public static Rectangle ProcessRectangle;
        public void Init()
        {
            // 주화면의 크기 정보 읽기
            rect = Screen.AllScreens[Follow.MonitorInfo.SelectMonitor.Index].Bounds;
            size = rect.Size;

            // 픽셀 포맷 정보 얻기 (Optional)
            int bitsPerPixel = Screen.PrimaryScreen.BitsPerPixel;
            pixelFormat = PixelFormat.Format32bppArgb;
            if (bitsPerPixel <= 16)
            {
                pixelFormat = PixelFormat.Format16bppRgb565;
            }
            if (bitsPerPixel == 24)
            {
                pixelFormat = PixelFormat.Format24bppRgb;
            }
            int index = Follow.MonitorInfo.SelectMonitor.Index;
            int r = Screen.AllScreens[index].Bounds.Width > Screen.AllScreens[index].Bounds.Height ? Screen.AllScreens[index].Bounds.Width : Screen.AllScreens[index].Bounds.Height ;
            r = r / 2;
            // 화면 크기만큼의 Bitmap 생성
            bmp = new Bitmap(r, r, pixelFormat);
            CaptureStartPoint = new Point(
                (Screen.AllScreens[index].Bounds.Width / 2) - r/2,
                (Screen.AllScreens[index].Bounds.Height / 2) - r/2);
            CaptureSize = new Size(r,r);
            CaptureBound = new Rectangle(CaptureStartPoint, CaptureSize);
            ProcessRectangle = new Rectangle(new Point(0, 0), CaptureSize);
        }

        public void Capture()
        {
            Rectangle newRect = Screen.AllScreens[Follow.MonitorInfo.SelectMonitor.Index].Bounds;
            if (!newRect.Size.Equals(size))
            {
                this.Init();
            }
            int index = Follow.MonitorInfo.SelectMonitor.Index;
            // Bitmap 이미지 변경을 위해 Graphics 객체 생성
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                // 화면을 그대로 카피해서 Bitmap 메모리에 저장
                //gr.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
                gr.CopyFromScreen(CaptureStartPoint.X, CaptureStartPoint.Y,0, 0, CaptureSize);
            }
        }
        public void CaptureBuffer()
        {
            IsCaptureStart = true;
            Capture();
            BitmapToArray();
        }
        public void BitmapToArray()
        {
            var imageData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                                                ImageLockMode.ReadWrite, pixelFormat);
            if (Buffer == null)
            {
                imageData_Stride = imageData.Stride;
                Buffer = new byte[imageData.Height * imageData.Stride];
            }
            try
            {
                Marshal.Copy(imageData.Scan0, Buffer, 0, Buffer.Length);
            }
            finally
            {
                bmp.UnlockBits(imageData);
            }
        }


        public void Init(int width, int height, PixelFormat pixelFormat)
        {
            IsCaptureStart = false;
            // 주화면의 크기 정보 읽기
            Rectangle rect = new Rectangle(0, 0, width, height);
            bmp = new Bitmap(rect.Width, rect.Height, pixelFormat);

        }
        public void ArrayToBitmap()
        {
            BitmapData imageData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                                                ImageLockMode.ReadWrite, pixelFormat);
            try
            {
                Marshal.Copy(Buffer, 0, imageData.Scan0, Buffer.Length);
            }
            finally
            {
                bmp.UnlockBits(imageData);
            }
        }
    }
}
