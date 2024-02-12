using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
