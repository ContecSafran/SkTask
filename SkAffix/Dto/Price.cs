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
}
