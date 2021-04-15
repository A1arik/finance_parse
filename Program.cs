using System;
using System.Collections.Generic;
using financeParse.DB;
using financeParse.DB.Entities;
using Newtonsoft.Json.Linq;

namespace financeParse
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://www.investing.com/equities/apple-computer-inc";
            string priceUrl = "https://api.investing.com/api/financialdata/6408/historical/chart/?period=P3M&interval=P1D&pointscount=120";

            FinanceParser fParser = new FinanceParser();
            AddInfo(fParser.GetTable(url));
            AddPrice(fParser.GetPrice(priceUrl));


        }


        static void AddPrice(JToken data)
        {
            using (TestDbContext db = new TestDbContext())
            {
                foreach (var item in data)
                {
                    db.Price.Add(new Price()
                    {
                        Date = (new DateTime(1970, 1, 1)).AddMilliseconds((double)item[0]).ToShortDateString(),
                        Open = (float)item[1],
                        High = (float)item[2],
                        Low = (float)item[3],
                        Close = (float)item[4],
                    });
                };

                db.SaveChanges();
            }
        }
        
        static void AddInfo(Dictionary<string,string> data)
        {
            using (TestDbContext db = new TestDbContext())
            {
                db.Info.Add(new Info()
                {
                    PrevClose = float.Parse(data["Prev. Close"]),
                    DaysRange = data["Day's Range"],
                    Revenue = data["Revenue"],
                    Open = float.Parse(data["Open"]),
                    FiftyTwoWkRange = data["52 wk Range"],
                    EPS = float.Parse(data["EPS"]),
                    Volume = double.Parse(data["Volume"]),
                    MarketCap = data["Market Cap"],
                    Dividend = decimal.Parse(data["Dividend (Yield)"]),
                    AverageVolFor3Months = double.Parse(data["Average Vol. (3m)"]),
                    PERation = float.Parse(data["P/E Ratio"]),
                    Beta = float.Parse(data["Beta"]),
                    OneYearChange = decimal.Parse(data["1-Year Change"]),
                    SharesOutstanding = double.Parse(data["Shares Outstanding"]),
                    NextEarningsDate = Convert.ToDateTime(data["Next Earnings Date"])

            });
                db.SaveChanges();
            }
        }

    }

 
}
