using Coin_API__DCT.ViewModels;
using System.Windows.Controls;


namespace Coin_API__DCT.Pages
{
    /// <summary>
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Page
    {
        public History(string coinID)
        {
            InitializeComponent();
            DataContext = new HistoryPageViewModel(coinID);
        }
    }
}
