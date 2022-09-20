using Coin_API__DCT.Models;
using System.Collections.ObjectModel;


namespace Coin_API__DCT.ViewModels
{
    public class ExchangePageViewModel : ViewModelBase
    {
        public string assetid { get; set; }
        public CoinRepository CoinRepository { get; set; }
        private Coin_API__DCT.Models.Exchange exchangeItem;
        public Coin_API__DCT.Models.Exchange ExchangeItem 
        {
            get
            {
                return exchangeItem;
            }

            set
            {
                exchangeItem = value;
                OnPropertyChanged("ExchangeItem");
            }
        }

        public ExchangePageViewModel(Asset asset)
        {
            CoinRepository = new CoinRepository("https://api.coincap.io/v2/exchanges");
            this.assetid = asset.Id;
        }

        ObservableCollection<Coin_API__DCT.Models.Exchange> allExchanges;

        public ObservableCollection<Coin_API__DCT.Models.Exchange> AllExchanges
        {
            get
            {
                if (allExchanges == null)
                    allExchanges = CoinRepository.GetAllExchanges();
                return allExchanges;
            }

            set
            {
                allExchanges = value;
                OnPropertyChanged("AllExchanges");
            }

        }
    }
}
