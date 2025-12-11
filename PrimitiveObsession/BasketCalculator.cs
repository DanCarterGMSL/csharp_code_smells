namespace PrimitiveObsession;

using System;
using System.Collections.Generic;

public class Item
{
    public Item(string[] data)
    {
        this.data = data;
    }

    public string[] data { get; set; }

    public decimal Price => decimal.Parse(data[1]);

    public int Quantity => int.Parse(data[2]);
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
