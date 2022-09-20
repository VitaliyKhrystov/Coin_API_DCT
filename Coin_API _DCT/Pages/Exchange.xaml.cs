using Coin_API__DCT.Models;
using Coin_API__DCT.ViewModels;
using System.Windows.Controls;


namespace Coin_API__DCT.Pages
{
    /// <summary>
    /// Interaction logic for Exchange.xaml
    /// </summary>
    public partial class Exchange : Page
    {
        public Exchange(Asset asset)
        {
            InitializeComponent();
            DataContext = new ExchangePageViewModel(asset);
        }
    }
}
