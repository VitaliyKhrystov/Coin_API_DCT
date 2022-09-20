using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_API__DCT.Models
{
    public class Rate
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string CurrencySymbol { get; set; }
        public decimal? rateUsd { get; set; }
        public string Type { get; set; }
    }
}
