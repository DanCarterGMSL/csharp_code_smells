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
            new Item { data = new[] { "Apple", "0.50", "3" }},       // 1.50
            new Item { data = new[] { "Pear", "0.80", "2" }},        // 1.60
            new Item { data = new[] { "Chocolate", "2.00", "1" }}    // 2.00
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
            new Item { data = new[] { "Banana", "1.20", "4" }}   // 4.80
        };

        decimal total = BasketCalculator.CalculateTotal(basket);

        Assert.That(total, Is.EqualTo(4.80m));
    }
}
