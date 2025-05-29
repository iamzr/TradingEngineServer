using System.Data.Common;

namespace TradingEngineServer.Instruments;

public class Security
{
    public readonly int Id;

    public Security(int id)
    {
        Id = id;
    }
}
