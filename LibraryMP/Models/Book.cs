namespace LibraryMP.Models;

class Book
{
    static int GeneralId;
    public int Id { get; }
    public string Name { get; set; }
    public string AuthorName { get; set; }
    public float Price { get; set; }


    public Book()
    {
        GeneralId++;
        if (Id == 0) Id = GeneralId;
    }

    public void ShowInfo()
    {
        Console.WriteLine($""""
                          Id: {Id}
                          Name: {Name}
                          Author Name: {AuthorName}
                          Price: {Price}
                          """");
    }
}