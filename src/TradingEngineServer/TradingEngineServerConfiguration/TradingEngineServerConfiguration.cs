using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Core.Configuration
{
    /// <summary>
    /// Representation of the Trading Engine Server Configuration
    /// </summary>
    public class TradingEngineServerConfiguration
    {
        public TradingEngineServerSettings TradingEngineServerSettings { get; set; }
        
    }

    /// <summary>
    /// Trading Engine Server Settings
    /// </summary>
    public class TradingEngineServerSettings
    {
        public int Port { get; set; }
    }
}