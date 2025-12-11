namespace FeatureEnvy.Model;

public class Order
{
    public List<Item> Items { get; set; } = new();
    public Address ShippingAddress { get; set; }
    public decimal Total { get; set; }
    public bool Confirmed { get; set; }

    public bool Confirm(List<WarehouseStock> warehouseStocks)
    {
        foreach (var item in this.Items)
        {
            if (!item.Product.IsAvailable(item.Quantity, warehouseStocks))
            {
                this.Confirmed = false;
                return false;
            }
        }

        this.Confirmed = true;
        return true;
    }
}