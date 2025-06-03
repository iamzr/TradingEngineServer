using System;
using TradingEngineServer.Orders;

namespace TradingEngineServer.Orderbook.MatchingStrategies;

public class FifoMatchingStrategy : IMatchingStrategy
{
    // Implement the Match function as per FIFO strategy
    public MatchResult Execute(IRetrievalOrderbook orderbook)
    {
        var matchResult = new MatchResult();
        var bidOrders = orderbook.GetBidOrders(); // Get list of all buy-side orders
        var askOrders = orderbook.GetAskOrders(); // Get list of all sell-side orders

        // Iterate while there's a matchable pair (Best Bid >= Best Ask)
        while (bidOrders.Count > 0 && askOrders.Count > 0 && bidOrders[0].CurrentOrder.Price >= askOrders[0].CurrentOrder.Price)
        {
            // Take the first (oldest) bid and ask (FIFO - First In, First Out)
            var bidOrderEntry = bidOrders[0];
            var askOrderEntry = askOrders[0];

            // Determine the matched quantity
            var matchedQuantity = System.Math.Min(bidOrderEntry.CurrentOrder.CurrentQuantity, askOrderEntry.CurrentOrder.CurrentQuantity);


            try
            {
                // Adjust the quantities for both orders
                bidOrderEntry.CurrentOrder.DecreaseQuantity(matchedQuantity);
                askOrderEntry.CurrentOrder.DecreaseQuantity(matchedQuantity);

            }
            catch
            {
                Console.WriteLine("Match failed. Stopping");
                break;
            }


            // Record the match
            matchResult.AddMatch(bidOrderEntry.CurrentOrder, askOrderEntry.CurrentOrder, matchedQuantity);

            // Remove fully matched orders
            if (bidOrderEntry.CurrentOrder.CurrentQuantity == 0)
            {
                orderbook.RemoveOrder(new CancelOrder(bidOrderEntry.CurrentOrder._orderCore));
                bidOrders.RemoveAt(0); // Remove from the bid list
            }

            if (askOrderEntry.CurrentOrder.CurrentQuantity == 0)
            {
                orderbook.RemoveOrder(new CancelOrder(askOrderEntry.CurrentOrder._orderCore));
                askOrders.RemoveAt(0); // Remove from the ask list
            }
        }

        return matchResult;
    }
}