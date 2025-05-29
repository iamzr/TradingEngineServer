using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Orders
{
    public class OrderbookEntry
    {
        public OrderbookEntry(Order currentOrder, Limit parentLimit)
        {
            CreationTime = DateTime.UtcNow;
            CurrentOrder = currentOrder;
            ParentLimit = parentLimit;
        }

        public DateTime CreationTime { get; init; }
        public Order CurrentOrder { get; init; }
        public Limit ParentLimit  { get; init; }
        public OrderbookEntry Next { get; set; }
        public OrderbookEntry Previous { get; set; }

        public override string ToString()
        {
            return $"Time created {CreationTime}, Current order{CurrentOrder.OrderId}, {ParentLimit.Price}";
        }
    }

}