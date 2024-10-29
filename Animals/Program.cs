using Animals.Models;

namespace Animals;

internal class Program
{
    static void Main()
    {
        Wolf alfaWolf = new Wolf()
        {
            AttackDamage = 25,
            AvgLifeTime = 35,
            Breed = "GrayWolf",
            HP = 100,
            IsPrideLeader = true,
            AnimalGender = Animal.Gender.Male,
        };

        Wolf betaWolf = new Wolf()
        {
            AttackDamage = 10,
            AvgLifeTime = 45,
            Breed = "GrayWolf",
            HP = 60,
            IsPrideLeader = false,
            AnimalGender = Animal.Gender.Female,
        };
        Wolf sigmaWolf = new Wolf()
        {
            AttackDamage = 40,
            AvgLifeTime = 25,
            Breed = "Andrew Tate",
            HP = 70,
            IsPrideLeader = false,
            AnimalGender = Animal.Gender.Male,
        };
        Elephant elephant1 = new Elephant()
        {
            HP = 100,
            IsTrained = true,
            Weight = 100,
            AnimalGender = Animal.Gender.Male,
        };
        Elephant elephant2 = new Elephant()
        {
            HP = 70,
            IsTrained = false,
            Weight = 200,
            AnimalGender = Animal.Gender.Female,
        };
        Meat meat1 = new Meat() { Calorie = 2000, MeatType = Meat.Type.Beef };
        Meat meat2 = new Meat() { Calorie = 2500, MeatType = Meat.Type.Pork };

        Grass grass1 = new Grass() { Calorie = 1000, Name = "LongGrass" };
        Grass grass2 = new Grass() { Calorie = 700, Name = "ShortGrass" };

        ZooCage<Animal, Food> Cage = new ZooCage<Animal, Food>();
        Cage.Add(alfaWolf);
        Cage.Add(betaWolf);
        Cage.Add(sigmaWolf);
        Cage.Add(elephant1);
        Cage.Add(elephant2);
        Cage.Add(meat1);
        Cage.Add(meat2);
        Cage.Add(grass1);
        Cage.Add(grass2);

        Cage.PrintInfo();
        sigmaWolf.Hunt<Animal>(elephant1);
        Cage.PrintInfo();
    }
}