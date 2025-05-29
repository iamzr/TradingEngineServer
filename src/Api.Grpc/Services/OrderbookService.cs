using Grpc.Core;
using Api.Grpc.Protos;
using TradingEngineServer.Orders;
using TradingEngineServer.OrderbookManager;

namespace Api.Grpc.Services;

public class TradingService(ILogger<TradingService> logger, IOrderbookManager orderbookManager, IOrderIdGenerator idGenerator) : OrderbookService.OrderbookServiceBase
{
    private readonly ILogger<TradingService> _logger = logger;
    private readonly IOrderbookManager _orderbookManager = orderbookManager;
    private readonly IOrderIdGenerator _idGenerator = idGenerator;

    public override Task<OrderResponse> PlaceOrder(OrderRequest request, ServerCallContext context)
    {
        switch (request.OrderCase)
        {
            case OrderRequest.OrderOneofCase.NewOrder:
                {
                    var orderRequest = request.NewOrder;

                    OrderCore orderCore = new(_idGenerator.NextId(), orderRequest.OrderCore.SecurityId, orderRequest.OrderCore.Username);
                    Order order = new(orderCore, orderRequest.Price, orderRequest.Quantity, orderRequest.IsBuySide);

                    _orderbookManager.ProcessOrder(order);
                    break;
                }

            case OrderRequest.OrderOneofCase.CancelOrder:
                {
                    var orderRequest = request.CancelOrder;

                    OrderCore orderCore = new(orderRequest.OrderCore.OrderId, orderRequest.OrderCore.SecurityId, orderRequest.OrderCore.Username);
                    CancelOrder order = new(orderCore);

                    _orderbookManager.ProcessOrder(order);
                    break;
                }

            case OrderRequest.OrderOneofCase.ChangeOrder:
                {
                    var orderRequest = request.ChangeOrder;

                    OrderCore orderCore = new(orderRequest.OrderCore.OrderId, orderRequest.OrderCore.SecurityId, orderRequest.OrderCore.Username);
                    ModifyOrder order = new(orderCore, orderRequest.ModifyPrice, orderRequest.ModifyQuantity, orderRequest.IsBuySide);

                    _orderbookManager.ProcessOrder(order);
                    break;
                }
        }


        return Task.FromResult(new OrderResponse
        {
            Accepted = true,
            Message = "Order received"
        }
        );
    }

    public override Task<OrderbookSnapshotResponse> GetOrderbookSnapshot(OrderbookSnapshotRequest request, ServerCallContext context)
    {
        var (bids, asks) = _orderbookManager.GetSnapshot(request.SecurityId);

        var res = new OrderbookSnapshotResponse
        {
            SecurityId = request.SecurityId,
            Timestamp = DateTime.UtcNow.ToBinary(),
        };

        foreach (var bid in bids)
        {
            res.Bids.Add(new OrderSummary { Price = bid.CurrentOrder.Price, Quantity = bid.CurrentOrder.CurrentQuantity });
        }

        foreach (var ask in asks)
        {
            res.Asks.Add(new OrderSummary { Price = ask.CurrentOrder.Price, Quantity = ask.CurrentOrder.CurrentQuantity });
        }


        return Task.FromResult(res);

    }
}
