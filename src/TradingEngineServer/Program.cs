using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using TradingEngineServer.Core;

// Using top-level statements here, this is the entrypoint of the trading engine.

// We use using here so that we can dispoble of the trading engine when this when this program terminates.
using var engine = TradingEngineServerHostBuilder.BuildTradingEngineServer();
TradingEngineServerServiceProvider.ServiceProvider = engine.Services;

{
    // This is added in here in case we want to add in a scoped service to the HostBuilder (as opposed to say a singleton service)
    using var scope = TradingEngineServerServiceProvider.ServiceProvider.CreateScope();

    await engine.RunAsync().ConfigureAwait(false);
}