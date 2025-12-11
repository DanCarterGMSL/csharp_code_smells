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
    public static decimal CalculateTotal(List<Item> basket)
    {
        decimal total = 0;

        foreach (var item in basket)
        {
            decimal price = item.Price;
            int quantity = item.Quantity;

            total += price * quantity;
        }

        return total;
    }
}
