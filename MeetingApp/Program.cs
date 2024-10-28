using MeetingApp.Models;

namespace MeetingApp;

internal class Program
{
    static void Main()
    {
        MeetingSchedule MS = new MeetingSchedule();

        try
        {
            MS.SetMeeting("MyMeeting1", DateTime.Today, DateTime.Today.AddHours(1));
            MS.SetMeeting("MyMeeting2", DateTime.Today, DateTime.Today.AddHours(2));
            MS.SetMeeting("MyMeeting3", DateTime.Today.AddHours(5), DateTime.Today.AddHours(3));
        }
        catch (ReservedDateInterval)
        {
            Console.WriteLine("ReservedDateInterval");
        }
        catch (WrongDateInterval)
        {
            Console.WriteLine("WrongDateInterval");
        }


        foreach (var item in MS.Meetings)
        {
            Console.WriteLine(item.FullName);
        }
    }
}