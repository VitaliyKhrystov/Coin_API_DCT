using Coin_API__DCT.ViewModels;
using System.Windows.Controls;


namespace Coin_API__DCT.Pages
{
    /// <summary>
    /// Interaction logic for Rate.xaml
    /// </summary>
    public partial class Rate : Page
    {
        public Rate(string coinID)
        {
            InitializeComponent();
            DataContext = new RatePageViewModel(coinID);
        }
    }
}
