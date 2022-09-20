using Coin_API__DCT.Models;
using Coin_API__DCT.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Coin_API__DCT.ViewModels
{
    public class ExchangePageViewModel : ViewModelBase
    {
        public string id { get; set; }
        public CoinRepository CoinRepository { get; set; }
        private Exchange exchange;
        public Exchange Exchange 
        {
            get
            {
                if (exchange == null)
                {
                    return exchange = CoinRepository.GetCoinById(id);
                }
                return exchange;
            }

            set
            {
                exchange = value;
                OnPropertyChanged("Exchange");
            }
        }

        public ExchangePageViewModel(string id)
        {
            CoinRepository = new CoinRepository($"https://api.coincap.io/v2/exchanges/{id}");
            this.id = id;
        }

    }
}
