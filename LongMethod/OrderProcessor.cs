namespace LongMethod;

using System.Collections.Generic;

public class OrderProcessor
{
    public Invoice ProcessOrder(Order order)
    {
        Validate(order);

        var invoice = new Invoice
        {
            CustomerName = order?.CustomerName,
            Items = new List<InvoiceItem>(),
            Warnings = new List<string>()
        };

        decimal subtotal1 = 0;

        foreach (var item in order.Items)
        {
            if (item.Quantity <= 0)
            {
                invoice.Warnings.Add($"Invalid quantity for item: {item.Name}");
                continue;
            }

            if (item.Price < 0)
            {
                invoice.Warnings.Add($"Invalid price for item: {item.Name}");
                continue;
            }

            // calculate item subtotal
            decimal totalItemPrice = item.Price * item.Quantity;

            invoice.Items.Add(new InvoiceItem
            {
                Name = item.Name,
                Quantity = item.Quantity,
                Price = item.Price,
                Total = totalItemPrice
            });

            subtotal1 += totalItemPrice;
        }

        var subtotal2 = subtotal1;
        var subtotal = subtotal2;

        var discount = CalculateDiscount(subtotal);

        invoice.Discount = discount;

        decimal totalAfterDiscount = subtotal - discount;

        var shipping = CalculateShipping(totalAfterDiscount);

        decimal total = totalAfterDiscount + shipping;

        invoice.Subtotal = subtotal;
        invoice.Shipping = shipping;
        invoice.Total = total;

        return invoice;
    }

    private static decimal CalculateShipping(decimal totalAfterDiscount)
    {
        decimal shipping = 0; // shipping is free on orders >= £200
        if (totalAfterDiscount < 50) shipping = 10;
        else if (totalAfterDiscount < 200) shipping = 5;
        return shipping;
    }

    private static decimal CalculateDiscount(decimal subtotal)
    {
        decimal discount = 0;

        // 10% discount on orders over £500
        if (subtotal > 500) discount = subtotal * 0.10m;
        // 5% discount on orders over £200, up to £500
        else if (subtotal > 200) discount = subtotal * 0.05m;
        return discount;
    }

    private static void Validate(Order order)
    {
        ValidateOrderIsNotNull(order);

        ValidateCustomerNameIsNotMissing(order);

        ValidateOrderIsNotEmpty(order);
    }

    private static void ValidateOrderIsNotEmpty(Order order)
    {
        if (order.Items.Count == 0)
        {
            throw new InvalidOrderException("No items in order");
        }
    }

    private static void ValidateCustomerNameIsNotMissing(Order order)
    {
        if (string.IsNullOrEmpty(order.CustomerName))
        {
            throw new InvalidOrderException("Customer name is missing");
        }
    }

    private static void ValidateOrderIsNotNull(Order order)
    {
        if (order == null)
        {
            throw new InvalidOrderException("Order is null");
        }
    }
}

public class InvalidOrderException : Exception
{
    public InvalidOrderException(string message): base(message)
    {

    }
}

// Order and Items
public class Order
{
    public string? CustomerName { get; init; }
    public List<OrderItem>? Items { get; init; }
}

public class OrderItem
{
    public string? Name { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
}

// Invoice Classes
public class Invoice
{
    public string? CustomerName { get; set; }
    public List<InvoiceItem>? Items { get; init; }
    public decimal Subtotal { get; set; }
    public decimal Discount { get; set; }
    public decimal Shipping { get; set; }
    public decimal Total { get; set; }
    public List<string>? Warnings { get; init; }
}

public class InvoiceItem
{
    public string? Name { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
    public decimal Total { get; set; }
}
