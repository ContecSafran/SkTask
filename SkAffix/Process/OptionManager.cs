using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SkAffix.Process
{
    public class OptionManager
    {
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
