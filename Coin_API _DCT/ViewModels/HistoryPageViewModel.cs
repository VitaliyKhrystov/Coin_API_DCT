using Coin_API__DCT.Models;

using System.Collections.ObjectModel;


namespace Coin_API__DCT.ViewModels
{
    public class HistoryPageViewModel : ViewModelBase
    {
        public CoinRepository CoinRepository { get; set; }
        public string CoinName { get; set; }
        private AssetHistory historyItem;
        public AssetHistory HistoryItem
        {
            get
            {
                return historyItem;
            }

            set
            {
                historyItem = value;
                OnPropertyChanged("HistoryItem");
            }
        }

        public HistoryPageViewModel(Asset asset)
        {
            CoinName = $"History - Id: {asset.Id}, Name: {asset.Name}";
            CoinRepository = new CoinRepository($"https://api.coincap.io/v2/assets/{asset.Id}/history?interval=d1");
        }

        ObservableCollection<AssetHistory> historyList;

        public ObservableCollection<AssetHistory> HistoryList
        {
            get
            {
                if (historyList == null)
                    historyList = CoinRepository.GetHistoryList();
                return historyList;
            }

            set
            {
                historyList = value;
                OnPropertyChanged("HistoryList");
            }

        }
    }
}
