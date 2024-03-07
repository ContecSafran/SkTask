using Action.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Action.Controls
{
    public partial class Position : UserControl
    {

        public static Point CurrentPosition;
        public Position()
        {
            InitializeComponent();

        }

        private void PositionTimer_Tick(object sender, EventArgs e)
        {
            if (!Setting.MouseLog)
            {
                return;
            }
            if (Setting.Mode == Constants.Mode.WAITING)
            {
                if (!Position.CurrentPosition.Equals(Cursor.Position))
                {
                    Position.CurrentPosition = Cursor.Position;
                    float x = (float)Position.CurrentPosition.X / (float)Screen.PrimaryScreen.Bounds.Width;
                    float y = (float)Position.CurrentPosition.Y / (float)Screen.PrimaryScreen.Bounds.Height;
                    this.ContentsTextBox.AppendText(x.ToString("F4") + "f, " + y.ToString("F4") + "f\r\n");
                    this.ContentsTextBox.Select(this.ContentsTextBox.Text.Length, 0);
                    this.ContentsTextBox.ScrollToCaret();
                }
                //this.PositionTextBox.Lines[0] = Cursor.Position.X.ToString() + " " + Cursor.Position.Y.ToString();
            }
        }
    }
}
