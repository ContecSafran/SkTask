using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkUtil
{
    public class CT_Converter
    {
        static public int StringObjectToInt32(object o)
        {
            string s = (string)o;
            return s.Equals("") ? 0 : Int32.Parse(s);
        }
        static public double StringObjectToDouble(object o)
        {
            string s = (string)o;
            return s.Equals("") ? 0 : Double.Parse(s);
        }
    }
}
