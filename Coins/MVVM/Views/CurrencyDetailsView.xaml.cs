using Coins.MVVM.Models;
using Coins.MVVM.ViewModels;
using System.Windows.Controls;

namespace Coins.MVVM.Views
{
    /// <summary>
    /// Interaction logic for CurrencyDetailsView.xaml
    /// </summary>
    public partial class CurrencyDetailsView : Page
    {

        public CurrencyDetailsView(Currency selectedCurrency, Frame contentFrame)
        {
            InitializeComponent();

            var viewModel = new CurrencyDetailsViewModel(selectedCurrency);
            DataContext = viewModel;
        }
    }
}
