using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingEngineServer.Orders;
using TradingServerEngine.Instruments;

namespace TradingEngineServer.Orderbook
{
    /// <summary>
    /// Base Orderbook class that stores the state of Orders 
    /// </summary>
    public class Orderbook : IRetrievalOrderbook
    {
        private readonly Security _instrument;
        private readonly Dictionary<long, OrderbookEntry> _orders = new Dictionary<long, OrderbookEntry>();
        private readonly SortedSet<Limit> _askLimits = new SortedSet<Limit>(AskLimitComparer.Comparer);
        private readonly SortedSet<Limit> _bidLimits = new SortedSet<Limit>(BidLimitComparer.Comparer);

        public Orderbook(Security instrument)
        {
            _instrument = instrument;
        }

        public int Count => _orders.Count;

        public void AddOrder(Order order)
        {
            var baseLimit = new Limit(order.Price);
            AddOrder(order, baseLimit, order.IsBuySide ? _bidLimits : _askLimits, _orders);
        }

        private static void AddOrder(Order order, Limit baseLimit, SortedSet<Limit> limitLevels, Dictionary<long, OrderbookEntry> internalOrderbook)
        {

            OrderbookEntry orderbookEntry = new OrderbookEntry(order, baseLimit);

            if (limitLevels.TryGetValue(baseLimit, out Limit limit))
            {
                // Limit exists but there is no head
                if (limit.Head == null)
                {
                    limit.Head = orderbookEntry;
                    limit.Tail = orderbookEntry;
                }
                else
                {
                    OrderbookEntry tailerPointer = limit.Tail;
                    tailerPointer.Next = orderbookEntry;
                    orderbookEntry.Previous = tailerPointer;
                    limit.Tail = orderbookEntry;
                }

                internalOrderbook.Add(order.OrderId, orderbookEntry);
            }
            else
            {
                // The base limit doesn't exist in the limit levels
                limitLevels.Add(baseLimit);

                // Both pointing to the same entry because it is the only entry in the limitLevel
                baseLimit.Head = orderbookEntry;
                baseLimit.Tail = orderbookEntry;

                internalOrderbook.Add(order.OrderId, orderbookEntry);

            }
        }

        public void ChangeOrder(ModifyOrder modifyOrder)
        {
            if (_orders.TryGetValue(modifyOrder.OrderId, out OrderbookEntry orderbookEntry))
            {
                RemoveOrder(modifyOrder.ToCancelOrder());
                AddOrder(modifyOrder.ToNewOrder(), orderbookEntry.ParentLimit, modifyOrder.IsBuySide ? _bidLimits : _askLimits, _orders);

            }
        }

        public bool ContainsOrder(long orderId)
        {
            return _orders.ContainsKey(orderId);
        }

        public List<OrderbookEntry> GetAskOrders()
        {
            List<OrderbookEntry> orderbookEntries = new List<OrderbookEntry>();

            foreach (var askLimit in _askLimits)
            {
                if (!askLimit.IsEmpty)
                {
                    OrderbookEntry askLimitPointer = askLimit.Head;
                    while (askLimitPointer != null)
                    {
                        orderbookEntries.Add(askLimitPointer);
                        askLimitPointer = askLimitPointer.Next;
                    }
                }
            }

            return orderbookEntries;
        }

        public List<OrderbookEntry> GetBidOrders()
        {

            List<OrderbookEntry> orderbookEntries = new List<OrderbookEntry>();

            foreach (var bidLimit in _bidLimits)
            {
                if (!bidLimit.IsEmpty)
                {
                    OrderbookEntry bidLimitPointer = bidLimit.Head;
                    while (bidLimitPointer != null)
                    {
                        orderbookEntries.Add(bidLimitPointer);
                        bidLimitPointer = bidLimitPointer.Next;
                    }
                }
            }

            return orderbookEntries;
        }

        public OrderbookSpread GetSpread()
        {
            long? bestAsk = null, bestBid = null;

            if (_askLimits.Any() && !_askLimits.Min.IsEmpty)
            {
                bestAsk = _askLimits.Min.Price;
            }

            if (_bidLimits.Any() && !_bidLimits.Max.IsEmpty)
            {
                bestBid = _bidLimits.Max.Price;
            }

            return new OrderbookSpread(bestBid, bestAsk);
        }

        public void RemoveOrder(CancelOrder cancelOrder)
        {
            if (_orders.TryGetValue(cancelOrder.OrderId, out OrderbookEntry orderbookEntry))
            {
                RemoveOrder(cancelOrder.OrderId, orderbookEntry, _orders);
            }
        }

        private static void RemoveOrder(long orderId, OrderbookEntry orderbookEntry, Dictionary<long, OrderbookEntry> internalOrderbook)
        {
            // Deal with the location of the OrderbookEntry in the LinkedList 
            if (orderbookEntry.Previous != null && orderbookEntry.Next != null)
            {
                orderbookEntry.Next.Previous = orderbookEntry.Previous;
                orderbookEntry.Previous.Next = orderbookEntry.Next;
            }
            else if (orderbookEntry.Previous != null)
            {
                orderbookEntry.Previous.Next = null;
            }
            else if (orderbookEntry.Next != null)
            {
                orderbookEntry.Next.Previous = null;
            }

            // Deal with OrderbookEntry on limit Level
            if (orderbookEntry.ParentLimit.Head == orderbookEntry && orderbookEntry.ParentLimit.Tail == orderbookEntry)
            {
                // One order on this limit
                orderbookEntry.ParentLimit.Head = null;
                orderbookEntry.ParentLimit.Tail = null;
            }
            else if (orderbookEntry.ParentLimit.Head == orderbookEntry)
            {
                // More than one order, but orderbookEntry is first order on level
                orderbookEntry.ParentLimit.Head = orderbookEntry.Next;
            }
            else if (orderbookEntry.ParentLimit.Tail == orderbookEntry)
            {
                // More than one order, but orderbookEntry is last order on level
                orderbookEntry.ParentLimit.Tail = orderbookEntry.Previous;
            }

            internalOrderbook.Remove(orderId);
        }
    }
}