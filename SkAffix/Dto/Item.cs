using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkAffix.Dto
{
    public class Item : DtoBase
    {
    }
    public class SearchItems
    {
        public bool search;
        public List<Item> ItemList;
        public List<Affix> PrefixList;
        public List<Affix> SuffixList;
    }
}
