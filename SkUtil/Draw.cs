using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkUtil
{
    public class Draw
    {
        public static System.Drawing.Point ToCenter(System.Drawing.Rectangle rc)
        {
            return new System.Drawing.Point(rc.X + (rc.Width / 2), rc.Y + (rc.Height / 2));
        }
    }
}
