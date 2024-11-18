namespace EF_Core.Models;

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int IsDeleted { get; set; }
}
