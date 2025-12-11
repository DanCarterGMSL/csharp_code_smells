using FeatureEnvy.Model;

namespace FeatureEnvy.Services;

public class OrderCollection
{
    public OrderCollection(List<Order> orders)
    {
        Orders = orders;
    }

    public List<Order> Orders { get; private set; }
}

public class OrderHistoryService
{
    private readonly OrderCollection _orderCollection;

    public OrderHistoryService(OrderCollection orderCollection)
    {
        _orderCollection = orderCollection;
    }

    public IEnumerable<Order> FindOrdersByProduct(Product product)
    {
        return FindOrdersByProduct2(product);
    }

    private IEnumerable<Order> FindOrdersByProduct2(Product product)
    {
        return _orderCollection.Orders.Where(o =>
            o.Confirmed &&
            o.Items.Any(i => i.Product == product));
    }

    public IEnumerable<Order> FindOrdersByAddress(Address address)
    {
        return _orderCollection.Orders.Where(o =>
            o.Confirmed &&
            o.ShippingAddress.Country == address.Country);
    }
}
