using TradingEngineServer.Orderbook;

namespace TradingEngineServer.Orderbook
{
    public interface IMatchingStrategy
    {
        MatchResult Execute(IRetrievalOrderbook orderbook);
    }
}