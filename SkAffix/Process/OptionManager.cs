using Newtonsoft.Json;
using SkAffix.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SkAffix.Process
{
    public class OptionManager
    {
        public static string ItemDirectory = "Item/";
        static public SearchItems getItems(string itemType)
        {

            string filename = "../resource/" + ItemDirectory + itemType + "/searchLayout.txt";
            if (File.Exists(filename))
            {
                string s = File.ReadAllText(filename);
                SearchItems searchItems = JsonConvert.DeserializeObject<SearchItems>(s);
                return searchItems;
            }
            else
            {

                SearchItems searchItems = new SearchItems();
                string directoryName = ItemDirectory + itemType + "/";
                searchItems.ItemList = ItemFileUtil.CsvToItemList(directoryName + itemType + ".csv");

                searchItems.PrefixList = ItemFileUtil.CsvToAffixList(directoryName + "prefix.csv");
                searchItems.SuffixList = ItemFileUtil.CsvToAffixList(directoryName + "suffix.csv");
                GetPriceAffixLoop(searchItems);

                File.WriteAllText(filename, JsonConvert.SerializeObject(searchItems));
                return searchItems;
            }
        }

        static public void SavePriceLayout(Dictionary<Item, List<Price>> priceLayout,string itemType = "flask")
        {
            string filename = "../resource/" + ItemDirectory + itemType + "/priceLayout.txt";
            File.WriteAllText(filename, JsonConvert.SerializeObject(priceLayout));
        }
        static public Dictionary<Item, List<Price>> LoadPriceLayout(string itemType = "flask")
        {
            string filename = "../resource/" + ItemDirectory + itemType + "/priceLayout.txt";
            string s = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<Dictionary<Item, List<Price>>>(s);
        }
        static public string getSampleData()
        {
            string filename = "../resource/" + ItemDirectory + "flask/flask sample sufix.txt";
            return File.ReadAllText(filename);
        }
        public static void GetPriceAffixLoop(SearchItems searchItems)
        {
            GetPriceAffixLoop(searchItems.PrefixList);
            GetPriceAffixLoop(searchItems.SuffixList);
        }

        public static void GetPriceAffixLoop(List<Affix> AffixList)
        {
            foreach (Affix affix in AffixList)
            {
                affix.filter = OptionParser.GetOptionFilter(affix.Option);
                //if (affix.filter == null)
                //{
                //    Trace.WriteLine(affix.Option);
                //    
                //}
            }
        }
        //
        public void test()
        {
            //검색 할때 검색어 설정
            int inputValue = 789;
            string entry = "11testtest #% test 321 123";
            string option = SetOption(entry, inputValue);

            //아이템에서 값 가져오기
            int result = GetOptionValue(option, entry);
        }
        public string SetOption(string s, int value)
        {
            s = s.Replace("#", "{0}");
            return string.Format(s, value);
        }
        public int GetOptionValue(string options, string entry)
        {
            MatchCollection matches1 = Regex.Matches(options, @"[-]?([0-9]+\.[0-9]+|[0-9]+)");
            MatchCollection matches2 = Regex.Matches(entry, @"[-]?([0-9]+\.[0-9]+|[0-9]+|#)");
            int result = 0;
            for (int t = 0; t < matches2.Count; t++)
            {
                if (matches2[t].Value == "#")
                {
                    result = Int32.Parse(matches1[t].Value);
                    break;
                }
            }
            return result;
        }
    }
}
