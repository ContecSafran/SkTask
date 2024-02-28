using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Follow;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Tesseract;

namespace SkTask
{
    public partial class Image : Form
    {
        public Image()
        {
            InitializeComponent();

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

        private void Image_Load(object sender, EventArgs e)
        {
            if(Screen.AllScreens.Length == 1)
            {
                this.Visible = false;
            }
            else
            {
                int SelectedIndex = 0;// Follow.MonitorInfo.SelectMonitor.Index;
                this.Location = new System.Drawing.Point
                {
                    X = Screen.AllScreens[SelectedIndex].Bounds.Left,
                    Y = Screen.AllScreens[SelectedIndex].Bounds.Top
                };
            }
        }
    }
}
