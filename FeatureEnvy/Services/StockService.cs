using FeatureEnvy.Model;

namespace FeatureEnvy.Services;

public class StockService
{
    private readonly List<WarehouseStock> _stocks;

    public StockService(List<WarehouseStock> stocks)
    {
        _stocks = stocks;
    }

    public List<WarehouseStock> Stocks => _stocks;

    public bool CheckStock(Product product, int qty)
    {
        return product.IsAvailable(qty, Stocks);
    }
}