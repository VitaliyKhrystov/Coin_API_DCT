using System;

namespace Coin_API__DCT.Models
{
    public class Exchange
    {
        public string ExchangeId { get; set; }
        public string Name { get; set; }
        public int? Rank { get; set; }
        public double? PercentTotalVolume { get; set; }
        public decimal? VolumeUsd { get; set; }
        public int? TradingPairs { get; set; }
        public object Socket { get; set; }
        public string ExchangeUrl { get; set; }
        public object Updated { get; set; }
      
    }
}
