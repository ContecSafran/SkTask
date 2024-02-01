using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkAffix.Dto;
using System;
using System.Collections.Generic;

namespace SkTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InitItems()
        {
            SkAffix.Process.ItemCsv itemCsv = new SkAffix.Process.ItemCsv();
            List<Item>  items = itemCsv.getItems();
        }
    }
}
