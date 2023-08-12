using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingEngineServer.Orders;

namespace TradingEngineServer.Orderbook
{
    /// <summary>
    /// Interface that allows to store the objects. 
    /// </summary>
    public interface IOrderEntryOrderbook : IReadOnlyOrderbook
    {
        void AddOrder(Order order);
        void ChangeOrder (ModifyOrder modifyOrder);
        void RemoveOrder(CancelOrder cancelOrder);
    }
}