using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TradingEngineServer.Core.Configuration;

namespace TradingEngineServer.Core
{
    public class TradingEngineServer : BackgroundService, ITradingEngineServer
    {
        private readonly ILogger<TradingEngineServer> _logger;
        private readonly IOptions<TradingEngineServerConfiguration> _tradingEngineServerConfiguration;

        public TradingEngineServer(ILogger<TradingEngineServer> logger, IOptions<TradingEngineServerConfiguration> configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _tradingEngineServerConfiguration = configuration.Value ?? throw new ArgumentException(nameof(configuration);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Server loop
            while (!stoppingToken.IsCancellationRequested) {

            }
        }
    }
}