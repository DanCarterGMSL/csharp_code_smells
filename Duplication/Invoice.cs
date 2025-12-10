namespace Duplication;

public class Item
{
    public double Price { get; }
    public int Quantity { get; }

    public Item(double price, int quantity)
    {
        Price = price;
        Quantity = quantity;
    }

    public static double Total(Item item)
    {
        return item.Price * item.Quantity;
    }
}

public class Invoice
{
    private readonly Item?[] _items;

    public Invoice(Item?[] items)
    {
        _items = items;
    }

    public double CalculateTotal()
    {
        return _items
            .OfType<Item>()
            .Sum(item => Item.Total(item));
    }
}
