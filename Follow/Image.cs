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

namespace SkTask
{
    public partial class Image : Form
    {
        public Image()
        {
            InitializeComponent();

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
        }
        public void init()
        {

            if (Screen.AllScreens.Length == 1)
            {
                this.Visible = false;
            }
            else
            {
                int SelectedIndex = Action.Info.MonitorArea.OtherIndex;
                this.Location = new System.Drawing.Point
                {
                    X = Screen.AllScreens[SelectedIndex].Bounds.Left,
                    Y = Screen.AllScreens[SelectedIndex].Bounds.Top
                };
            }
        }
    }
}
