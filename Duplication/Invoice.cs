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
}

public class Invoice
{
    private readonly Item? _item1;
    private readonly Item? _item2;
    private readonly Item? _item3;
    private readonly Item? _item4;
    private readonly Item? _item5;
    private readonly Item?[] _items;

    public Invoice(Item? item1, Item? item2, Item? item3, Item? item4, Item? item5, Item?[] items)
    {
        _item1 = item1;
        _item2 = item2;
        _item3 = item3;
        _item4 = item4;
        _item5 = item5;

        _items = items;
    }

    public double CalculateTotal2()
    {
        double total = 0.0;
        foreach (var item in _items)
        {
            if (item != null)
            {
                double subtotal = item.Price * item.Quantity;
                total += subtotal;
            }
        }

        return total;
    }

    public double CalculateTotal()
    {
        return CalculateTotal2();
    }
}
