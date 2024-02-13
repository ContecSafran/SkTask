using Search;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public class Search
    {
        static public string toJson(string Name, string inputType, q_Stats_filters prefix, q_Stats_filters surffix)
        {
            string BeforeDayToString(int day)
            {
                if (day < 1)
                    return "any";
                else if (day < 3)
                    return "1day";
                else if (day < 7)
                    return "3days";
                else if (day < 14)
                    return "1week";
                return "2weeks";
            }

            try
            {
                JsonData jsonData = new JsonData();
                jsonData.Query = new q_Query();
                q_Query JQ = jsonData.Query;

                jsonData.Sort.Price = "asc";

                byte lang_index = 0;//(byte)itemOptions.LangIndex;
                string Inherit = inputType;

                JQ.Name = "";
                JQ.Type = Name;

                JQ.Stats = new q_Stats[0];
                JQ.Status.Option = "online";

                JQ.Filters.Type.Filters.Category.Option = Inherit;
                JQ.Filters.Type.Filters.Rarity.Option = "magic";
                //JQ.Filters.Type.Filters.Rarity.Option = itemOptions.RarityAt > 0 ? RS.lRarity.ElementAt(itemOptions.RarityAt - 1).Key.ToLower() : "any";

                JQ.Filters.Trade.Disabled = false;
                JQ.Filters.Trade.Filters.Indexed.Option = BeforeDayToString(8);
                JQ.Filters.Trade.Filters.SaleType.Option = "priced";
                JQ.Filters.Trade.Filters.Price.Max = 99999;
                JQ.Filters.Trade.Filters.Price.Min = 99999;

                JQ.Filters.Socket.Disabled = true;

                JQ.Filters.Socket.Filters.Links.Min = 99999;
                JQ.Filters.Socket.Filters.Links.Max = 99999;
                JQ.Filters.Socket.Filters.Sockets.Min = 99999;
                JQ.Filters.Socket.Filters.Sockets.Max = 99999;

                JQ.Filters.Misc.Filters.Quality.Min = 99999;
                JQ.Filters.Misc.Filters.Quality.Max = 99999;

                JQ.Filters.Misc.Filters.Ilvl.Min = 99999;
                JQ.Filters.Misc.Filters.Ilvl.Max = 99999;
                JQ.Filters.Misc.Filters.Gem_level.Min = 99999;
                JQ.Filters.Misc.Filters.Gem_level.Max = 99999;
                JQ.Filters.Misc.Filters.AlternateQuality.Option = "any";

                JQ.Filters.Misc.Filters.Shaper.Option = "any";
                JQ.Filters.Misc.Filters.Elder.Option = "any";
                JQ.Filters.Misc.Filters.Crusader.Option = "any";
                JQ.Filters.Misc.Filters.Redeemer.Option = "any";
                JQ.Filters.Misc.Filters.Hunter.Option = "any";
                JQ.Filters.Misc.Filters.Warlord.Option = "any";

                JQ.Filters.Misc.Filters.Synthesis.Option  = "any";
                JQ.Filters.Misc.Filters.Corrupted.Option = "any";

                JQ.Filters.Heist.Filters.HeistObjective.Option = "any";

                JQ.Filters.Heist.Disabled = JQ.Filters.Heist.Filters.HeistObjective.Option == "any";

                JQ.Filters.Misc.Disabled = true;

                JQ.Filters.Map.Disabled = true;

                JQ.Filters.Map.Filters.Tier.Min = 99999;
                JQ.Filters.Map.Filters.Tier.Max = 99999;
                JQ.Filters.Map.Filters.Shaper.Option = "any";
                JQ.Filters.Map.Filters.Elder.Option = "any";
                JQ.Filters.Map.Filters.Blight.Option = "any";

                JQ.Filters.Ultimatum.Disabled = true;

                bool error_filter = false;

                JQ.Stats = new q_Stats[1];
                JQ.Stats[0] = new q_Stats();
                JQ.Stats[0].Type = "and";
                JQ.Stats[0].Filters = new q_Stats_filters[2] { prefix, surffix };


                //if (!ckSocket.Dispatcher.CheckAccess())
                //else if (ckSocket.Dispatcher.CheckAccess())

                string sEntity = Json.Serialize<JsonData>(jsonData);

                sEntity = sEntity.Replace("\"name\":\"" + JQ.Name + "\",", "");

                sEntity = sEntity.RepEx("\"(min|max)\":99999|\"option\":(0|\"any\"|null)", "").RepEx("\"[a-z_]+\":{[,]*}", "");
                sEntity = sEntity.RepEx(",{2,}", ",").RepEx("({),{1,}", "$1").RepEx(",{1,}(}|])", "$1");
                return sEntity;
            }


            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Trace.WriteLine(String.Format("{0} 에러:  {1}\r\n\r\n{2}\r\n\r\n", ex.Source, ex.Message, ex.StackTrace));
                return "";
            }
        }
    }
}
