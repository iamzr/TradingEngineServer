using TradingEngineServer.Orders;

namespace TradingEngineServer.OrderbookManager;

public interface IOrderbookManager
{
    void ProcessOrder(IOrderCore order);
    Tuple<List<OrderbookEntry>, List<OrderbookEntry>> GetSnapshot(int securityId);

}
