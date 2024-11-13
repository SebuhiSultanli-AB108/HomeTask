using Newtonsoft.Json;

namespace LibraryMP.Models;

class Library
{
    int GeneralId = 0;
    public int Id { get; }
    public string Name { get; set; }
    public List<Book> Books = new List<Book>();

    public string path = @"C:\Users\Phoenix\Desktop\HomeTask\LibraryMP\Files\Database.json";

    public Library(string name)
    {
        Id = GeneralId;
        GeneralId++;
        Name = name;
    }

    public void AddBook(Book book)
    {
        Update(ref Books);
        Books.Add(book);
        Save(Books);
    }
    public void RemoveBook(int id)
    {
        Update(ref Books);
        foreach (Book book in Books)
        {
            if (book.Id == id)
            {
                Books.Remove(book);
                return;
            }
        }
        Console.WriteLine("The Books that u are looking for is not in the Books list !!!");
        Save(Books);
    }
    public Book? GetBookById(int id)
    {
        Update(ref Books);
        foreach (Book book in Books)
        {
            if (book.Id == id) return book;
        }
        Console.WriteLine("The Books that u are looking for is not in the Books list !!!");
        return null;
    }
    public void PrintAllBookInfo()
    {
        Update(ref Books);
        if (Books.Count == 0)
        {
            Console.WriteLine("Book list is empty!");
            return;
        }

        int count = 0;
        Console.WriteLine("");
        foreach (Book book in Books)
        {
            count++;
            Console.WriteLine($"{count}. {book.Name} {book.AuthorName} {book.Price}$");
        }
        Console.WriteLine("");
    }
    void Save(List<Book> books)
    {
        using StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(JsonConvert.SerializeObject(books));
    }
    void Update(ref List<Book> books)
    {
        using StreamReader reader = new StreamReader(path);
        List<Book> newBooks = JsonConvert.DeserializeObject<List<Book>>(reader.ReadToEnd());
        if (books == null) books = new List<Book>();
        books.Clear();
        books.AddRange(newBooks);
    }
}