namespace Classes
{
    internal class Program
    {
        static void Main()
        {
            Product[] Productlist = 
            {
                new Product("Ally", "ROG", 622.99),
                new Product("SteamDeck", "Steam", 739.99),
                new Product("Legion", "Lenovo", 1889.99),
                new Product("Aspire", "Acer", 799.99),
                new Product("TUF", "ASUS", 999.99),
            };

            double min = 750;
            double max = 1000;

            ShowItemPriceAtRange(Productlist, min, max);

            static void ShowItemPriceAtRange(Product[] productList, double minPrice, double maxPrice)
            {
                foreach (Product product in productList)
                {
                    if (product.Price < maxPrice && product.Price > minPrice)
                    {
                        Console.WriteLine("---------------------------");
                        Console.WriteLine($"Product name: {product.Name}");
                        Console.WriteLine($"Product brand: {product.BrandName}");
                        Console.WriteLine($"Price: {product.Price}");
                        Console.WriteLine("---------------------------");
                    }
                }
            }
        }
    }
}
