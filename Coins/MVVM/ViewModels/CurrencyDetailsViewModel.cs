using Coins.MVVM.Models;
using Coins.MVVM.Views;
using Coins.Services;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Coins.MVVM.ViewModels
{
    public class CurrencyDetailsViewModel : INotifyPropertyChanged
    {
        private readonly CoinCapApiService _apiService;
        private Currency _selectedCurrency;
        private List<CurrencyMarketInfo> _marketsInfo;

        public ICommand BackCommand { get; private set; }

        public CurrencyDetailsViewModel(Currency selectedCurrency)
        {
            _apiService = new CoinCapApiService();
            _selectedCurrency = selectedCurrency;
            LoadMarketsInfo();
            BackCommand = new RelayCommand(GoBack);
        }

        public Currency SelectedCurrency
        {
            get => _selectedCurrency;
            set
            {
                _selectedCurrency = value;
                OnPropertyChanged();
            }
        }

        public List<CurrencyMarketInfo> MarketsInfo
        {
            get => _marketsInfo;
            set
            {
                _marketsInfo = value;
                OnPropertyChanged();
            }
        }

        public async void LoadMarketsInfo()
        {
            MarketsInfo = await _apiService.GetMarketsInfoByCurrencyIdAsync(_selectedCurrency.Id);
        }

        private void GoBack()
        {
            Frame frame = Application.Current.MainWindow.FindName("ContentFrame") as Frame;

            if (frame != null)
            {
                frame.Navigate(new MainView());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}