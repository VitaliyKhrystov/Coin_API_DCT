using Coin_API__DCT.Models;
using Coin_API__DCT.ViewModels;
using System.Windows;


namespace Coin_API__DCT.Views
{
    /// <summary>
    /// Interaction logic for CoinInfo.xaml
    /// </summary>
    public partial class CoinInfo : Window
    {
        public CoinInfo(Asset selectedCoin)
        {
            InitializeComponent();
            this.Title = selectedCoin.Name;
            DataContext = new CoinInfoViewModel(selectedCoin);
        }
    }
}
