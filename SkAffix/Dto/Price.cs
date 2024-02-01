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
        public int PrefixValue;
        public int SuffixId;
        public int SuffixValue;

        public SkAffix.Constants.Currency MinCurrency;
        public int MinNum;
        public int MinCount;

        public SkAffix.Constants.Currency MaxCurrency;
        public int MaxNum;
        public int MaxCount;

        public DateTime date;
    }
}
