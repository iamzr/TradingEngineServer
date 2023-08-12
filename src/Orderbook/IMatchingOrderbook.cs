using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Orderbook
{
    /// <summary>
    /// Interface that allows you to modify the state of the Orderbook via matching 
    /// </summary>
    public interface IMatchingOrderbook : IRetrievalOrderbook
    {
        MatchResult Match();
    }
}