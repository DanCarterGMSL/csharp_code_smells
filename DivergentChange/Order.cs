namespace DivergentChange;

using System.Collections.Generic;
using System.Linq;

    // This class violates SRP: it manages order items, calculates tax, and calculates shipping
    public class Order
    {
        private List<OrderItem> _items = new List<OrderItem>();

        // Add an item to the order
        public void AddItem(decimal price, int quantity)
        {
            _items.Add(new OrderItem { Price = price, Quantity = quantity });
        }

        // Calculate total price of items
        public decimal CalculateTotal()
        {
            return _items.Sum(item => item.Price * item.Quantity);
        }

        // Responsibility 1: Calculate sales tax based on jurisdiction
        public decimal CalculateTax(string jurisdiction)
        {
            decimal taxRate = jurisdiction switch
            {
                "EU" => 0.20m,
                "UK" => 0.21m,
                "US" => 0.07m,
                _ => 0.10m
            };

            return CalculateTotal() * taxRate;
        }

        // Responsibility 2: Calculate shipping based on total and region
        public decimal CalculateShipping(string region)
        {
            decimal total = CalculateTotal();
            decimal shipping;

            if (region == "EU")
                shipping = total > 100 ? 0 : 10;
            else if (region == "UK")
                shipping = total > 50 ? 0 : 8;
            else
                shipping = total > 75 ? 0 : 15;

            return shipping;
        }

        // Properties for testing/inspection
        public List<OrderItem> Items => _items;
    }

    public class OrderItem
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

