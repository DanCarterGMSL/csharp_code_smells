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
        var basket = new List<Item>
        {
            new Item(price: 0.50m, quantity: 3),       // 1.50
            new Item(price: 0.80m, quantity: 2),        // 1.60
            new Item(price: 2.00m, quantity: 1) // 2.00
        };

        decimal total = new Basket(basket).CalculateTotal();

        Assert.That(total, Is.EqualTo(5.10m));
    }

    [Test]
    public void CalculateTotal_WithEmptyBasket_ReturnsZero()
    {
        var basket = new List<Item>();

        decimal total = new Basket(basket).CalculateTotal();

        Assert.That(total, Is.EqualTo(0m));
    }

    [Test]
    public void CalculateTotal_WithSingleItem_ReturnsPriceTimesQuantity()
    {
        var basket = new List<Item>
        {
            new Item(price: 1.20m, quantity: 4) // 4.80
        };

        decimal total = new Basket(basket).CalculateTotal();

        Assert.That(total, Is.EqualTo(4.80m));
    }
}
