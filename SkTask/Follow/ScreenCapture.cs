using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SkTask.Follow
{
    public class ScreenCapture
    {
        public Rectangle rect;
        public int imageData_Stride;
        public PixelFormat pixelFormat;
        public bool IsCaptureStart = true;   //false : Receive
        public bool Stop = true;
        public Bitmap bmp;
        public byte[] Buffer = null;
        public void Init()
        {
            // 주화면의 크기 정보 읽기
            rect = Screen.PrimaryScreen.Bounds;
            // 2nd screen = Screen.AllScreens[1]

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
            // 화면 크기만큼의 Bitmap 생성
            bmp = new Bitmap(rect.Width, rect.Height, pixelFormat);


        }

        public void Capture()
        {
            // Bitmap 이미지 변경을 위해 Graphics 객체 생성
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                // 화면을 그대로 카피해서 Bitmap 메모리에 저장
                gr.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
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
            // 2nd screen = Screen.AllScreens[1]

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
