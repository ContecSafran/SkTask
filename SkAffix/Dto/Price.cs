using SkAffix.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkAffix.Dto
{
    public class Price : DtoBase
    {
        public int ItemId;
        public int PrefixId;
        public double PrefixValue;
        public int SuffixId;
        public double SuffixValue;

        public List<SkAffix.Dto.Currency> Result;

        public DateTime date;
    }
    public class CurrentItemPrice
    {
        public int ItemId;
        public Affix prefix;
        public double PrefixValue;
        public Affix surfix;
        public double sufixValue;
        public q_Stats_filters searchPrefixFilter;
        public q_Stats_filters searchSurfixFilter;
    }
}
