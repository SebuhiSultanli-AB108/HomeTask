namespace Methods
{
    internal class Program
    {
        static void Main()
        {
            #region Task 1
            /*--> Area deyə Method(lar) yaradılır. <--*/

            //Console.Write(Area(5));
            //Console.Write(Area(5, 6));
            //Console.Write(Area(5, 6, 7));
            //Console.Write(Area(5, 6, 7, 8));
            #endregion

            #region Task A
            /*--> Method yaradirsiz 2 eded ve 1 operator('+','-','*','/') qebul edir. Qebul etdiyi operatora uygun a v' b ədədləri üzərində hesablama aparib alinan deyeri qaytarır. <--*/

            //Console.WriteLine("Zehmet olmasa emeliyyati (a ve 'emeliyyat' ve b) daxil edin: ");
            //Console.Write("Birinci eded: ");
            //float num1 = float.Parse(Console.ReadLine());
            //Console.Write("Birinci emeliyyat: ");
            //char command = Convert.ToChar(Console.ReadLine());
            //Console.Write("Ikinci eded: ");
            //float num2 = float.Parse(Console.ReadLine());

            //Console.WriteLine(Calculate(num1, command, num2));
            #endregion

            #region Task B
            /*--> Method yaradırsız əgər methoda bir eded gonderilirse hemin ededin kvadratını, iki eded gonderilirse 1ci ədədi ikinci ədəd qədər qüvvətinə yüksəldirsiz. <--*/

            //Console.WriteLine(CustomPow(2));
            //Console.WriteLine(CustomPow(2,5));
            #endregion

            #region Task C
            /*--> 
             * Methodlar yaradirsiz.
             * Methoda ad gonderende adi ekrana cixardir.
             * ad ve soyad gonderende soyadi adi ekrana cixardir.
             * ad, soyad ve ata adı göndərildikdə adin baş hərfi nöqtə soyad ata adi ekrana cixardirsiz. 
             * Methodlarin adi eyni olmalıdır.
            <--*/

            //Console.WriteLine(Name("Sabir"));
            //Console.WriteLine(Name("Sabir", "Guliyev"));
            //Console.WriteLine(Name("Sabir", "Guliyev", "Mehti"));
            #endregion
        }

        static float Area(float radius)
        {
            Console.Write("Çevrənin sahəsi: ");
            float S = 3.14f * radius * radius;
            return S;
        }
        static float Area(float height, float width)
        {
            Console.Write("Düzbucaqlının sahəsi: ");
            float S = height * width;
            return S;
        }
        static float Area(float height, float width, float length)
        {
            Console.Write("Düzbucaqlı paralelpipedin tam səthinin sahəsi: ");
            float S = 2 * (height * width + height * length + width * length);
            return S;
        }
        static float Area(float a, float b, float c, float radius)
        {
            Console.Write("Üçbucaqlının daxilinə çəkilmiş çevrənin sahəsi: ");
            float S = (a + b + c) / 2 * radius;
            return S;
        }

        static float Calculate(float a, char com, float b)
        {
            float num = 0f;
            switch (com)
            {
                case '*':
                    num = a * b;
                    break;
                case '+':
                    num = a + b;
                    break;
                case '/':
                    num = b / a;
                    break;
                case '-':
                    num = a - b;
                    break;
            }
            return num;
        }

        static float CustomPow(float a, float b)
        {
            float mem = a;
            for (int i = 1; i < b; i++)
            {
                a *= mem;
            };
            return a;
        }

        static float CustomPow(float a)
        {
            float lenght = a;
            for (int i = 1; i < lenght; i++)
            {
                a *= lenght;
                Console.WriteLine(a);
            }
            return a;
        }

        static string Name(string name)
        {
            return name;
        }
        static string Name(string name, string surname)
        {
            return $"{surname} {name}";
        }
        static string Name(string name, string surname, string parentName)
        {
            return $"{name[0]}.{surname} {parentName}";
        }
    }
}
