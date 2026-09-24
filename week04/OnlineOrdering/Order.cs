public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal productTotal = _products.Sum(product => product.GetTotalCost());
        decimal shippingCost = _customer.LivesInUsa() ? 5m : 35m;
        return productTotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        List<string> labelLines = new List<string> { "Packing Label" };

        foreach (Product product in _products)
        {
            labelLines.Add($"{product.GetName()} ({product.GetProductId()})");
        }

        return string.Join(Environment.NewLine, labelLines);
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label{Environment.NewLine}{_customer.GetName()}{Environment.NewLine}{_customer.GetAddress().GetAddressString()}";
    }
}