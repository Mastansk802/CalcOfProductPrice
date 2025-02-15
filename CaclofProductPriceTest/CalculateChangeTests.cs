using System;
using System.Collections.Generic;
using CalcOfProductPrice;
using NUnit.Framework;
using NUnit;
using NSubstitute;


[TestFixture]
public class CalculateChangeTests
{
    private CalculateChange _calculator;

    [SetUp]
    public void SetUp()
    {
        _calculator = new CalculateChange();
    }

    [Test]
    public void CalculateChange_ReturnsCorrectChange()
    {
        //Arrange
        decimal totalAmount = 10.00m;
        decimal purchasePrice = 7.67m;

        //Act
        var result = _calculator.CalculateChangeInPurchase(totalAmount, purchasePrice);

        var expected = new List<string>
            {
                "\nChange to be returned: �2.33",
                   "1 x �2.00",
                    "1 x �0.20",
                    "1 x �0.10",
                    "1 x �0.02",
                    "1 x �0.01"

            };
        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void CalculateChange_ThrowsArgumentException_WhenTotalAmountIsLessThanPurchasePrice()
    {
        decimal totalAmount = 5.00m;
        decimal purchasePrice = 7.00m;

        Assert.Throws<ArgumentException>(() => _calculator.CalculateChangeInPurchase(totalAmount, purchasePrice));
    }
}
