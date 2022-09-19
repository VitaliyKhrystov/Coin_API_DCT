using Coin_API__DCT.Models;
using System.Collections.Generic;
using System.Windows.Input;

namespace Coin_API__DCT.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
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

        public MainWindowViewModel()
        {
            coinRepository = new CoinRepository();
            Number = 10;
        }

        #region Get n-Coins
        IEnumerable<Asset> nCoins;
        public IEnumerable<Asset> Ncoins
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

        IEnumerable<Asset> allCoins;

        public IEnumerable<Asset> AllCoins
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

    }
}
