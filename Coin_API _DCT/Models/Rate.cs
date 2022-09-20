using System;


namespace Coin_API__DCT.Models
{
    public class Rate
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string CurrencySymbol { get; set; }
        public object RateUsd { get; set; }
        public string Type { get; set; }
    }
}
