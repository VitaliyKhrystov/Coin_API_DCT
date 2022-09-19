using Coin_API__DCT.Models;
using Coin_API__DCT.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Coin_API__DCT.ViewModels
{
    public class CoinInfoViewModel : ViewModelBase
    {
        private readonly Asset asset;
        private Page Coin { get; set; }
        private Page Market { get; set; }
        private Page Rate { get; set; }
        private Page Exchange { get; set; }
        private Page History { get; set; }
        private Page currentPage;
        public Page CurrentPage
        {
            get
            {
                return currentPage;
            }

            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        public CoinInfoViewModel(Asset asset)
        {
            this.asset = asset;
            Coin = new Coin();
            Market = new Market();
            Rate = new Rate();
            Exchange = new Exchange();
            History = new Page();
            CurrentPage = Coin;
        }

        #region Command MainClick

        RelayCommand mainClick;
        public ICommand MainClick
        {
            get
            {
                if (mainClick == null)
                    mainClick = new RelayCommand(
                        r => { CurrentPage = Coin; },

                        t => {
                            if (CurrentPage == null)
                                return false;
                            return true;
                        });
                return mainClick;
            }
        }

        #endregion

        #region Command MarketClick

        RelayCommand marketClick;
        public ICommand MarketClick
        {
            get
            {
                if (marketClick == null)
                    marketClick = new RelayCommand(
                        r => { CurrentPage = Market; },

                        t => {
                            if (marketClick == null)
                                return false;
                            return true;
                        });
                return marketClick;
            }
        }

        #endregion

        #region Command RateClick

        RelayCommand rateClick;
        public ICommand RateClick
        {
            get
            {
                if (rateClick == null)
                    rateClick = new RelayCommand(
                        r => { CurrentPage = Rate; },

                        t => {
                            if (rateClick == null)
                                return false;
                            return true;
                        });
                return rateClick;
            }
        }

        #endregion

        #region Command ExchangeClick

        RelayCommand exchangeClick;
        public ICommand ExchangeClick
        {
            get
            {
                if (exchangeClick == null)
                    exchangeClick = new RelayCommand(
                        r => { CurrentPage = Exchange; },

                        t => {
                            if (exchangeClick == null)
                                return false;
                            return true;
                        });
                return exchangeClick;
            }
        }

        #endregion

        #region Command HistoryClick

        RelayCommand historyClick;
        public ICommand HistoryClick
        {
            get
            {
                if (historyClick == null)
                    historyClick = new RelayCommand(
                        r => { CurrentPage = History; },

                        t => {
                            if (historyClick == null)
                                return false;
                            return true;
                        });
                return historyClick;
            }
        }

        #endregion
    }
}
