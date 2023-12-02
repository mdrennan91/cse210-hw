class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalPrice()
    {
        decimal totalPrice = 0;

        foreach (Product product in _products)
        {
            totalPrice += product.GetPrice();
        }

        if (_customer.IsInUSA())
        {
            totalPrice += 5;
        }
        else
        {
            totalPrice += 35;
        }

        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";

        foreach (Product product in _products)
        {
            packingLabel += $"Product: {product.GetName()}, ID: {product.GetProductId()}\n";
        }

        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Customer: {_customer.GetName()}\n{_customer.GetAddress().ToString()}";
    }
}
