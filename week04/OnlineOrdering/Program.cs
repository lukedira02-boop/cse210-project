Address usaAddress = new Address("123 Main Street", "Provo", "UT", "USA");
Customer usaCustomer = new Customer("Jordan Lee", usaAddress);
Order usaOrder = new Order(usaCustomer);
usaOrder.AddProduct(new Product("Notebook", "NB-101", 4.50m, 2));
usaOrder.AddProduct(new Product("Blue Pen Set", "PS-204", 6.25m, 1));

Address internationalAddress = new Address("45 Queen Street", "Toronto", "Ontario", "Canada");
Customer internationalCustomer = new Customer("Taylor Smith", internationalAddress);
Order internationalOrder = new Order(internationalCustomer);
internationalOrder.AddProduct(new Product("Desk Lamp", "DL-310", 24.99m, 1));
internationalOrder.AddProduct(new Product("Office Chair Mat", "CM-415", 31.50m, 2));
internationalOrder.AddProduct(new Product("Cable Organizer", "CO-522", 8.75m, 3));

List<Order> orders = new List<Order> { usaOrder, internationalOrder };

foreach (Order order in orders)
{
    Console.WriteLine(order.GetPackingLabel());
    Console.WriteLine();
    Console.WriteLine(order.GetShippingLabel());
    Console.WriteLine();
    Console.WriteLine($"Total Cost: ${order.GetTotalCost():F2}");
    Console.WriteLine(new string('-', 40));
}