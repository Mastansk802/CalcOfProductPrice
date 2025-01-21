using CalcOfProductPrice;
using System;
using System.Collections.Generic;
using Xunit;

namespace CalcOfProductPrice {
    public class CalculateChangeTests
    {
        [Fact]
        public void CalculateChange_ReturnsCorrectChange()
        {
            var calculator = new CalculateChange();
            decimal totalAmount = 10.00m;
            decimal purchasePrice = 7.67m;

            var result = calculator.CalculateChangeInPurchase(totalAmount, purchasePrice);

            var expected = new List<string>
            {
                "Change to be returned: £2.33",
                   "1 x £2.00",
                    "1 x £0.20",
                    "1 x £0.10",
                    "1 x £0.02",
                    "1 x £0.01"

            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateChange_ThrowsArgumentException_WhenTotalAmountIsLessThanPurchasePrice()
        {
            var calculator = new CalculateChange();
            decimal totalAmount = 5.00m;
            decimal purchasePrice = 7.00m;

            Assert.Throws<ArgumentException>(() => calculator.CalculateChangeInPurchase(totalAmount, purchasePrice));
        }
    }
}
