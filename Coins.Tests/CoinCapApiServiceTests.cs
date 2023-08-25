using Coins.Services;

namespace Coins.Tests
{
    [TestFixture]
    public class CoinCapApiServiceTests
    {
        [Test]
        public async Task GetTopCurrenciesAsync_WhenCalled_ReturnsListOfCurrencies()
        {
            var service = new CoinCapApiService();

            var result = await service.GetTopCurrenciesAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result[0].Id, Is.EqualTo("bitcoin"));
        }
    }
}
