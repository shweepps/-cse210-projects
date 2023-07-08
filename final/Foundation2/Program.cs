using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main()
        {
            Address address1 = new Address("123 Main Street", "New York", "NY", "USA");
            Customer customer1 = new Customer("John Doe", address1);
            Order order1 = new Order(customer1);

            Product product1 = new Product("Product 1", 1, 10.99m, 2);
            Product product2 = new Product("Product 2", 2, 5.99m, 3);

            order1.AddProduct(product1);
            order1.AddProduct(product2);

            Console.WriteLine("Order 1 - Packing Label:");
            Console.WriteLine(order1.GetPackingLabel());

            Console.WriteLine("\nOrder 1 - Shipping Label:");
            Console.WriteLine(order1.GetShippingLabel());

            Console.WriteLine("\nOrder 1 - Total Cost:");
            Console.WriteLine(order1.CalculateTotalCost());

            Console.WriteLine("\n-----------------------\n");

            Address address2 = new Address("456 Elm Street", "Toronto", "ON", "Canada");
            Customer customer2 = new Customer("Jane Smith", address2);
            Order order2 = new Order(customer2);

            Product product3 = new Product("Product 3", 3, 7.49m, 1);
            Product product4 = new Product("Product 4", 4, 3.99m, 4);
            Product product5 = new Product("Product 5", 5, 12.99m, 2);

            order2.AddProduct(product3);
            order2.AddProduct(product4);
            order2.AddProduct(product5);

            Console.WriteLine("Order 2 - Packing Label:");
            Console.WriteLine(order2.GetPackingLabel());

            Console.WriteLine("\nOrder 2 - Shipping Label:");
            Console.WriteLine(order2.GetShippingLabel());

            Console.WriteLine("\nOrder 2 - Total Cost:");
            Console.WriteLine(order2.CalculateTotalCost());
        }
    }
}
