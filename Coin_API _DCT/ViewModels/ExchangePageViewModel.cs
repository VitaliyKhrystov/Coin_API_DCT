using Coin_API__DCT.Models;
using Coin_API__DCT.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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

        public ExchangePageViewModel(string assetid)
        {
            CoinRepository = new CoinRepository("https://api.coincap.io/v2/exchanges");
            this.assetid = assetid;
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
