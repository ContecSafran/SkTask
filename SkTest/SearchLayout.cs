using Search;
using SkAffix.Dto;
using SkAffix.Process;
using SkUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkTest
{
    public class SearchLayout
    {
        public static void GetPriceAffixLoop(SearchItems searchItems)
        {
            GetPriceAffixLoop(searchItems.PrefixList);
            GetPriceAffixLoop(searchItems.PrefixList);
        }

        public static void GetPriceAffixLoop(List<Affix> AffixList)
        {
            foreach(Affix affix in AffixList)
            {
                affix.filter = OptionParser.GetOptionFilter(affix.Option);
            }
        }
    }
}
