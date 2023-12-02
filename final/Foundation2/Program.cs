using System;

class Program
{
    static void Main(string[] args)
    {
        Product product1 = new Product("Computer", "111", 2000, 1);
        Product product2 = new Product("iPad", "222", 500, 1);
        Product product3 = new Product("Printer", "333", 200, 1);
        Product product4 = new Product("Graphics Card", "444", 900, 1);
        
        Address usaAddress = new Address("5555 Prior Ridge", "Granite Bay", "CA", "USA");
        Address nonUsaAddress = new Address("4444 Lakeshore Rd", "Kelowna", "BC", "Canada");

        Customer usaCustomer = new Customer("Gretchen Wieners", usaAddress);
        Customer nonUsaCustomer = new Customer("Regina George", nonUsaAddress);

        Order order1 = new Order(usaCustomer);
        order1.AddProduct(product1);
        order1.AddProduct(product2); 
        order1.AddProduct(product3);
    
        Order order2 = new Order(nonUsaCustomer);
        order2.AddProduct(product2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:\n" + order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:\n" + order1.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order1.GetTotalPrice());
        Console.WriteLine();

        Console.WriteLine("Order 2:");
        Console.WriteLine("Packing Label:\n" + order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:\n" + order2.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order2.GetTotalPrice());
    }
}