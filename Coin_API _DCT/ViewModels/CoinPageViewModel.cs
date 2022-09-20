using Coin_API__DCT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_API__DCT.ViewModels
{
    public class CoinPageViewModel : ViewModelBase
    {
        private string coinName;
        public string CoinName
        {
            get
            {
                return coinName;
            }

            set
            {
                coinName = value;
                OnPropertyChanged("CoinName");
            }
        }
        private string Id;
        public string ID
        {
            get
            {
                return Id;
            }

            set
            {
                Id = value;
                OnPropertyChanged("ID");
            }
        }
        private int? rank;
        public int? Rank
        {
            get
            {
                return rank;
            }

            set
            {
                rank = value;
                OnPropertyChanged("Rank");
            }
        }
        private string symbol;
        public string Symbol
        {
            get
            {
                return symbol;
            }

            set
            {
                symbol = value;
                OnPropertyChanged("Symbol");
            }
        }
        private decimal? supply;
        public decimal? Supply
        {
            get
            {
                return supply;
            }

            set
            {
                supply = value;
                OnPropertyChanged("Supply");
            }
        }
        private decimal? maxSupply;
        public decimal? MaxSupply
        {
            get
            {
                return maxSupply;
            }

            set
            {
                maxSupply = value;
                OnPropertyChanged("MaxSupply");
            }
        }
        private decimal? marketCapUsd;
        public decimal? MarketCapUsd
        {
            get
            {
                return marketCapUsd;
            }

            set
            {
                marketCapUsd = value;
                OnPropertyChanged("MarketCapUsd");
            }
        }
        private decimal? volumeUsd24Hr;
        public decimal? VolumeUsd24Hr
        {
            get
            {
                return volumeUsd24Hr;
            }

            set
            {
                volumeUsd24Hr = value;
                OnPropertyChanged("VolumeUsd24Hr");
            }
        }
        private decimal? priceUsd;
        public decimal? PriceUsd
        {
            get
            {
                return priceUsd;
            }

            set
            {
                priceUsd = value;
                OnPropertyChanged("PriceUsd");
            }
        }
        private double? changePercent24Hr;
        public double? ChangePercent24Hr
        {
            get
            {
                return changePercent24Hr;
            }

            set
            {
                changePercent24Hr = value;
                OnPropertyChanged("ChangePercent24Hr");
            }
        }
        private decimal? vwap24Hr;
        public decimal? Vwap24Hr
        {
            get
            {
                return vwap24Hr;
            }

            set
            {
                vwap24Hr = value;
                OnPropertyChanged("Vwap24Hr");
            }
        }
        private string explorer;
        public string Explorer
        {
            get
            {
                return explorer;
            }

            set
            {
                explorer = value;
                OnPropertyChanged("Explorer");
            }
        }

        public CoinPageViewModel(Asset asset)
        {
            Id = asset.Id;
            coinName = asset.Name;
            rank = asset.Rank;
            symbol = asset.Symbol;
            supply = asset.Supply;
            maxSupply = asset.MaxSupply;
            marketCapUsd = asset.MarketCapUsd;
            volumeUsd24Hr = asset.VolumeUsd24Hr;
            priceUsd = asset.PriceUsd;
            changePercent24Hr = asset.ChangePercent24Hr;
            vwap24Hr = asset.Vwap24Hr;
            explorer = asset.Explorer;
        }
    }
}
