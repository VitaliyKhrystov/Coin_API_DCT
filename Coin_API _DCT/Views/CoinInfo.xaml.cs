using Coin_API__DCT.Models;
using Coin_API__DCT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
