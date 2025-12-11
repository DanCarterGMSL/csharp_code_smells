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
            new Item(data: data, price: decimal.Parse(data[1])),       // 1.50
            new Item(data: data1, price: decimal.Parse(data1[1])),        // 1.60
            new Item(data: data2, price: decimal.Parse(data2[1])) // 2.00
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
        string[] data = new[] { "Banana", "1.20", "4" };
        var basket = new List<Item>
        {
            new Item(data: data, price: decimal.Parse(data[1])) // 4.80
        };

        decimal total = BasketCalculator.CalculateTotal(basket);

        Assert.That(total, Is.EqualTo(4.80m));
    }
}
