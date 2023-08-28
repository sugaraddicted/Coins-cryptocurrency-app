using Coins.MVVM.Models;
using Coins.MVVM.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;

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

            viewModel.BackCommand = new RelayCommand(() =>
            {
                NavigationService?.Navigate(new MainView());
            });

            Messenger.Default.Register<NavigateToMainViewMessage>(this, _ => NavigateToMainView());
        }

        private void NavigateToMainView()
        {
            NavigationService?.Navigate(new MainView());
        }

        ~CurrencyDetailsView()
        {
            Messenger.Default.Unregister(this);
        }
    }
}
