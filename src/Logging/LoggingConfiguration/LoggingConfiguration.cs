using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Logging.LoggingConfiguration
{
    public class LoggingConfiguration
    {
        public LoggerType LoggerType { get; set; }

        // public DatabaseLoggerConfiguration DatabaseLoggerConfiguration { get; set; }

        public TextLoggerConfiguration TextLoggerConfiguration { get; set; }
    }

    public class DatabaseLoggerConfiguration
    {
    }

    public class TextLoggerConfiguration
    {
        public string Directory { get; set; }
        public string Filename { get; set; }
        public string FileExtension { get; set; }
    }
}