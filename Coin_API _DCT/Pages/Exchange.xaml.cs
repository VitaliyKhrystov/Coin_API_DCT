using Coin_API__DCT.ViewModels;
using System.Windows.Controls;


namespace Coin_API__DCT.Pages
{
    /// <summary>
    /// Interaction logic for Exchange.xaml
    /// </summary>
    public partial class Exchange : Page
    {
        public Exchange(string coinID)
        {
            InitializeComponent();
            DataContext = new ExchangePageViewModel(coinID);
        }
    }
}
