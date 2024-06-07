using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingEngineServer.Orders;

namespace TradingEngineServer.Orderbook
{
    /// <summary>
    /// Interface that allows you retrieve data from inside the Orderbook and allows for it to be mutated outside the Orderbook. 
    /// </summary>
    public interface IRetrievalOrderbook : IOrderEntryOrderbook
    {
        List<OrderbookEntry> GetAskOrders();
        List<OrderbookEntry> GetBidOrders();
    }
}