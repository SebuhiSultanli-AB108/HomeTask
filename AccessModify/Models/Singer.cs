namespace AccessModify.Models
{
    class Singer
    {
        //Singer class-ı olsun. Singer-in Name, Surname, Age prop-ları olsun. Name və Surname max 100 uzunluqda set oluna bilər. Age max 170 ola bilər.

        private string _name;
        private string _surname;
        private int _age;


        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length <= 100) _name = value;
                else Console.WriteLine("Name is too long!");
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (value.Length <= 100) _surname = value;
                else Console.WriteLine("Name is too long!");
            }
        }
        public int Age { get { return _age; } set { if (value <= 170) _age = value; } }

        public Song[] Songs;

        public Singer(string Name, string Surname, int Age)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
        }

        public void ListSongs()
        {
            Console.WriteLine($"Author: {Name} {Surname}");
            Console.WriteLine("Music List: ");

            Console.WriteLine("------------------------------");
            for (int i = 0; i < Songs.Length; i++)
                Console.WriteLine((i + 1) + ". " + Songs[i].Name);

            Console.WriteLine("------------------------------");
        }
    }
}
