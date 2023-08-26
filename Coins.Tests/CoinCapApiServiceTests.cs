using Coins.Services;

namespace Coins.Tests
{
    [TestFixture]
    public class CoinCapApiServiceTests
    {
        [Test]
        public async Task GetCurrenciesAsync_WhenCalled_ReturnsListOfCurrencies()
        {
            var service = new CoinCapApiService();

            var result = await service.GetCurrenciesAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result[0].Id, Is.EqualTo("bitcoin"));
        }

        [Test]
        public async Task GetCurrencyByIdAsync_WhenCalled_ReturnsCurrency()
        {
            var service = new CoinCapApiService();
            var id = "bitcoin";

            var result = await service.GetCurrencyByIdAsync(id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Symbol, Is.EqualTo("BTC"));
        }

        [Test]
        public async Task GetMarketsInfoByCurrencyIdAsync_WhenCalled_ReturnsListOfMarketsInfo()
        {
            var service = new CoinCapApiService();
            var id = "bitcoin";

            var result = await service.GetMarketsInfoByCurrencyIdAsync(id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result[0].ExchangeId, Is.EqualTo("Binance"));
        }

    }
}
