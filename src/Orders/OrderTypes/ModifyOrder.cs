using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Orders
{
    public class ModifyOrder : IOrderCore
    {
        public ModifyOrder(IOrderCore orderCore, long modifyPrice, uint modifyQuantity, bool isBuySide)
        {
            // Properties
           Price = modifyPrice;
           Quantity = modifyQuantity;
           IsBuySide = isBuySide;

           // Fields
           _orderCore = orderCore;

        }

        public long Price { get; private set; }
        public uint Quantity { get; private set; }
        public bool IsBuySide { get; private set; }
        public long OrderId => _orderCore.OrderId;
        public int SecurityId => _orderCore.SecurityId;
        public string Username => _orderCore.Username;

        // Fields
        public readonly IOrderCore _orderCore;

        // Methods
        public CancelOrder ToCancelOrder()
        {
            return new CancelOrder(this);
        } 

        public Order ToNewOrder()
        {
            return new Order(this);
        }
    }
}