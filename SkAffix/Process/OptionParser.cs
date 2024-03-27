using SkAffix.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SkAffix.Process
{
    public class OptionParser
    {
        public static void GetSearchItemOptionFilter(CurrentItemPrice price,string s, SearchItems searchItems,bool isPrefix, double value = 99999)
        {
            string ss;
            ConfigFile.LoadData(out ss);
            s = s.Replace((char)160, ' ');
            string input = s.RepEx(@"\s(\([a-zA-Z]+\)|—\s.+)$", "");
            string ft_type = s.Split(new string[] { "\n" }, 0)[0].RepEx(@"(.+)\s\(([a-zA-Z]+)\)$", "$2");
            if (!RS.lFilterType.ContainsKey(ft_type)) ft_type = "_none_";

            input = Regex.Escape(Regex.Replace(input, @"[+-]?[0-9]+\.[0-9]+|[+-]?[0-9]+", "#"));
            input = Regex.Replace(input, @"\\#", @"[+-]?([0-9]+\.[0-9]+|[0-9]+|\#)");

            Regex rgx = new Regex("^" + input + "$", RegexOptions.IgnoreCase);
            if (isPrefix)
            {
                Affix[] entriesAffix = Array.FindAll(searchItems.PrefixList.ToArray(), x => rgx.IsMatch(x.Option));
                price.prefix = entriesAffix.First();
                price.searchPrefixFilter = new q_Stats_filters()
                {
                    Disabled = false,
                    Id = price.prefix.filter.Id,
                    Value = (new q_Min_And_Max() { Min = value, Max = 99999 })
                };
            }
            else
            {
                Affix[] entriesAffix = Array.FindAll(searchItems.PrefixList.ToArray(), x => rgx.IsMatch(x.Option));
                price.surfix = entriesAffix.First();
                price.searchPrefixFilter = new q_Stats_filters()
                {
                    Disabled = false,
                    Id = price.surfix.filter.Id,
                    Value = (new q_Min_And_Max() { Min = value, Max = 99999 })
                };
            }
        }

        public static double GetOptionValue(string options, string entry)
        {
            MatchCollection matches1 = Regex.Matches(options, @"[-]?([0-9]+\.[0-9]+|[0-9]+)");
            MatchCollection matches2 = Regex.Matches(entry, @"[-]?([0-9]+\.[0-9]+|[0-9]+|#)");
            double result = 0;
            for (int t = 0; t < matches2.Count; t++)
            {
                if (matches2[t].Value == "#")
                {
                    result = Double.Parse(matches1[t].Value);
                    break;
                }
            }
            return result;
        }
        public static q_Stats_filters GetOptionFilter(string s)
        {
            string ss;
            ConfigFile.LoadData(out ss);
            s = s.Replace((char)160, ' ');
            string input = s.RepEx(@"\s(\([a-zA-Z]+\)|—\s.+)$", "");
            string ft_type = s.Split(new string[] { "\n" }, 0)[0].RepEx(@"(.+)\s\(([a-zA-Z]+)\)$", "$2");
            if (!RS.lFilterType.ContainsKey(ft_type)) ft_type = "_none_";

            input = Regex.Escape(Regex.Replace(input, @"[+-]?[0-9]+\.[0-9]+|[+-]?[0-9]+", "#"));
            input = Regex.Replace(input, @"\\#", @"[+-]?([0-9]+\.[0-9]+|[0-9]+|\#)");

            Regex rgx = new Regex("^" + input + "$", RegexOptions.IgnoreCase);
            foreach (FilterDict data_result in ConfigFile.mFilter[0].Result)
            {
                FilterDictItem[] entries = Array.FindAll(data_result.Entries, x => rgx.IsMatch(x.Text));
                if (entries.Length > 0)
                {
                    FilterDictItem item = entries.First();
                    return new q_Stats_filters()
                    {
                        Disabled = false,
                        Id = item.Id
                    };
                }
            }
            return null;
        }

       //public static q_Stats_filters toFilter(string input)
       //{
       //
       //
       //    input = Regex.Escape(Regex.Replace(input, @"[+-]?[0-9]+\.[0-9]+|[+-]?[0-9]+", "#"));
       //    input = Regex.Replace(input, @"\\#", @"[+-]?([0-9]+\.[0-9]+|[0-9]+|\#)");
       //
       //    bool local_exists = false;
       //    FilterDictItem filter = null;
       //    foreach (FilterDict data_result in ConfigFile.mFilter[0].Result)
       //    {
       //        FilterDictItem[] entries = Array.FindAll(data_result.Entries, x => rgx.IsMatch(x.Text));
       //        if (entries.Length > 0)
       //        {
       //            FilterDictItem item = entries.First();
       //            return new q_Stats_filters()
       //            {
       //                Disabled = false,
       //                Id = item.Id,
       //                Value = (new q_Min_And_Max() { Min = 9999, Max = 9999 })
       //            };
       //        }
       //    }
       //    return null;
       //}
    }
}
