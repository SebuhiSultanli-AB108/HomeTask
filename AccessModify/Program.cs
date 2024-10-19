using AccessModify.Models;

namespace AccessModify;

internal class Program
{
    static void Main()
    {
        Singer MikiMatsu = new Singer("Matsubara", "Miki", 44);
        Singer RickAstley = new Singer("Rick", "Astley", 58);
        Singer Hoizer = new Singer("Andrew", "Hoizer-Byrne", 34);

        Song SWM = new Song("Stay With Me", "Pop", MikiMatsu, [10f, 10f, 10f]);
        Song NGGYU = new Song("Never Gonna Give You Up", "Pop", RickAstley, [9.1f, 9.5f, 10f]);
        Song TS = new Song("Too Sweet", "Rock", Hoizer, [8.1f, 7.1f, 6.9f, 10f, 9.1f, 9.5f]);
        Song TMTC = new Song("Take Me to Church", "Psop", Hoizer, [10f, 10f, 10f, 9.9f, 10f]);

        SWM.AddRating(9.9f);
        NGGYU.AddRating(9.9f);

        MikiMatsu.Songs = [SWM];
        RickAstley.Songs = [NGGYU];
        Hoizer.Songs = [TS, TMTC];

        Console.Write($"Average Rating of {TS.Name}: ");
        Console.WriteLine(TS.GetAverageRating());
        Console.WriteLine("");
        Hoizer.ListSongs();
    }
}
