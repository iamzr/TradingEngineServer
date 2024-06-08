using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OrderbookTests
{
    public class TestOrderbook
    {
        [Fact]
        public void AddOrder_IsBuySideTrue_AddsLimitToBidLimits()
        { }

        [Fact]
        public void AddOrder_IsBuySideFalse_AddsLimitToAskLimits()
        { }

        [Fact]
        public void ChangeOrder_LimitInOrderbook_ChangesOrder()
        { }

        [Fact]
        public void ChangeOrder_LimitNotInOrderbook_AddOrderToOrderbook()
        { }

        [Fact]
        public void ContainsOrder_OrderInOrderbook_ReturnsTrue()
        { }

        [Fact]
        public void ContainsOrder_OrderNotInOrderbook_ReturnsFalse()
        { }

        [Fact]
        public void GetAskOrders_OrderbookHasAskLimits_ReturnsCorrectListOfEntries()
        { }

        [Fact]
        public void GetAskOrders_OrderbookHasNoEntries_ReturnsEmptyList()
        { }

        [Fact]
        public void GetBidOrders_OrderbookHasBidLimits_ReturnsCorrectListOfEntries()
        { }

        [Fact]
        public void GetBidOrders_OrderbookHasNoEntries_ReturnsEmptyList()
        { }

        [Fact]
        public void GetSpread_ZeroSpread_ReturnsZero()
        { }

        [Fact]
        public void GetSpread_NoBids_ReturnsNull()
        { }

        [Fact]
        public void GetSpread_NoAsks_ReturnsNull()
        { }

        [Fact]
        public void GetSpread_NonZeroSpread_ReturnsCorrectSpread()
        { }

        [Fact]
        public void RemoveOrder_OrderNotInOrderbook_DoesNothing()
        { }

        [Fact]
        public void RemoveOrder_OrderInOrderbook_RemovesOrder()
        { }

    }
}