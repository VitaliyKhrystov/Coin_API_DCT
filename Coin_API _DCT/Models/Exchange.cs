using System;

namespace Coin_API__DCT.Models
{
    public class Exchange
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Rank { get; set; }
        public double? PercentTotalVolume { get; set; }
        public decimal? VolumeUsd { get; set; }
        public int? TradingPairs { get; set; }
        public bool Socket { get; set; }
        public string ExchangeUrl { get; set; }
        public DateTimeOffset Updated { get; set; }
      
    }
}
