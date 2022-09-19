using Coin_API__DCT.Models;
using Coin_API__DCT.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Input;

namespace Coin_API__DCT.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string selectedAPI = "https://api.coincap.io/v2/assets";
        private int number;
        public int Number
        {
            get { return number; }
            set
            {
                if (value > 0)
                {
                    number = value;
                }
            }
        }

        public CoinRepository coinRepository { get; set; }
        public string SearchText { get; set; }


        private Asset selectedCoin;
        public Asset SelectedCoin
        {
            get
            {
                return selectedCoin;
            }

            set
            {
                selectedCoin = value;
                OnPropertyChanged("SelectedCoin");
                GetNewWindow(selectedCoin);
            }
        }

        public MainWindowViewModel()
        {
            coinRepository = new CoinRepository(selectedAPI);
            Number = 10;
        }

        #region Get n-Coins
        ObservableCollection<Asset> nCoins;
        public ObservableCollection<Asset> Ncoins
        {
            get
            {
                if (nCoins == null)
                    nCoins = coinRepository.GetNCoins(Number);
                return nCoins;
            }
        }
        #endregion

        #region Get All coins

        ObservableCollection<Asset> allCoins;

        public ObservableCollection<Asset> AllCoins
        {
            get
            {
                if (allCoins == null)
                    allCoins = coinRepository.GetAllCoins();
                return allCoins;
            }

            set
            {
                allCoins = value;
                OnPropertyChanged("AllCoins");
            }

        }

        #endregion

        #region Command ClikSearch

        RelayCommand clikSearch;
        public ICommand ClikSearch
        {
            get
            {
                if (clikSearch == null)
                    clikSearch = new RelayCommand(
                        r => { AllCoins = coinRepository.SearchCoin(SearchText); },

                        t => {
                            if (AllCoins == null)
                                return false;
                            return true;
                        });
                return clikSearch;
            }
        }

        #endregion

        private void GetNewWindow(Asset coin)
        {
            Thread newWindowThread = new Thread(
                () =>
                {
                    CoinInfo coinInfo = new CoinInfo(coin);
                    coinInfo.ShowDialog();
                    System.Windows.Threading.Dispatcher.Run();
                });
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();
        }

    }
}
