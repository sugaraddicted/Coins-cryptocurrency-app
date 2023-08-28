using Coins.MVVM.Models;
using Coins.MVVM.Views;
using Coins.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Coins.MVVM.ViewModels
{
    public class CurrencyDetailsViewModel : INotifyPropertyChanged
    {
        private readonly CoinCapApiService _apiService;
        private Currency _selectedCurrency;
        private List<CurrencyMarketInfo> _marketsInfo;
        public RelayCommand BackCommand { get; set; }


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
            Messenger.Default.Send(new NavigateToMainViewMessage());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
    public class NavigateToMainViewMessage { }
}