using LibraryMP.Models;

namespace LibraryMP;
internal class Program
{
    static void Main()
    {
        Library Library1 = new Library("Library1");

        if (!File.Exists(Library1.path))
        {
            File.WriteAllTextAsync(Library1.path, "{}");
        }
        else
        {
            Console.WriteLine($"File already exist in the path: {Library1.path}");
        }
        Help();
        bool isLooping = true;
        while (isLooping)
        {
            Console.WriteLine("\nYour input:");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 0:
                    Console.WriteLine("Bye!");
                    isLooping = false;
                    break;
                case 1:
                    Console.WriteLine("========>Add Book<========");
                    Book newBook = CreateBook();
                    Library1.AddBook(newBook);
                    break;
                case 2:
                    Console.WriteLine("=====>Get Book By Id<=====");
                    Console.WriteLine("Enter the id: ");
                    int getId = Convert.ToInt32(Console.ReadLine());
                    Book book = Library1.GetBookById(getId);
                    if (book != null) book.ShowInfo();
                    break;
                case 3:
                    Console.WriteLine("======>Remove book<======");
                    Console.WriteLine("Enter the id: ");
                    int removeId = Convert.ToInt32(Console.ReadLine());
                    Library1.RemoveBook(removeId);
                    break;
                case 4:
                    Console.WriteLine("====>Print all books<====");
                    Library1.PrintAllBookInfo();
                    break;
                default:
                    Help();
                    break;
            }
        }

        Book CreateBook()
        {
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Author Name:");
            string authorName = Console.ReadLine();
            Console.WriteLine("Price:");
            float price = Convert.ToSingle(Console.ReadLine());

            Book newBook = new Book()
            {
                Name = name,
                AuthorName = authorName,
                Price = price
            };
            return newBook;
        }


        void Help()
        {
            Console.WriteLine("""          
                          =======>Menu<=======   
                          1. Add book            
                          2. Get book by id       /\_/\
                          3. Remove book         ( o.o )
                          4. Print all books       >^<
                          0. Quit
                          ====================   
                          """);
        }
    }
}