using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using SkTask.Follow;
using Tesseract;

namespace SkTask
{
    public partial class Image : Form
    {
        public Image()
        {
            InitializeComponent();

            ScreenCapture screenCapture = new ScreenCapture();
            screenCapture.Init();
            screenCapture.Capture();
            OutputImage.Image = screenCapture.bmp;
            /*
            //캡쳐 thread
            //이미지 변환 thread
            Mat src = Cv2.ImRead("../resource/inputImage.png");
            process(src);

            Mat gray = new Mat();
            Mat binary = new Mat();

            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(gray, binary, 100, 200, ThresholdTypes.Binary);
            OutputImage.Image = BitmapConverter.ToBitmap(binary);

            //ocr thread
            Tesseract.TesseractEngine tesseractEngine = new Tesseract.TesseractEngine("../resource/tessdata-main", "eng");
            using (var img = PixConverter.ToPix((Bitmap)OutputImage.Image))
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
                            //string path = Server.MapPath("~/Output/data.txt");
                            if (iter.TryGetBoundingBox(PageIteratorLevel.Word, out symbolBounds))
                            {
                                // do whatever you want with bounding box for the symbol

                                var curText = iter.GetText(PageIteratorLevel.Word);
                                int dd = 0;
                                //Wayne
                                //Wayn
                                //ayne
                                //Way
                                //ayn
                                //yne
                                //확인해서 검출

                            }
                        } while (iter.Next(PageIteratorLevel.Word));
                    }
                }
            }*/
        }
        public void process(Mat src)
        {

            Mat[] mv = new Mat[3];
            Mat mask = new Mat();

            Cv2.CvtColor(src, src, ColorConversionCodes.BGR2HSV);
            mv = Cv2.Split(src);
            Cv2.CvtColor(src, src, ColorConversionCodes.HSV2BGR);

            Cv2.InRange(mv[0], new Scalar(60), new Scalar(60), mask);
            Cv2.BitwiseAnd(src, mask.CvtColor(ColorConversionCodes.GRAY2BGR), src);
        }
        void showComparison(string one, string two)
        {
            int compareLinguistic = String.Compare(one, two, StringComparison.InvariantCulture);
            int compareOrdinal = String.Compare(one, two, StringComparison.Ordinal);
            if (compareLinguistic < 0)
                Console.WriteLine($"<{one}> is less than <{two}> using invariant culture");
            else if (compareLinguistic > 0)
                Console.WriteLine($"<{one}> is greater than <{two}> using invariant culture");
            else
                Console.WriteLine($"<{one}> and <{two}> are equivalent in order using invariant culture");
            if (compareOrdinal < 0)
                Console.WriteLine($"<{one}> is less than <{two}> using ordinal comparison");
            else if (compareOrdinal > 0)
                Console.WriteLine($"<{one}> is greater than <{two}> using ordinal comparison");
            else
                Console.WriteLine($"<{one}> and <{two}> are equivalent in order using ordinal comparison");
        }
    }
}
