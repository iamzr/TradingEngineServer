using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Orders
{
    public class OrderBookEntry
    {
        public OrderBookEntry(Order currentOrder, Limit parentLimit)
        {
            CreationTime = DateTime.UtcNow;
            CurrentOrder = currentOrder;            
            ParentLimit = parentLimit;
        }

        public DateTime CreationTime { get; init; }
        public Order CurrentOrder { get; init; }
        public Limit ParentLimit  { get; init; }
        public OrderBookEntry Next { get; set; }
        public OrderBookEntry Previous { get; set; }
        
    }
}