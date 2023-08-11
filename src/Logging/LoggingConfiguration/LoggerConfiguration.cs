using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Logging.LoggingConfiguration
{
    /// <summary>
    /// Class representing the Logger Configuration
    /// </summary>
    public class LoggerConfiguration
    {
        public LoggerType LoggerType { get; set; }

        // public DatabaseLoggerConfiguration DatabaseLoggerConfiguration { get; set; }

        public TextLoggerConfiguration TextLoggerConfiguration { get; set; }
    }

    /// <summary>
    /// Representation of the Database Logger Configuration
    /// </summary>
    public class DatabaseLoggerConfiguration
    {
    }

    /// <summary>
    /// Reprsentation of the Text Logger Configuration
    /// </summary>
    public class TextLoggerConfiguration
    {
        public string Directory { get; set; }
        public string Filename { get; set; }
        public string FileExtension { get; set; }
    }
}