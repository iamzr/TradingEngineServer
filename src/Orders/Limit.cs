using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Orders
{
    public class Limit
    {
        public long Price { get; set; }
        public OrderbookEntry Head { get; set; }
        public OrderbookEntry Tail { get; set; }

        public bool IsEmpty
        {
            get
            {
                return Head == null && Tail == null;
            }
        }

        public Side Side 
        {
            get
            {
                if (IsEmpty)
                {
                    return Side.Unkown;
                }

                return Head.CurrentOrder.IsBuySide ? Side.Bid : Side.Ask;
            }
        }

        public uint GetLevelOrderCount()
        {
            uint orderCount = 0;
            OrderbookEntry headPointer = Head;

            while (headPointer != null) 
            {
                if (headPointer.CurrentOrder.CurrentQuantity != 0)
                {
                    orderCount++;
                }
                headPointer = headPointer.Next;
            } 

            return orderCount;
        }

        public uint GetLevelOrderQuantity()
        {
            uint orderQuantity = 0;
            OrderbookEntry headPointer = Head;

            while (headPointer != null) 
            {
                orderQuantity += headPointer.CurrentOrder.CurrentQuantity;
                headPointer = headPointer.Next;
            }

            return orderQuantity;
        }

        public List<OrderRecord> GetLevelOrderRecords()
        {
            List<OrderRecord> orderRecords = new List<OrderRecord>();
            uint theorticalQueuePosition = 0;
            OrderbookEntry headPointer = Head;

            while (headPointer != null)
            {
                var currentOrder = headPointer.CurrentOrder;
                if (currentOrder.CurrentQuantity != 0)
                {
                    orderRecords.Add(new OrderRecord(currentOrder.OrderId,
                    currentOrder.CurrentQuantity, Price, currentOrder.IsBuySide,
                    currentOrder.Username, currentOrder.SecurityId, theorticalQueuePosition));
                }

                theorticalQueuePosition++;
                headPointer = headPointer.Next;
            }

            return orderRecords;
        }
    }
}