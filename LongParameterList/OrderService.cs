namespace LongParameterList;

public class Order
{
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string ShippingAddress { get; set; }
    public string BillingAddress { get; set; }
    public DateTime OrderDate { get; set; }

    public decimal TotalAmount => Quantity * Price;
}

public class Customer
{
    public Customer(string customerName, string customerEmail, string billingAddress)
    {
        CustomerName = customerName;
        CustomerEmail = customerEmail;
        BillingAddress = billingAddress;
    }

    public string CustomerName { get; }
    public string CustomerEmail { get; }
    public string BillingAddress { get; }
}

public class OrderService
{
    public Order CreateOrder(Customer customer,
        string shippingAddress,
        DateTime orderDate,
        Item item)
    {
        var customerName = customer.CustomerName;
        var customerEmail = customer.CustomerEmail;
        var billingAddress = customer.BillingAddress;
        var order = new Order
        {
            CustomerName = customerName,
            CustomerEmail = customerEmail,
            ProductName = item.ProductName,
            Quantity = item.Quantity,
            Price = item.Price,
            ShippingAddress = shippingAddress,
            BillingAddress = billingAddress,
            OrderDate = orderDate
        };

        return order;
    }
}

public class Item
{
    public int Quantity { get; }
    public decimal Price { get; }
    public string ProductName { get; }

    public Item(int quantity, decimal price, string productName)
    {
        Quantity = quantity;
        Price = price;
        ProductName = productName;
    }
}
