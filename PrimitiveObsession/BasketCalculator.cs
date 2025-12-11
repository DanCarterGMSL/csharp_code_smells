namespace PrimitiveObsession;

using System;
using System.Collections.Generic;

public class Item
{
    public Item(decimal price, int quantity)
    {
        Price = price;
        Quantity = quantity;
    }

    public decimal Price { get; }

    public int Quantity { get; }
}

public class Basket
{
    public Basket(List<Item> items)
    {
        Items = items;
    }

    public List<Item> Items { get; }
}

public static class BasketCalculator
{
    public static decimal CalculateTotal(Basket basket)
    {
        var items = basket.Items;
        decimal total = 0;

        foreach (var item in items)
        {
            decimal price = item.Price;
            int quantity = item.Quantity;

            total += price * quantity;
        }

        return total;
    }
}
