using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkAffix.Dto
{
    public class Item : DtoBase
    {
        public string KRName { get; set; }
        public string EnName { get; set; }
    }
    public class SearchItems
    {
        public List<Item> ItemList;
        public List<Affix> PrefixList;
        public List<Affix> SurffixList;
    }
}
