using FeatureEnvy.Model;

namespace FeatureEnvy.Services;

public class OrderConfirmationService
{
    private readonly StockService _stockService;
    private readonly List<WarehouseStock> _stocks;

    public OrderConfirmationService(StockService stockService)
    {
        _stockService = stockService;
        _stocks = _stockService.Stocks;
    }

    public bool ConfirmOrder(Order order)
    {
        foreach (var item in order.Items)
        {
            if (!item.Product.IsAvailable(item.Quantity, _stocks))
            {
                order.Confirmed = false;
                return false;
            }
        }

        order.Confirmed = true;
        return true;
    }
}
