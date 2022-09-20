using Coin_API__DCT.Models;
using Coin_API__DCT.ViewModels;
using System.Windows.Controls;


namespace Coin_API__DCT.Pages
{
    /// <summary>
    /// Interaction logic for Coin.xaml
    /// </summary>
    public partial class Coin : Page
    {
        public Coin(Asset asset)
        {
            InitializeComponent();
            DataContext = new CoinPageViewModel(asset);
        }
    }
}
