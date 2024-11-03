using Newtonsoft.Json;

namespace FileStream.Models;

class FileManager
{
    string link = string.Empty;
    public FileManager(string link)
    {
        this.link = link;
    }
    List<string> strList = new();
    public void Add(string name)
    {
        Read(strList);
        if (!strList.Contains(name))
            strList.Add(name);
        Write(strList);
    }
    public void Update(int index, string name)
    {
        Read(strList);
        try
        {
            strList[index] = name;
        }
        catch (Exception)
        {
            Console.WriteLine("Cant find what u are looking for mate!");
        }
        Write(strList);
    }
    public void Delete(int index)
    {
        Read(strList);
        try
        {
            strList.RemoveAt(index);
        }
        catch (Exception)
        {
            Console.WriteLine("Cant find what u are looking for mate!");
        }
        Write(strList);
    }
    private void Read(object? obj)
    {
        using StreamReader reader = new StreamReader(link);
        List<string> strArr = JsonConvert.DeserializeObject<List<string>>(reader.ReadToEnd());
        obj = strArr;
    }
    private void Write(object? obj)
    {
        using StreamWriter writer = new StreamWriter(link, false);
        writer.WriteLine(JsonConvert.SerializeObject(obj));
    }


    /*
    List<string> yaradırsınız. Bunu names.json adlı jsona yazırsınız.
    void Add(string name)
    bool Exist(stiring name)
    void Update(int index, string name)
    void Delete(int index)
    Metodlarını adlarına uyğun olaraq yazın
    */
}