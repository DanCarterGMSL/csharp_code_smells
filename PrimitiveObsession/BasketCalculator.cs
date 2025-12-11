namespace PrimitiveObsession;

using System;
using System.Collections.Generic;

public class Item
{
    public string[] data { get; set; }

    public decimal Price()
    {
        return decimal.Parse(data[1]);
    }
}

public static class BasketCalculator
{
    public static decimal CalculateTotal(List<Item> basket)
    {
        decimal total = 0;

        foreach (var item in basket)
        {
            decimal price = item.Price();
            int quantity = int.Parse(item.data[2]);

            total += price * quantity;
        }

        return total;
    }
}
