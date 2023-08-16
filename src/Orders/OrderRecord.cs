using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Orders
{
    /// <summary>
    /// Read-only representation of an order. 
    public record OrderRecord(long OrderId, uint Quantity, long Price, 
        bool IsBuySide, string Username, int SecurityId, uint TheoreticalQueuePosition);
}