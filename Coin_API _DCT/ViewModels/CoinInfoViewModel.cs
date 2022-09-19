using Coin_API__DCT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_API__DCT.ViewModels
{
    public class CoinInfoViewModel : ViewModelBase
    {
        private readonly Asset asset;

        public CoinInfoViewModel(Asset asset)
        {
            this.asset = asset;
        }

    }
}
