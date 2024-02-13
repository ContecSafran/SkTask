using Microsoft.VisualStudio.TestTools.UnitTesting;
using Search;
using SkAffix.Dto;
using SkAffix.Process;
using System;
using System.Collections.Generic;

namespace SkTest
{
    [TestClass]
    public class ItemOptionTest
    {
        [TestMethod]
        public void SingleOptionAndSingleValueTest()
        {
            OptionManager optionManager = new OptionManager();

            int inputValue = 789;
            string entry = "11testtest #% test 321 123";
            string option = optionManager.SetOption(entry, inputValue); 

            int result = optionManager.GetOptionValue(option, entry);
            Assert.AreEqual(inputValue, result);
        }

        [TestMethod]
        public void TextSearchTest()
        {
            List<string> SearchList = new List<string>() {"Wayne", "Wayn", "ayne", "Way", "ayn", "yne", "wayne", "wayn" };
            string input = "Wayne_";
            string s = SearchList.Find(x => input.Contains(x));
            int dd = 0;
        }
        [TestMethod]
        public void searchTest()
        {
            //Search.ConfigFile.LoadData()
            string refStr = "{\"query\":{\"filters\":{\"armour_filters\":{\"disabled\":true},\"heist_filters\":{\"disabled\":true,\"filters\":{}},\"map_filters\":{\"disabled\":true,\"filters\":{}},\"misc_filters\":{\"disabled\":true,\"filters\":{}},\"req_filters\":{\"disabled\":true},\"socket_filters\":{\"disabled\":true,\"filters\":{}},\"trade_filters\":{\"disabled\":false,\"filters\":{\"indexed\":{\"option\":\"1week\"},\"sale_type\":{\"option\":\"priced\"}}},\"type_filters\":{\"filters\":{\"category\":{\"option\":\"flask\"},\"rarity\":{\"option\":\"magic\"}}},\"ultimatum_filters\":{\"disabled\":true,\"filters\":{}},\"weapon_filters\":{\"disabled\":true}},\"stats\":[{\"filters\":[{\"disabled\":false,\"id\":\"pseudo.pseudo_number_of_empty_prefix_mods\"},{\"disabled\":false,\"id\":\"explicit.stat_962725504\",\"value\":{\"max\":39,\"min\":39}}],\"type\":\"and\"}],\"type\":\"자수정 플라스크\",\"status\":{\"option\":\"online\"}},\"sort\":{\"price\":\"asc\"}}";
            q_Stats_filters prefixFilter = Search.OptionParser.GetOptionFilter("# 빈 접두어 속성 부여");
            q_Stats_filters suffixFilter = Search.OptionParser.GetOptionFilter("효과를 받는 동안 추가 원소 저항 #%", 39);
            string output = Search.Search.toJson("자수정 플라스크", "flask", prefixFilter, suffixFilter);
            Assert.AreEqual(refStr, output);

        }

    }
}
