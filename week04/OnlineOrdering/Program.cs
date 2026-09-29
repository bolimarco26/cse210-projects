using System;

class Program
{
    static void Main(string[] args)
    {
        // First order
        Address address1 = new Address(
            "123 Main Street",
            "New York",
            "NY",
            "USA");

        Customer customer1 = new Customer(
            "John Smith",
            address1);

        Order order1 = new Order(customer1);

        Product product1 = new Product(
            "Laptop",
            "P001",
            800,
            1);

        Product product2 = new Product(
            "Wireless Mouse",
            "P002",
            25,
            2);

        order1.AddProduct(product1);
        order1.AddProduct(product2);

        // Second order
        Address address2 = new Address(
            "45 Avenida Arce",
            "La Paz",
            "La Paz",
            "Bolivia");

        Customer customer2 = new Customer(
            "Marco Perez",
            address2);

        Order order2 = new Order(customer2);

        Product product3 = new Product(
            "Keyboard",
            "P003",
            50,
            1);

        Product product4 = new Product(
            "Monitor",
            "P004",
            250,
            2);

        Product product5 = new Product(
            "USB Cable",
            "P005",
            10,
            3);

        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Display first order
        Console.WriteLine("ORDER 1");
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");
        Console.WriteLine();
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine("------------------------------");

        // Display second order
        Console.WriteLine("ORDER 2");
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
        Console.WriteLine();
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
    }
}