using FileStream.Models;

namespace FileStream;
class Program
{
    static void Main()
    {
        FileManager fm = new FileManager(@"C:\Users\Phoenix\Desktop\HomeTask\FileStream\Json\Data.json");
        fm.Add("Sebuhi");
        fm.Add("HumanA");
        fm.Add("HumanB");
        fm.Add("HumanC");
        fm.Update(2, "HumanD");
        fm.Delete(3);
    }
}