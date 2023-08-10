using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingEngineServer.Orders
{
    public sealed class OrderStatusCreator
    {
       public CancelOrderStatus GenerateCancelOrderStatus(CancelOrder cancelOrder) 
       {
            return new CancelOrderStatus();
       }
       public NewOrderStatus GenerateNewOrderStatus(Order order) 
       {
            return new NewOrderStatus();
       }

       public ModifyOrderStatus GenerateModifyOrderStatus(ModifyOrder modifyOrder) 
       {
            return new ModifyOrderStatus();
       }


    }
}