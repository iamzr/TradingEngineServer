using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingEngineServer.Orders;

namespace TradingEngineServer.Rejects
{
    public class RejectionCreator
    {
        public static Rejection GenerateOrderCoreRejection(IOrderCore rejectedOrder, RejectionReason rejectionReason)
        {
            return new Rejection(rejectedOrder, rejectionReason);
        }
    }
}