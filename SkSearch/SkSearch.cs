using Action;
using Action.Network;
using SkAffix.Dto;
using SkAffix.Process;
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
    public partial class SkSearch : FormBase
    {
        TaskClient taskClient = new TaskClient();

        string itemType = "flask";
        SearchItems searchItems;
        public SkSearch()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PositionList
            // 
            this.PositionList.Size = new System.Drawing.Size(139, 100);
            // 
            // CommandLog
            // 
            this.CommandLog.Size = new System.Drawing.Size(217, 100);
            // 
            // MainPanel
            // 
            // 
            // MainPanel.ContentPanel
            // 
            this.MainPanel.ContentPanel.Size = new System.Drawing.Size(360, 465);
            this.MainPanel.Size = new System.Drawing.Size(360, 465);
            // 
            // FollowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(360, 465);
            this.Name = "FollowForm";
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        protected override void Form_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        protected override void InitForm()
        {
            searchItems = OptionManager.getItems(itemType);
            Dictionary<Item, List<Price>> result = SearchAllItem(searchItems);

            SeachLayout seachLayout = new SeachLayout(searchItems, result);
            seachLayout.Show();
            //base.InitForm();
            //Action.Info.Setting.IsServer = false;
            //this.InitializeComponent();
            //taskClient.ClientStart();
        }
        protected override void AddAction()
        {
            AddAction(new Action.Alter());
            base.AddAction();
        }


        public static Dictionary<Item, List<Price>> SearchAllItem(SearchItems searchItems)
        {
            string itemType = "flask";
            searchItems.search = false;
            return GetPriceItemLoop(searchItems);
        }
        private static Dictionary<Item, List<Price>> GetPriceItemLoop(SearchItems searchItems)
        {
            Dictionary<Item, List<Price>> ItemDic = new Dictionary<Item, List<Price>>();
            for (int i = 0; i < searchItems.ItemList.Count; i++)
            {
                List<Price> prices = GetPriceAffixLoop(searchItems, searchItems.ItemList[i]);
                ItemDic.Add(searchItems.ItemList[i], prices);
            }
            return ItemDic;
        }
        private static List<Price> GetPriceAffixLoop(SearchItems searchItems, Item item)
        {
            List<Price> prices = new List<Price>();
            for (int p = 0; p < searchItems.PrefixList.Count; p++)
            {
                for (int s = 0; s < searchItems.SuffixList.Count; s++)
                {
                    if (searchItems.PrefixList[p].filter == null || searchItems.SuffixList[s].filter == null)
                    {
                        continue;
                    }
                    GetPriceRangeLoop(item, searchItems.PrefixList[p], searchItems.SuffixList[s], prices, searchItems.search);
                }
            }
            return prices;
        }
        private static void GetPriceRangeLoop(
            Item item,
            Affix prefix,
            Affix suffix,
            List<Price> prices,
            bool search)
        {
            if (prefix.IsRange)
            {
                if (suffix.IsRange)
                {
                    prices.Add(GetPrice(item, prefix, suffix, search, prefix.Min, suffix.Min));
                    //  prices.Add(SearchItem.GetPrice(item, prefix, suffix, prefix.Max, suffix.Max));
                }
                else
                {
                    prices.Add(GetPrice(item, prefix, suffix, search, prefix.Min));
                    //  prices.Add(SearchItem.GetPrice(item, prefix, suffix, prefix.Max));
                }
                /*
                for (double pr = prefix.Min; pr <= prefix.Max; pr += 1.0)
                {
                    if (suffix.IsRange)
                    {
                        prices.Add(SearchItem.GetPrice(item, prefix, suffix, pr, suffix.Min));
                        prices.Add(SearchItem.GetPrice(item, prefix, suffix, pr, suffix.Max));

                        for (double sr = suffix.Min; sr <= suffix.Max; sr += 1.0)
                        {
                            prices.Add(SearchItem.GetPrice(item, prefix, suffix, pr, sr));
                        }
                    }
                    else
                    {
                        prices.Add(SearchItem.GetPrice(item, prefix, suffix, pr));
                    }
                }*/
            }
            else
            {
                if (suffix.IsRange)
                {
                    prices.Add(GetPrice(item, prefix, suffix, search, 99999, suffix.Min));
                    //prices.Add(SearchItem.GetPrice(item, prefix, suffix, 99999, suffix.Max));
                }
                else
                {
                    prices.Add(GetPrice(item, prefix, suffix, search));
                }
                /*
                if (suffix.IsRange)
                {
                    for (double sr = suffix.Min; sr <= suffix.Max; sr += 1.0)
                    {
                        prices.Add(SearchItem.GetPrice(item, prefix, suffix, 99999, sr));
                    }
                }
                else
                {
                    prices.Add(SearchItem.GetPrice(item, prefix, suffix));
                }*/
            }
        }

        public static Price GetPrice(Item item, Affix prefix, Affix suffix, bool search, double prefixValue = 99999, double surfixValue = 99999)
        {
            // Thread.Sleep(5000);
            prefix.filter.Value = new q_Min_And_Max() { Min = prefixValue, Max = prefixValue };
            suffix.filter.Value = new q_Min_And_Max() { Min = surfixValue, Max = surfixValue };
            //인풋 파일에서 c2 a0를 20으로 변경해야함
            q_Stats_filters prefixFilter = prefix.filter;
            q_Stats_filters suffixFilter = suffix.filter;

            string output = Search.toJson(item.Name, "flask", prefixFilter, suffixFilter);
            List<SkAffix.Dto.Currency> price = search ? Search.UpdatePrice("Affliction", 0, output, 5) : null;
            Price result = new Price()
            {
                ItemId = item.id,
                PrefixId = prefix.id,
                PrefixValue = prefixValue,
                SuffixId = suffix.id,
                SuffixValue = surfixValue,
                Result = price,
                date = DateTime.Now,
            };
            return result;
        }
        static private byte[] StringToByte(string str)
        {
            byte[] StrByte = Encoding.UTF8.GetBytes(str);
            return StrByte;
        }
    }
}
