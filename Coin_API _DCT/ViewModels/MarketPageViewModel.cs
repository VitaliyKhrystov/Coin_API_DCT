using Coin_API__DCT.Models;
using System.Collections.ObjectModel;


namespace Coin_API__DCT.ViewModels
{
    public class MarketPageViewModel : ViewModelBase
    {
        public string CoinName { get; set; }
        public CoinRepository CoinRepository { get; set; }
        private Market marketItem;
        public Market MarketItem
        {
            get
            {
                return marketItem;
            }

            set
            {
                marketItem = value;
                OnPropertyChanged("MarketItem");
            }
        }

        public MarketPageViewModel(Asset asset)
        {
            CoinName = $"Markets. Coin - {asset.Name}";
            CoinRepository = new CoinRepository($"https://api.coincap.io/v2/assets/{asset.Id}/markets");
        }

        ObservableCollection<Market> marketList;

        public ObservableCollection<Market> MarketList
        {
            get
            {
                if (marketList == null)
                    marketList = CoinRepository.GetMarket();
                return marketList;
            }

            set
            {
                marketList = value;
                OnPropertyChanged("MarketList");
            }

        }
    }
}
