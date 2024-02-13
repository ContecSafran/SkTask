using Search;
using SkAffix.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Search
{
    public class Search
    {
        static ConfigOption configOption = new ConfigOption();
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

        private List<SkAffix.Dto.Currency> UpdatePrice(string league, int langIndex, string[] entity, int listCount)
        {
            string url_string = "";
            string json_entity = "";
            string msg = "정보가 없습니다";
            string msg_2 = "";
            List<SkAffix.Dto.Currency> price = new List<SkAffix.Dto.Currency>();

            try
            {
                if (entity.Length > 0 && !string.IsNullOrEmpty(entity[0]))
                {
                    if (entity.Length == 1)
                    {
                        url_string = RS.TradeApi[langIndex] + league;
                        json_entity = entity[0];
                    }
                    else
                    {
                        url_string = RS.ExchangeApi[langIndex] + league;
                        json_entity = "{\"exchange\":{\"status\":{\"option\":\"online\"},\"have\":[\"" + entity[0] + "\"],\"want\":[\"" + entity[1] + "\"]}}";
                    }
                    string request_result = Api.SendHTTP(json_entity, url_string, configOption.ServerTimeout);
                    msg = "현재 리그의 거래소 접속이 원활하지 않습니다";

                    if (request_result != null)
                    {
                        ResultData resultData = Json.Deserialize<ResultData>(request_result);
                        Dictionary<string, int> currencys = new Dictionary<string, int>();

                        int total = 0;
                        int resultCount = resultData.Result.Length;

                        if (resultData.Result.Length > 0)
                        {
                            string ents0 = "", ents1 = "";

                            if (entity.Length > 1)
                            {
                                //listCount = listCount + 2;
                                ents0 = Regex.Replace(entity[0], @"(timeless-)?([a-z]{3})[a-z\-]+\-([a-z]+)", @"$3`$2");
                                ents1 = Regex.Replace(entity[1], @"(timeless-)?([a-z]{3})[a-z\-]+\-([a-z]+)", @"$3`$2");
                            }

                            for (int x = 0; x < listCount; x++)
                            {
                                string[] tmp = new string[10];
                                int cnt = x * 10;
                                int length = 0;

                                if (cnt >= resultData.Result.Length)
                                    break;

                                for (int i = 0; i < 10; i++)
                                {
                                    if (i + cnt >= resultData.Result.Length)
                                        break;

                                    tmp[i] = resultData.Result[i + cnt];
                                    length++;
                                }

                                string json_result = "";
                                string url = RS.FetchApi[langIndex] + tmp.Join(',') + "?query=" + resultData.ID;
                                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                                request.CookieContainer = new CookieContainer();
                                request.UserAgent = RS.UserAgent;
                                request.Timeout = configOption.ServerTimeout * 1000;
                                //request.UseDefaultCredentials = true;

                                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                                using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                                {
                                    json_result = streamReader.ReadToEnd();
                                }

                                if (json_result != "")
                                {
                                    FetchData fetchData = new FetchData();
                                    fetchData.Result = new FetchInfo[10];

                                    fetchData = Json.Deserialize<FetchData>(json_result);

                                    for (int i = 0; i < fetchData.Result.Length; i++)
                                    {
                                        if (fetchData.Result[i] == null)
                                            break;

                                        if (fetchData.Result[i].Listing.Price != null && fetchData.Result[i].Listing.Price.Amount > 0)
                                        {
                                            string key = "";
                                            string indexed = fetchData.Result[i].Listing.Indexed;
                                            string account = fetchData.Result[i].Listing.Account.Name;
                                            string currency = fetchData.Result[i].Listing.Price.Currency;
                                            double amount = fetchData.Result[i].Listing.Price.Amount;
                                            SkAffix.Constants.Currency selectedCurrency = currency.Equals("divine") ? SkAffix.Constants.Currency.Divine: SkAffix.Constants.Currency.Chaos;
                                            /*
                                            liPrice.Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)delegate ()
                                            {
                                                ParserDictItem item = GetExchangeItem(currency);
                                                string keyName = item != null ? item.Text[0] : currency;

                                                if (entity.Length > 1)
                                                {
                                                    item = GetExchangeItem(entity[1]);
                                                    string tName2 = item != null ? item.Text[0] : entity[1];
                                                    liPrice.Items.Add(Math.Round(1 / amount, 4) + " " + tName2 + " <-> " + Math.Round(amount, 4) + " " + keyName + " [" + account + "]");
                                                }
                                                else
                                                {
                                                    liPrice.Items.Add((
                                                        String.Format(
                                                            "{0} [{1}] {2}", (amount + " " + keyName).PadRight(14, '\u2000'), account, GetLapsedTime(indexed).PadRight(10, '\u2000'))
                                                        )
                                                    );
                                                }
                                            });
                                            */
                                            if (entity.Length > 1)
                                                key = amount < 1 ? Math.Round(1 / amount, 1) + " " + ents1 : Math.Round(amount, 1) + " " + ents0;
                                            else
                                                key = Math.Round(amount - 0.1) + " " + currency;

                                            if (currencys.ContainsKey(key))
                                            {
                                                currencys[key]++;
                                                price.FirstOrDefault(s => s.currency == selectedCurrency).count++;
                                            }
                                            else
                                            {

                                                SkAffix.Dto.Currency newPrice = new SkAffix.Dto.Currency();
                                                newPrice.currency = selectedCurrency;
                                                newPrice.num = (int)Math.Round(amount - 0.1);
                                                newPrice.count = 1;
                                                currencys.Add(key, 1);
                                                price.Add(newPrice);
                                            }

                                            total++;
                                        }
                                    }
                                }

                            }

                            if (currencys.Count > 0)
                            {
                                List<KeyValuePair<string, int>> myList = new List<KeyValuePair<string, int>>(currencys);
                                string first = ((KeyValuePair<string, int>)myList[0]).Key;
                                string last = ((KeyValuePair<string, int>)myList[myList.Count - 1]).Key;

                                myList.Sort(
                                    delegate (KeyValuePair<string, int> firstPair,
                                    KeyValuePair<string, int> nextPair)
                                    {
                                        return -1 * firstPair.Value.CompareTo(nextPair.Value);
                                    }
                                );

                                for (int i = 0; i < myList.Count; i++)
                                {
                                    if (i == 2) break;
                                    if (myList[i].Value < 2) continue;
                                    msg_2 += myList[i].Key + "[" + myList[i].Value + "], ";
                                }

                                msg = Regex.Replace(first + " ~ " + last, @"(timeless-)?([a-z]{3})[a-z\-]+\-([a-z]+)", @"$3`$2");
                                msg_2 = Regex.Replace(msg_2.TrimEnd(',', ' '), @"(timeless-)?([a-z]{3})[a-z\-]+\-([a-z]+)", @"$3`$2");

                                //currencys.FirstOrDefault(x => x.Value == currencys.Max(y => y.Value)).
                                if (msg_2 == "") msg_2 = "가장 많은 수 없음";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
            }
            return price;
        }
    }
}
