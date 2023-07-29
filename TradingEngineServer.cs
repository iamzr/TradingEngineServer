using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TradingEngineServer.Core.Configuration;

namespace TradingEngineServer.Core
{
    public sealed class TradingEngineServer : BackgroundService, ITradingEngineServer
    {
        private readonly ILogger<TradingEngineServer> _logger;
        private readonly TradingEngineServerConfiguration _tradingEngineServerConfiguration;

        public TradingEngineServer (ILogger<TradingEngineServer> logger, IOptions<TradingEngineServerConfiguration> configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _tradingEngineServerConfiguration = configuration.Value ?? throw new ArgumentException(nameof(configuration));
        }

        // Added a Run method in order to expose the ExecuteAsync
        // This method isn't needed exactly because the Microsoft Hosting package that will host this server as a 
        // background service will run ExecuteAsync for us but this is kept here for completion.
        public Task Run(CancellationToken token) => ExecuteAsync(token);

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Starting {(nameof(TradingEngineServer))}");

            // Server loop
            while (!stoppingToken.IsCancellationRequested) {

            }

            _logger.LogInformation($"Stopped {(nameof(TradingEngineServer))}");

            return Task.CompletedTask;
        }
    }
}