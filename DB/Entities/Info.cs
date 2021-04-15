using System;
using System.ComponentModel.DataAnnotations;

namespace financeParse.DB.Entities
{
    public class Info
    {
        public int Id { get; set; }
        public float PrevClose { get; set; }
        public string DaysRange { get; set; }
        public string Revenue { get; set; }
        public float Open { get; set; }
        public string FiftyTwoWkRange { get; set; }
        public float EPS { get; set; }
        public double Volume { get; set; }
        public string MarketCap { get; set; }
        public decimal Dividend { get; set; }
        public double AverageVolFor3Months { get; set; }
        public float PERation { get; set; }
        public float Beta { get; set; }
        public decimal OneYearChange { get; set; }
        public double SharesOutstanding { get; set; }
        public DateTime NextEarningsDate { get; set; }
    }
}
