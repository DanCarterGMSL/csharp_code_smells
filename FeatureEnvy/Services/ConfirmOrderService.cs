using FeatureEnvy.Model;

namespace FeatureEnvy.Services;

public class OrderConfirmationService
{
    private readonly List<WarehouseStock> _stocks;

    public OrderConfirmationService(List<WarehouseStock> stocks)
    {
        _stocks = stocks;
    }

    public bool ConfirmOrder(Order order)
    {
        return order.Confirm(_stocks);
    }
}
