namespace Animals.Models;

abstract class Animal
{
    public int AvgLifeTime { get; set; }
    public string Breed { get; set; }
    public int HP { get; set; }
    public Gender AnimalGender { get; set; }
    public enum Gender : byte
    {
        Male = 1,
        Female = 2
    }
}


class Wolf : Animal
{
    public bool IsPrideLeader { get; set; }
    public int AttackDamage { get; set; }

    public void Hunt<T>(Animal animal)
    {
        animal.HP -= AttackDamage;
    }
}

class Elephant : Animal
{
    public double Weight { get; set; }
    public bool IsTrained { get; set; }
}

abstract class Food
{
    public int Calorie { get; set; }
}

class Meat : Food
{
    public Type MeatType { get; set; }
    public enum Type : byte
    {
        Beef = 1,
        Chicken = 2,
        Pork = 3
    }
}

class Grass : Food
{
    public string Name { get; set; }
}

class ZooCage<T, U>
    where T : Animal
    where U : Food
{
    T[] Animals = [];
    U[] Foods = [];

    public void Add(T animal)
    {
        Array.Resize(ref Animals, Animals.Length + 1);
        Animals[^1] = animal;
    }
    public void Add(U food)
    {
        Array.Resize(ref Foods, Foods.Length + 1);
        Foods[^1] = food;
    }
    public void PrintInfo()
    {
        Console.WriteLine("0 - Info for Animals\n" + "1 - Info for Food");
        int input = Convert.ToInt32(Console.ReadLine());
        bool printInfoAnimal = false;
        switch (input)
        {
            case 0:
                printInfoAnimal = true;
                break;
            case 1:
                printInfoAnimal = false;
                break;
            default:
                Console.WriteLine("Invalid input!");
                Console.WriteLine("0 - Info for Animals\n" + "1 - Info for Food");
                break;
        }

        if (printInfoAnimal)
        {
            foreach (var animal in Animals)
            {
                Console.WriteLine("====================================");
                Console.WriteLine($"Breed: {animal.Breed}\nAnimal Gender: {animal.AnimalGender}\nHP: {animal.HP}");
            }
            Console.WriteLine("====================================");
        }
        else
            foreach (var food in Foods)
            {
                Console.WriteLine("Calorie:" + food.Calorie);
            }

    }
}