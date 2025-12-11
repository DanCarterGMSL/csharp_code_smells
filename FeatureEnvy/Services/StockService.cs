using FeatureEnvy.Model;

namespace FeatureEnvy.Services;

public class StockService
{
    private readonly List<WarehouseStock> _stocks;

    public StockService(List<WarehouseStock> stocks)
    {
        _stocks = stocks;
    }

    public bool CheckStock(Product product, int qty)
    {
        return product.IsProductAvailable(qty, _stocks);
    }
}