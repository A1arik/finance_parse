using System;
using System.ComponentModel.DataAnnotations;

namespace financeParse.DB.Entities
{
    public class Price
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
    }
}
