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
    private readonly Item?[] _items;

    public Invoice(Item?[] items)
    {
        _items = items;
    }

    public double CalculateTotal()
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
}
