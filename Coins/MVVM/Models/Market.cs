
namespace Coins.MVVM.Models
{
    public class Market
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Exchange { get; set; }
        public string Pair { get; set; }
        public decimal Volume { get; set; }
        public decimal Price { get; set; }
        public decimal Spread { get; set; }
    }
}
