namespace TradingEngineServer.Orders;

public class OrderIdGenerator : IOrderIdGenerator
{
    private long _currentId = 0;

    public long NextId()
    {
        return Interlocked.Increment(ref _currentId);
    }
}
