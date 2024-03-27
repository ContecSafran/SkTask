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
            string s = OptionManager.getSampleData();

            // string ss = "{\"query\":{\"filters\":{\"armour_filters\":{\"disabled\":true},\"heist_filters\":{\"disabled\":true,\"filters\":{}},\"map_filters\":{\"disabled\":true,\"filters\":{}},\"misc_filters\":{\"disabled\":true,\"filters\":{}},\"req_filters\":{\"disabled\":true},\"socket_filters\":{\"disabled\":true,\"filters\":{}},\"trade_filters\":{\"disabled\":false,\"filters\":{\"indexed\":{\"option\":\"1week\"},\"sale_type\":{\"option\":\"priced\"}}},\"type_filters\":{\"filters\":{\"category\":{\"option\":\"flask\"},\"rarity\":{\"option\":\"magic\"}}},\"ultimatum_filters\":{\"disabled\":true,\"filters\":{}},\"weapon_filters\":{\"disabled\":true}},\"stats\":[{\"filters\":[{\"disabled\":false,\"id\":\"explicit.stat_1582728645\",\"value\":{\"max\":3,\"min\":3}}],\"type\":\"and\"}],\"type\":\"자수정 플라스크\",\"status\":{\"option\":\"online\"}},\"sort\":{\"price\":\"asc\"}}";
            //List<SkAffix.Dto.Currency> price = Search.Search.UpdatePrice("Affliction", 0, output, 5);
            //q_Stats_filters q_Stats_Filters = OptionParser.GetOptionFilter1("적에게 피격 시 충전 3 획득");
            //SearchItems searchItems = OptionManager.getItems("flask");
            //아이템 복사
            //접두 접미 복사해서 리스트에서 검색
            //2티어 까지 확인해서 리스트에서 검색
            //검색된것이 어느정도 가격 이상이면 웹브라우저로 띄움


        }
        
        public static void SearchCurrentItem()
        {
            string itemName = "자수정 플라스크";
            string itemType = "flask";
            SearchItems searchItems = OptionManager.getItems(itemType);
            CurrentItemPrice currentItemPrice = new CurrentItemPrice();
            OptionParser.GetSearchItemOptionFilter(currentItemPrice, "효과 25% 증가", searchItems, true);
            //q_Stats_filters suffixFilter = OptionParser.GetSearchItemOptionFilter("효과를 받는 동안 추가 원소 저항 36%");
            OptionParser.GetSearchItemOptionFilter(currentItemPrice, "# 빈 접미어 속성 부여", searchItems, false);
            Item item = Array.FindAll(searchItems.ItemList.ToArray(), x => itemName.Equals(x.KRName)).First();
            Dictionary<Item, List<Price>> result = GetPriceItemLoop(searchItems);
            List<Price> prices = result[item];

            Price Result = Array.FindAll(
                prices.ToArray(), x =>
                    currentItemPrice.ItemId.Equals(x.ItemId) &&
                    currentItemPrice.prefix.id.Equals(x.PrefixId) &&
                    currentItemPrice.surfix.id.Equals(x.SuffixId)
                ).First();
            SkAffix.Dto.Currency currency = Result.Result.First();

        }
        public static void SearchAllItem()
        {
            string itemType = "flask";
            SearchItems searchItems = OptionManager.getItems(itemType);
            Dictionary<Item, List<Price>> result = GetPriceItemLoop(searchItems);
        }
        public static void OpenWebBrowser()
        {
            string itemType = "flask";
            SearchItems searchItems = OptionManager.getItems(itemType);
            CurrentItemPrice currentItemPrice = new CurrentItemPrice();
            OptionParser.GetSearchItemOptionFilter(currentItemPrice, "효과 25% 증가", searchItems, true);
            //q_Stats_filters suffixFilter = OptionParser.GetSearchItemOptionFilter("효과를 받는 동안 추가 원소 저항 36%");
            OptionParser.GetSearchItemOptionFilter(currentItemPrice, "# 빈 접미어 속성 부여", searchItems, false);
            string output = Search.toJson("자수정 플라스크", "flask", currentItemPrice.searchPrefixFilter, currentItemPrice.searchSurfixFilter);
            Search.OpenWebBrowser(Status.league, output);
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
                    if (searchItems.PrefixList[p].filter == null || searchItems.SuffixList[s].filter == null)
                    {
                        continue;
                    }
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
                if (suffix.IsRange)
                {
                    prices.Add(SearchItem.GetPrice(item, prefix, suffix, prefix.Min, suffix.Min));
                  //  prices.Add(SearchItem.GetPrice(item, prefix, suffix, prefix.Max, suffix.Max));
                }
                else
                {
                    prices.Add(SearchItem.GetPrice(item, prefix, suffix, prefix.Min));
                  //  prices.Add(SearchItem.GetPrice(item, prefix, suffix, prefix.Max));
                }
                    /*
                    for (double pr = prefix.Min; pr <= prefix.Max; pr += 1.0)
                    {
                        if (suffix.IsRange)
                        {
                            prices.Add(SearchItem.GetPrice(item, prefix, suffix, pr, suffix.Min));
                            prices.Add(SearchItem.GetPrice(item, prefix, suffix, pr, suffix.Max));

                            for (double sr = suffix.Min; sr <= suffix.Max; sr += 1.0)
                            {
                                prices.Add(SearchItem.GetPrice(item, prefix, suffix, pr, sr));
                            }
                        }
                        else
                        {
                            prices.Add(SearchItem.GetPrice(item, prefix, suffix, pr));
                        }
                    }*/
                }
            else
            {
                if (suffix.IsRange)
                {
                    prices.Add(SearchItem.GetPrice(item, prefix, suffix, 99999, suffix.Min));
                    //prices.Add(SearchItem.GetPrice(item, prefix, suffix, 99999, suffix.Max));
                }
                else
                {
                    prices.Add(SearchItem.GetPrice(item, prefix, suffix));
                }
                /*
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
                }*/
            }
        }
    }
}
