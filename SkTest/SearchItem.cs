using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Search;
using SkAffix.Dto;
using SkAffix.Process;

namespace SkTest
{
    class SearchItem
    {
        public static Price GetPrice(Item item, Affix prefix, Affix suffix, double prefixValue = 99999, double surfixValue = 99999)
        {
            //인풋 파일에서 c2 a0를 20으로 변경해야함
            q_Stats_filters prefixFilter = OptionParser.GetOptionFilter(prefix.Option, prefixValue);
            q_Stats_filters suffixFilter = OptionParser.GetOptionFilter(suffix.Option, surfixValue);

           // string output = Search.Search.toJson(item.KRName, "flask", prefixFilter, suffixFilter);
            List<SkAffix.Dto.Currency> price = null;// Search.Search.UpdatePrice("Affliction", 0, output, 5);
            Price result = new Price()
            {
                ItemId = item.id,
                PrefixId = prefix.id,
                PrefixValue = prefixValue,
                SuffixId = suffix.id,
                SuffixValue = surfixValue,
                Result = price,
                date = DateTime.Now,
            };
            return result;
        }
        static private byte[] StringToByte(string str)
        {
            byte[] StrByte = Encoding.UTF8.GetBytes(str);
            return StrByte;
        }
    }
}
