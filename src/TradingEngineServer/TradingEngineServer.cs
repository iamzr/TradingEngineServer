using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TradingEngineServer.Core.Configuration;
using TradingEngineServer.Logging;

namespace TradingEngineServer.Core
{
    public sealed class TradingEngineServer : BackgroundService, ITradingEngineServer
    {
        private readonly ITextLogger _logger;
        private readonly TradingEngineServerConfiguration _tradingEngineServerConfiguration;

        public TradingEngineServer (ITextLogger textLogger, IOptions<TradingEngineServerConfiguration> configuration)
        {
            _logger = textLogger ?? throw new ArgumentNullException(nameof(textLogger));
            _tradingEngineServerConfiguration = configuration.Value ?? throw new ArgumentException(nameof(configuration));
        }

        // Added a Run method in order to expose the ExecuteAsync
        // This method isn't needed exactly because the Microsoft Hosting package that will host this server as a 
        // background service will run ExecuteAsync for us but this is kept here for completion.
        public Task Run(CancellationToken token) => ExecuteAsync(token);

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.Information(nameof(TradingEngineServer), "Starting trading engine.");

            // Server loop
            while (!stoppingToken.IsCancellationRequested) {

            }

            _logger.Information(nameof(TradingEngineServer), "Stopping trading engine.");

            return Task.CompletedTask;
        }
    }
}