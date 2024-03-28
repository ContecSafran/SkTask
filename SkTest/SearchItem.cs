using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SkAffix.Dto;
using SkAffix.Process;

namespace SkTest
{
    class SearchItem
    {
        public static Price GetPrice(Item item, Affix prefix, Affix suffix, bool search, double prefixValue = 99999, double surfixValue = 99999)
        {
           // Thread.Sleep(5000);
            prefix.filter.Value = new q_Min_And_Max() { Min = prefixValue, Max = prefixValue };
            suffix.filter.Value = new q_Min_And_Max() { Min = surfixValue, Max = surfixValue };
            //인풋 파일에서 c2 a0를 20으로 변경해야함
            q_Stats_filters prefixFilter = prefix.filter;
            q_Stats_filters suffixFilter = suffix.filter;

            string output = Search.toJson(item.Name, "flask", prefixFilter, suffixFilter);
            List<SkAffix.Dto.Currency> price = search ? Search.UpdatePrice("Affliction", 0, output, 5): null;
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
