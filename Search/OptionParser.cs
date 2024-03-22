using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Search
{
    public class OptionParser
    {
        public static q_Stats_filters GetOptionFilter(string s, double Value = 99999)
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
                        Id = item.Id,
                        Value = (new q_Min_And_Max() { Min = Value, Max = Value }) 
                    };
                }
            }
            return null;
        }
    }
}
