﻿using System;
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
        public static Price GetPrice(Item item, Affix prefix, Affix surffix, double prefixValue = 99999, double surfixValue = 99999)
        {
            //인풋 파일에서 c2 a0를 20으로 변경해야함
            q_Stats_filters prefixFilter = OptionParser.GetOptionFilter(prefix.Option, prefixValue);
            q_Stats_filters suffixFilter = OptionParser.GetOptionFilter(surffix.Option, surfixValue);

            string output = Search.Search.toJson(item.KRName, "flask", prefixFilter, suffixFilter);
            // string ss = "{\"query\":{\"filters\":{\"armour_filters\":{\"disabled\":true},\"heist_filters\":{\"disabled\":true,\"filters\":{}},\"map_filters\":{\"disabled\":true,\"filters\":{}},\"misc_filters\":{\"disabled\":true,\"filters\":{}},\"req_filters\":{\"disabled\":true},\"socket_filters\":{\"disabled\":true,\"filters\":{}},\"trade_filters\":{\"disabled\":false,\"filters\":{\"indexed\":{\"option\":\"1week\"},\"sale_type\":{\"option\":\"priced\"}}},\"type_filters\":{\"filters\":{\"category\":{\"option\":\"flask\"},\"rarity\":{\"option\":\"magic\"}}},\"ultimatum_filters\":{\"disabled\":true,\"filters\":{}},\"weapon_filters\":{\"disabled\":true}},\"stats\":[{\"filters\":[{\"disabled\":false,\"id\":\"explicit.stat_1582728645\",\"value\":{\"max\":3,\"min\":3}}],\"type\":\"and\"}],\"type\":\"자수정 플라스크\",\"status\":{\"option\":\"online\"}},\"sort\":{\"price\":\"asc\"}}";
            List<SkAffix.Dto.Currency> price = Search.Search.UpdatePrice("Affliction", 0, output, 5);
            Price result = new Price()
            {
                ItemId = item.id,
                PrefixId = prefix.id,
                PrefixValue = prefixValue,
                SuffixId = surffix.id,
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
