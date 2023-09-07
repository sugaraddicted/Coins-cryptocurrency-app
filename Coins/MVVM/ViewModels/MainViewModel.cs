using Coins.MVVM.Models;
using Coins.MVVM.Views;
using Coins.Services;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace Coins.MVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly CoinCapApiService _apiService;
        private List<Currency> _currencies;
        private string _searchText;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            _apiService = new CoinCapApiService();
            LoadCurrenciesAsync();
            DetailsCommand = new RelayCommand<Currency>(OpenDetailsPage);
            SearchCommand = new RelayCommand(SearchAsync);
        }

        public ICommand DetailsCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }

        public List<Currency> Currencies
        {
            get => _currencies;
            private set
            {
                if (_currencies != value)
                {
                    _currencies = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged();
                }
            }
        }

        private async void LoadCurrenciesAsync()
        {
            var fullList = await _apiService.GetCurrenciesAsync();
            Currencies = fullList.Where(i => i.Rank <= 10).ToList();
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OpenDetailsPage(Currency selectedCurrency)
        {
            if (Application.Current.MainWindow.FindName("ContentFrame") is Frame frame)
            {
                frame.Navigate(new CurrencyDetailsView(selectedCurrency, frame));
            }
        }

        private async void SearchAsync()
        {
            var fullCurrencyList = await _apiService.GetCurrenciesAsync();
            Currency foundCurrency = null;

            if (!string.IsNullOrEmpty(SearchText))
            {
                foundCurrency = fullCurrencyList.FirstOrDefault(c => c.Id.ToLower() == SearchText.ToLower() ||
                                                                     c.Name.ToLower() == SearchText.ToLower());
            }

            if (foundCurrency != null)
            {
                OpenDetailsPage(foundCurrency);
            }
            else
            {
                MessageBox.Show("Currency not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}