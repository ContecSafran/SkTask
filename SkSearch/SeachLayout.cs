using SkAffix.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkSearch
{
    public partial class SeachLayout : Form
    {
        SearchItems searchItems;
        Dictionary<Item, List<Price>> priceLayout;
        SearchItemCheckBox selectItem;
        SearchItemCheckBox selectAffix;
        public SeachLayout(SearchItems searchItems, Dictionary<Item, List<Price>> priceLayout)
        {
            InitializeComponent();
            this.searchItems = searchItems;
            this.priceLayout = priceLayout;

            selectAffix = new SearchItemCheckBox();
            selectAffix.Dock = DockStyle.Top;
            SelectPanel.Controls.Add(selectAffix);
            selectItem = new SearchItemCheckBox();
            selectItem.Dock = DockStyle.Top;
            SelectPanel.Controls.Add(selectItem);

            for (int i = 0; i < searchItems.ItemList.Count; i++)
            {
                SearchItem searchItem = new SearchItem();
                searchItem.dtoBase = searchItems.ItemList[i];
                searchItem.Dock = DockStyle.Top;
                searchItem.Select += SelectSearchItem;
                ItemPanel.Controls.Add(searchItem);
            }


            for (int i = 0; i < searchItems.PrefixList.Count; i++)
            {
                SearchItem searchItem = new SearchItem();
                searchItem.dtoBase = searchItems.PrefixList[i];
                searchItem.Dock = DockStyle.Top;
                searchItem.Select += SelectSearchPrefix;
                PrefixPanel.Controls.Add(searchItem);
            }


            for (int i = 0; i < searchItems.SuffixList.Count; i++)
            {
                SearchItem searchItem = new SearchItem();
                searchItem.dtoBase = searchItems.SuffixList[i];
                searchItem.Dock = DockStyle.Top;
                searchItem.Select += SelectSearchSuffix;
                SuffixPanel.Controls.Add(searchItem);
            }
            
        }

        private void SelectSearchPrefix(DtoBase dtoBaseValue)
        {
            selectAffix.dtoBase = dtoBaseValue;
        }

        private void SelectSearchSuffix(DtoBase dtoBaseValue)
        {
            selectAffix.dtoBase = dtoBaseValue;
        }

        private void SelectSearchItem(DtoBase dtoBaseValue)
        {
            selectItem.dtoBase = dtoBaseValue;
        }
    }
}
