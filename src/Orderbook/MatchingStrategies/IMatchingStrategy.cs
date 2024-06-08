using TradingEngineServer.Orderbook;

namespace TradingEngineServer.Orderbook
{
    public interface IMatchingStrategy
    {
        MatchResult Match(IRetrievalOrderbook orderbook);
    }
}