namespace PrimitiveObsession;

using System;
using System.Collections.Generic;

public class Item
{
    public Item(string[] data)
    {
        this.data = data;
        Price = decimal.Parse(this.data[1]);
        Quantity = int.Parse(this.data[2]);
    }

    public string[] data { get; set; }

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
