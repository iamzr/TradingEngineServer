using TradingEngineServer.Instruments;
using TradingEngineServer.Orderbook;
using TradingEngineServer.Orderbook.MatchingStrategies;
using TradingEngineServer.Orders;

namespace TradingEngineServer.OrderbookManager 
{
    public class OrderbookManager : IOrderbookManager
    {
        private readonly Dictionary<int, MatchingOrderbook> _books = [];

        public OrderbookManager()
        {
            var security = new Security(0);
            var orderbook = new Orderbook.Orderbook(security);
            var matchingOrderbook = new MatchingOrderbook(orderbook);
            matchingOrderbook.SetMatchingStrategy(new FifoMatchingStrategy());
            _books.Add(security.Id, matchingOrderbook);
        }

        public void ProcessOrder(IOrderCore order)
        {
            if (!_books.TryGetValue(order.SecurityId, out var book))
                throw new InvalidOperationException($"No book for {order.SecurityId}");

            switch (order)
            {
                case CancelOrder cancelOrder:
                    book.RemoveOrder(cancelOrder);
                    break;

                case Order addOrder:
                    book.AddOrder(addOrder);
                    break;

                case ModifyOrder modifyOrder:
                    book.ChangeOrder(modifyOrder);
                    break;

                default:
                    throw new InvalidOperationException("Unknown order type");
            }
        }

        public void AddInstrument(Security security)
        {
            if (!_books.ContainsKey(security.Id))
            {
                var orderbook = new Orderbook.Orderbook(security);
                var matchingOrderbook = new MatchingOrderbook(orderbook);
                _books[security.Id] = matchingOrderbook;
            }
        }

        public Tuple<List<OrderbookEntry>, List<OrderbookEntry>> GetSnapshot(int securityId)
        {
            if (_books.TryGetValue(securityId, out var book))
                return new Tuple<List<OrderbookEntry>, List<OrderbookEntry>>(book.GetBidOrders(), book.GetAskOrders());

            throw new InvalidOperationException("Security not found.");
        }
    }
}