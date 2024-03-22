using Newtonsoft.Json;
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
    class Program
    {
        static void Main(string[] args)
        {
            SearchItems searchItems = OptionManager.getItems("flask");
            Dictionary<Item, List<Price>> result = GetPriceItemLoop(searchItems);

        }
        private static Dictionary<Item, List<Price>> GetPriceItemLoop(SearchItems searchItems)
        {
            Dictionary<Item, List<Price>> ItemDic = new Dictionary<Item, List<Price>>();
            for (int i = 0; i < searchItems.ItemList.Count; i++)
            {
                List<Price> prices = GetPriceAffixLoop(searchItems, searchItems.ItemList[i]);
                ItemDic.Add(searchItems.ItemList[i], prices);
            }
            return ItemDic;
        }
        private static List<Price> GetPriceAffixLoop(SearchItems searchItems, Item item)
        {
            List<Price> prices = new List<Price>();
            for (int p = 0; p < searchItems.PrefixList.Count; p++)
            {
                for (int s = 0; s < searchItems.SuffixList.Count; s++)
                {
                    GetPriceRangeLoop(item, searchItems.PrefixList[p], searchItems.SuffixList[s], prices);
                }
            }
            return prices;
        }
        private static void GetPriceRangeLoop(
            Item item,
            Affix prefix,
            Affix suffix,
            List<Price> prices)
        {
            if (prefix.IsRange)
            {
                for (double pr = prefix.Min; pr <= prefix.Max; pr += 1.0)
                {
                    if (suffix.IsRange)
                    {
                        for (double sr = suffix.Min; sr <= suffix.Max; sr += 1.0)
                        {
                            prices.Add(SearchItem.GetPrice(item, prefix, suffix, pr, sr));
                        }
                    }
                    else
                    {
                        prices.Add(SearchItem.GetPrice(item, prefix, suffix, pr));
                    }
                }
            }
            else
            {
                if (suffix.IsRange)
                {
                    for (double sr = suffix.Min; sr <= suffix.Max; sr += 1.0)
                    {
                        prices.Add(SearchItem.GetPrice(item, prefix, suffix, 99999, sr));
                    }
                }
                else
                {
                    prices.Add(SearchItem.GetPrice(item, prefix, suffix));
                }
            }
        }
    }
}
