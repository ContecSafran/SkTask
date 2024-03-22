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
            

        }
    }
}
