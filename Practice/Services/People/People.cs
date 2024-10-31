namespace Practice.Services.People;

public abstract class People
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    protected People(string id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
    }
}
