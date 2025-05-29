using TradingEngineServer.Orderbook.MatchingStrategies;
using TradingEngineServer.Orders;

namespace TradingEngineServer.Orderbook
{
    public class MatchingOrderbook : IMatchingOrderbook
    {
        private readonly IRetrievalOrderbook _orderbook;

        private IMatchingStrategy _matchingStrategy = new FifoMatchingStrategy();

        public MatchingOrderbook(IRetrievalOrderbook orderbook) 
        {
            _orderbook = orderbook;
        }

        public int Count => _orderbook.Count;

        public void AddOrder(Order order)
        {
            _orderbook.AddOrder(order);
            Match();
        }

        public void ChangeOrder(ModifyOrder modifyOrder)
        {
            _orderbook.ChangeOrder(modifyOrder);
            Match();
        }

        public bool ContainsOrder(long orderId) => _orderbook.ContainsOrder(orderId);

        public List<OrderbookEntry> GetAskOrders() => _orderbook.GetAskOrders();

        public List<OrderbookEntry> GetBidOrders() => _orderbook.GetBidOrders();

        public OrderbookSpread GetSpread() => _orderbook.GetSpread();

        public MatchResult Match() => _matchingStrategy.Execute(_orderbook);

        public void RemoveOrder(CancelOrder cancelOrder)
        {
            _orderbook.RemoveOrder(cancelOrder);
            Match();
        }

        public void SetMatchingStrategy(IMatchingStrategy matchingStrategy) => _matchingStrategy = matchingStrategy;
    }
}
