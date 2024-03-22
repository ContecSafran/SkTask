using Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkAffix.Dto
{
    public class Affix : DtoBase
    {
        public string Name;
        public string NameEN;
        public string OptionEN;
        public string Option;
        public bool IsRange;
        public double Min;
        public double Max;
        public q_Stats_filters filter;
    }
}
