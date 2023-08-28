using Coins.MVVM.Models;
using Coins.Services;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Coins.MVVM.Views;
using System.Windows.Controls;
using System.Windows;

namespace Coins.MVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly CoinCapApiService _apiService;
        private List<Currency> _currencies;

        public MainViewModel()
        {
            _apiService = new CoinCapApiService();
            LoadCurrencies();
            DetailsCommand = new RelayCommand<Currency>(OpenDetailsPage);
        }

        public List<Currency> Currencies
        {
            get => _currencies;
            private set
            {
                _currencies = value;
                OnPropertyChanged();
            }
        }

        public ICommand DetailsCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void LoadCurrencies()
        {
            var fullList = await _apiService.GetCurrenciesAsync();
            Currencies = fullList.Where(i => i.Rank <= 10).ToList();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OpenDetailsPage(Currency selectedCurrency)
        {
            Frame frame = Application.Current.MainWindow.FindName("ContentFrame") as Frame;

            if (frame != null)
            {
                frame.Navigate(new CurrencyDetailsView(selectedCurrency, frame));
            }
        }
    }

    public class NavigateToCurrencyDetailsMessage
    {
        public Currency SelectedCurrency { get; }

        public NavigateToCurrencyDetailsMessage(Currency selectedCurrency)
        {
            SelectedCurrency = selectedCurrency;
        }
    }


}