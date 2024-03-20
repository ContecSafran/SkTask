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
    class Program
    {
        static void Main(string[] args)
        {
            ItemCsv itemCsv = new ItemCsv();
            SearchItems searchItems = itemCsv.getItems();
            Price result = SearchItem.GetPrice(searchItems.ItemList[6], searchItems.PrefixList[5], searchItems.SurffixList[4], 25, 36);
            
            //string refStr = "{\"query\":{\"filters\":{\"armour_filters\":{\"disabled\":true},\"heist_filters\":{\"disabled\":true,\"filters\":{}},\"map_filters\":{\"disabled\":true,\"filters\":{}},\"misc_filters\":{\"disabled\":true,\"filters\":{}},\"req_filters\":{\"disabled\":true},\"socket_filters\":{\"disabled\":true,\"filters\":{}},\"trade_filters\":{\"disabled\":false,\"filters\":{\"indexed\":{\"option\":\"1week\"},\"sale_type\":{\"option\":\"priced\"}}},\"type_filters\":{\"filters\":{\"category\":{\"option\":\"flask\"},\"rarity\":{\"option\":\"magic\"}}},\"ultimatum_filters\":{\"disabled\":true,\"filters\":{}},\"weapon_filters\":{\"disabled\":true}},\"stats\":[{\"filters\":[{\"disabled\":false,\"id\":\"pseudo.pseudo_number_of_empty_prefix_mods\"},{\"disabled\":false,\"id\":\"explicit.stat_962725504\",\"value\":{\"max\":39,\"min\":39}}],\"type\":\"and\"}],\"type\":\"자수정 플라스크\",\"status\":{\"option\":\"online\"}},\"sort\":{\"price\":\"asc\"}}";
            q_Stats_filters prefixFilter = OptionParser.GetOptionFilter("효과 #% 증가", 25);
            q_Stats_filters suffixFilter = OptionParser.GetOptionFilter("효과를 받는 동안 추가 원소 저항 #%", 36);
            string output = Search.Search.toJson("자수정 플라스크", "flask", prefixFilter, suffixFilter);
            // string ss = "{\"query\":{\"filters\":{\"armour_filters\":{\"disabled\":true},\"heist_filters\":{\"disabled\":true,\"filters\":{}},\"map_filters\":{\"disabled\":true,\"filters\":{}},\"misc_filters\":{\"disabled\":true,\"filters\":{}},\"req_filters\":{\"disabled\":true},\"socket_filters\":{\"disabled\":true,\"filters\":{}},\"trade_filters\":{\"disabled\":false,\"filters\":{\"indexed\":{\"option\":\"1week\"},\"sale_type\":{\"option\":\"priced\"}}},\"type_filters\":{\"filters\":{\"category\":{\"option\":\"flask\"},\"rarity\":{\"option\":\"magic\"}}},\"ultimatum_filters\":{\"disabled\":true,\"filters\":{}},\"weapon_filters\":{\"disabled\":true}},\"stats\":[{\"filters\":[{\"disabled\":false,\"id\":\"explicit.stat_1582728645\",\"value\":{\"max\":3,\"min\":3}}],\"type\":\"and\"}],\"type\":\"자수정 플라스크\",\"status\":{\"option\":\"online\"}},\"sort\":{\"price\":\"asc\"}}";
            List<SkAffix.Dto.Currency> price = Search.Search.UpdatePrice("Affliction", 0, output, 5);
        }
    }
}
