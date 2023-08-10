using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Rejects
{
    public class RejectionCreator
    {
        public static Rejection GenerateOrderCoreRejection(IOrderCore orderCore, RejectionReason rejectionReason)
        {
            return new Rejection(rejectedOrder, rejectionReason);
        }
    }
}