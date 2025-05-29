using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingEngineServer.Orders;

namespace TradingEngineServer.Orderbook
{
    public class MatchResult
    {
        public List<Trade> Trades { get; } = new List<Trade>();

        public bool HasMatches => Trades.Count > 0;

        public void AddMatch(Orders.Order buyOrder, Order sellOrder, long quantity)
        {
            Trades.Add(new Trade(buyOrder.OrderId, sellOrder.OrderId, buyOrder.Price, quantity));
        }
    }

    public class Trade
    {
        public long BuyOrderId { get; }
        public long SellOrderId { get; }
        public long Price { get; }
        public long Quantity { get; }
        public DateTime Timestamp { get; }

        public Trade(long buyOrderId, long sellOrderId, long price, long quantity)
        {
            BuyOrderId = buyOrderId;
            SellOrderId = sellOrderId;
            Price = price;
            Quantity = quantity;
            Timestamp = DateTime.UtcNow;
        }

        public override string ToString()
        {
            return $"Trade: BuyOrder {BuyOrderId}, SellOrder {SellOrderId}, Price {Price}, Quantity {Quantity}, Time {Timestamp}";
        }
    }
}
