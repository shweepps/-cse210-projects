using System.Collections.Generic;

namespace OnlineOrdering
{
    class Order
    {
        private List<Product> products;
        private Customer customer;

        public Order(Customer customer)
        {
            this.customer = customer;
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public decimal CalculateTotalCost()
        {
            decimal totalCost = 0;
            foreach (Product product in products)
            {
                totalCost += product.CalculateTotalPrice();
            }

            totalCost += customer.IsInUSA() ? 5 : 35;

            return totalCost;
        }

        public string GetPackingLabel()
        {
            string packingLabel = "";
            foreach (Product product in products)
            {
                packingLabel += $"{product.Name} (ID: {product.ProductId})\n";
            }

            return packingLabel;
        }

        public string GetShippingLabel()
        {
            return $"{customer.Name}\n{customer.Address.GetFormattedAddress()}";
        }
    }
}
