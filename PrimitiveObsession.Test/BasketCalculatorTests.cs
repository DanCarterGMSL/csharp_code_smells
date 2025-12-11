using Microsoft.VisualBasic;

namespace PrimitiveObsession.Test;

using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class BasketCalculatorTests
{
    [Test]
    public void CalculateTotal_WithMultipleItems_ReturnsCorrectTotal()
    {
        string[] data = new[] { "Apple", "0.50", "3" };
        string[] data1 = new[] { "Pear", "0.80", "2" };
        string[] data2 = new[] { "Chocolate", "2.00", "1" };
        var basket = new List<Item>
        {
            new Item(price: decimal.Parse(data[1]), quantity: int.Parse(data[2])),       // 1.50
            new Item(price: decimal.Parse(data1[1]), quantity: int.Parse(data1[2])),        // 1.60
            new Item(price: decimal.Parse(data2[1]), quantity: int.Parse(data2[2])) // 2.00
        };

        decimal total = BasketCalculator.CalculateTotal(basket);

        Assert.That(total, Is.EqualTo(5.10m));
    }

    [Test]
    public void CalculateTotal_WithEmptyBasket_ReturnsZero()
    {
        var basket = new List<Item>();

        decimal total = BasketCalculator.CalculateTotal(basket);

        Assert.That(total, Is.EqualTo(0m));
    }

    [Test]
    public void CalculateTotal_WithSingleItem_ReturnsPriceTimesQuantity()
    {
        var basket = new List<Item>
        {
            new Item(price: 1.20m, quantity: 4) // 4.80
        };

        decimal total = BasketCalculator.CalculateTotal(basket);

        Assert.That(total, Is.EqualTo(4.80m));
    }
}
