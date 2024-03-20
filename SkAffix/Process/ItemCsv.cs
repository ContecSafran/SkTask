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
        public SearchItems getItems()
        {
            SearchItems searchItems = new SearchItems();
            searchItems.ItemList = ItemFileUtil.CsvToItemList("Item/flask.csv");

            searchItems.PrefixList = ItemFileUtil.CsvToAffixList("Item/flask_prefix.csv");
            searchItems.SurffixList = ItemFileUtil.CsvToAffixList("Item/flask_surffix.csv");
            return searchItems;
        }
    }
}
