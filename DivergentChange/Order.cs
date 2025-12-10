namespace DivergentChange;

using System.Collections.Generic;
using System.Linq;

    public class Order
    {
        private readonly List<OrderItem> _items = new List<OrderItem>();

        public void AddItem(decimal price, int quantity)
        {
            _items.Add(new OrderItem { Price = price, Quantity = quantity });
        }

        public decimal CalculateTotal()
        {
            return _items.Sum(item => item.Price * item.Quantity);
        }

        public decimal CalculateTax(string jurisdiction)
        {
            var taxRate = GetTaxRate(jurisdiction);

            return CalculateTotal() * taxRate;
        }

        private static decimal GetTaxRate(string jurisdiction) =>
            jurisdiction switch
            {
                "EU" => 0.20m,
                "UK" => 0.21m,
                "US" => 0.07m,
                _ => 0.10m
            };

        public decimal CalculateShipping(string region)
        {
            decimal total = CalculateTotal();
            return Shipping.CalculatingShippingCost(region, total);
        }

        public List<OrderItem> Items => _items;
    }

    public class OrderItem
    {
        public decimal Price { get; init; }
        public int Quantity { get; init; }
    }

