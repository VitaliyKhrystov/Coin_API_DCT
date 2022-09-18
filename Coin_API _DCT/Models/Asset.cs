﻿

namespace Coin_API__DCT.Models
{
    public class Asset
    {
        public string Id { get; set; }
        public int? Rank { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal? Supply { get; set; }
        public decimal? MaxSupply { get; set; }
        public decimal? MarketCapUsd { get; set; }
        public decimal? VolumeUsd24Hr { get; set; }
        public decimal? PriceUsd { get; set; }
        public double? ChangePercent24Hr { get; set; }
        public decimal? Vwap24Hr { get; set; }
        public string Explorer { get; set; }

    }
}
