using Coin_API__DCT.Models;
using System.Collections.ObjectModel;


namespace Coin_API__DCT.ViewModels
{
    public class RatePageViewModel : ViewModelBase
    {
        public CoinRepository CoinRepository { get; set; }
        private Coin_API__DCT.Models.Rate rateItem;
        public Coin_API__DCT.Models.Rate RateItem
        {
            get
            {
               return rateItem;
            }

            set
            {
                rateItem = value;
                OnPropertyChanged("RateItem");
            }
        }

        public RatePageViewModel(Asset asset)
        {
            CoinRepository = new CoinRepository("https://api.coincap.io/v2/rates");
        }

        ObservableCollection<Coin_API__DCT.Models.Rate> rateList;

        public ObservableCollection<Coin_API__DCT.Models.Rate> RateList
        {
            get
            {
                if (rateList == null)
                    rateList = CoinRepository.GetRates();
                return rateList;
            }

            set
            {
                rateList = value;
                OnPropertyChanged("RateList");
            }

        }
    }
}
