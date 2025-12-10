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

    public double Total()
    {
        return Price * Quantity;
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
            .Sum(item => item.Total());
    }
}
