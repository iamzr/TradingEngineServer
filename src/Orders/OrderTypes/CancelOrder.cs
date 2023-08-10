using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Orders
{
    public class CancelOrder : IOrderCore 
    {
       public CancelOrder(IOrderCore orderCore)
       {

            // Fields
            _orderCore = orderCore;
       } 

        // Properties 
        public long OrderId => _orderCore.OrderId;
        public int SecurityId => _orderCore.SecurityId;
        public string Username => _orderCore.Username;

        // Fields
       private readonly IOrderCore _orderCore;
    }
}