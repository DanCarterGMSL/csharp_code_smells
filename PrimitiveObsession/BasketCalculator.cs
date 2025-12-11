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

public static class BasketCalculator
{
    public static decimal CalculateTotal(List<Item> items)
    {
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
