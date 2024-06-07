using System.Diagnostics.Metrics;
using TradingServerEngine.Instruments;

namespace TradingEngineServer.Orderbook
{
    public class MatchingOrderbook : Orderbook, IMatchingOrderbook
    {
        private readonly IMatchingStrategy _matchingStrategy;

        public MatchingOrderbook(IMatchingStrategy matchingStrategy, Security instrument) : base(instrument)
        {
            _matchingStrategy = matchingStrategy;
        }

        public MatchResult Match()
        {
            return _matchingStrategy.Match(this);
        }
    }
}