using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Orders
{
    public class OrderCore : IOrderCore
    {
        public OrderCore(long orderId, int securityId, string username)
        {
            OrderId = orderId;
            SecurityId = securityId;
            Username = username;
        }

        public long OrderId { get; private set; }

        public int SecurityId { get; private set; }

        public string Username { get; private set; }
        
    }

    
}