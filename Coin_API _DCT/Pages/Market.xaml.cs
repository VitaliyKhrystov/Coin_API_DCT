using Coin_API__DCT.Models;
using Coin_API__DCT.ViewModels;
using System.Windows.Controls;


namespace Coin_API__DCT.Pages
{
    /// <summary>
    /// Interaction logic for Market.xaml
    /// </summary>
    public partial class Market : Page
    {
        public Market(Asset asset)
        {
            InitializeComponent();
            DataContext = new MarketPageViewModel(asset);
        }
    }
}
