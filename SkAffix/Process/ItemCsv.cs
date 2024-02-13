using SkAffix.Dto;
using SkUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkAffix.Process
{
    public class ItemCsv
    {
        public List<Item> getItems()
        {
            List<Item> ItemList = ItemFileUtil.CsvToItemList("Item/flask.csv");

            List<Affix> PrefixList = ItemFileUtil.CsvToAffixList("Item/flask_prefix.csv");
            List<Affix> SurffixList = ItemFileUtil.CsvToAffixList("Item/flask_surffix.csv");
            return ItemList;
        }
    }
}
