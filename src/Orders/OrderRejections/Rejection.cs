using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TradingEngineServer.Orders;

namespace TradingEngineServer.Rejects
{
    public class Rejection
    {
        public Rejection(IOrderCore rejectedOrder, RejectionReason rejectionReason)
        {
            // Properties
            RejectionReason = rejectionReason; 

            // Fields
            _orderCore = rejectedOrder;
        } 

        public RejectionReason RejectionReason { get; private set;}
        public long OrderId => _orderCore.OrderId;
        public int SecurityId => _orderCore.SecurityId;
        public string Username => _orderCore.Username;


        private readonly IOrderCore _orderCore;
    }
}