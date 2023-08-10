using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Orders
{
    public class Order : IOrderCore
    {
        public Order(IOrderCore orderCore, long price, uint quantity, bool isBuySide)
        {
           _orderCore = orderCore; 

            // Properties
            Price = price;
            InitialQuantity= quantity;
            CurrentQuantity = quantity;
            IsBuySide = isBuySide; 

            // Fields
            _orderCore = orderCore;
        } 

        public Order(ModifyOrder modifyOrder) : this(modifyOrder, modifyOrder.Price, modifyOrder.Quantity, modifyOrder.IsBuySide)
        {

        }

        // Properties
        public long Price { get; private set; }
        public uint InitialQuantity { get; private set; } 
        public uint CurrentQuantity { get; private set; } 
        public bool IsBuySide { get; private set; }
        public long OrderId => _orderCore.OrderId;
        public int SecurityId => _orderCore.SecurityId;
        public string Username => _orderCore.Username;

        // Fields
        public readonly IOrderCore _orderCore;


        // Methods
        public void IncreaseQuantity(uint quantityDelta )
        {
            CurrentQuantity += quantityDelta;
        } 

        public void DecreaseQuantity(uint quantityDelta)
        {
            if (quantityDelta > CurrentQuantity)
            {
                throw new InvalidOperationException($"Quantity delta greater than current quantity for OrderId={OrderId}");
            }
            CurrentQuantity -= quantityDelta;
        }

    }
}