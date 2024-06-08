using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OrdersTests
{
    public class LimitTests
    {
        [Fact]
        public void IsEmpty_LimitIsEmpty_ReturnsFalse()
        {
            Assert.True(true);
        }

        [Fact]
        public void IsEmpty_HeadNotNull_ReturnsFalse()
        { }

        [Fact]
        public void IsEmpty_TailNotNull_ReturnsFalse()
        { }

        [Fact]
        public void IsEmpty_HeadAndTailNull_ReturnsTrue()
        { }

    }
}