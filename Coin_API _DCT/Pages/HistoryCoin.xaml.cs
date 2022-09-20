using Coin_API__DCT.Models;
using Coin_API__DCT.ViewModels;
using System.Windows.Controls;


namespace Coin_API__DCT.Pages
{
    /// <summary>
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class HistoryCoin : Page
    {
        public HistoryCoin(Asset asset)
        {
            InitializeComponent();
            DataContext = new HistoryPageViewModel(asset);
        }
    }
}
