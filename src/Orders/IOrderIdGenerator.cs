namespace TradingEngineServer.Orders;

public interface IOrderIdGenerator
{
    long NextId();
}
