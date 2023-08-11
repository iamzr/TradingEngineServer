using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Logging
{
    /// <summary>
    /// Interface for Text Logger
    /// </summary>
    public interface ITextLogger: ILogger, IDisposable
    {
    }
}