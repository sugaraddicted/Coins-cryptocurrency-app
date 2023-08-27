using Coins.MVVM.Models;
using Coins.Services;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

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

        private void OpenDetailsPage(object selectedCurrency)
        {
           
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
