namespace FeatureEnvy.Model;

public class Product
{
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }

    public bool IsProductAvailable(int qty, List<WarehouseStock> warehouseStocks)
    {
        var stock = warehouseStocks.FirstOrDefault(s => s.Product == this);
        return stock != null && stock.Quantity >= qty;
    }
}