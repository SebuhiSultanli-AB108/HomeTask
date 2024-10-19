namespace AccessModify.Models;

class Song
{
    /*
     Song class-ı olsun. Song-un Name, Genre, Singer(agregation) prop-ları olsun. Name max 100 uzunluqda set oluna bilər. 
     Genre yalnız "Pop", "Rock", "Jazz", "Techno" bu value-lardan biri ola bilər. Məsələn  "Classic" ola bilməz, yalnız göstərilənlərdən biri set olunmalıdır.
     Song-un rating-ləri olsun. AddRating, GetAverageRating metodları ilə funksionallıq təmin olunsun.
     */

    private string _name;
    private string _genre;

    public string Name
    {
        get { return _name; }
        set
        {
            if (value.Length <= 100) _name = value;
            else Console.WriteLine("Name is too long!");
        }
    }

    private string[] Genres = { "Pop", "Rock", "Jazz", "Techno" };
    public string Genre
    {
        get { return _genre; }
        set
        {
            if (Genres.Contains(value)) _genre = value;
            else Console.WriteLine("Genre must be one of these: \n Pop\n Rock\n Jazz\n Techno\n");
        }
    }
    public Singer Singer { get; set; }
    public float[] Ratings;

    public Song(string Name, string Genre, Singer Singer, float[] Ratings)
    {
        this.Name = Name;
        this.Genre = Genre;
        this.Singer = Singer;
        this.Ratings = Ratings;
    }

    public void AddRating(float newRating)
    {
        float[] newRatings = new float[Ratings.Length + 1];
        for (int i = 0; i < Ratings.Length; i++) newRatings[i] = Ratings[i];
        newRatings[newRatings.Length - 1] = newRating;
        Ratings = newRatings;
    }

    public float GetAverageRating()
    {
        float sum = 0f;
        foreach (float item in Ratings) sum += item;
        sum /= Ratings.Length;
        return sum;
    }
}
