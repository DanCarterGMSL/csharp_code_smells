namespace PrimitiveObsession;

using System;
using System.Collections.Generic;

public class Item
{
    private readonly decimal price;
    private readonly int quantity;

    public Item(string[] data)
    {
        this.data = data;
        price = decimal.Parse(this.data[1]);
        quantity = int.Parse(this.data[2]);
    }

    public string[] data { get; set; }

    public decimal Price => price;

    public int Quantity => quantity;
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
