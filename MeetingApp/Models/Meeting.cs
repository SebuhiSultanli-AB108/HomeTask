namespace MeetingApp.Models;

public class Meeting
{
    public string FullName { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }

    public Meeting(string fullName, DateTime fromDate, DateTime toDate)
    {
        FullName = fullName;
        FromDate = fromDate;
        ToDate = toDate;


    }
}


public class ReservedDateInterval : Exception
{
    public ReservedDateInterval() : base("ReservedDateInterval") { }
    public ReservedDateInterval(string message) : base(message) { }
}

public class WrongDateInterval : Exception
{
    public WrongDateInterval() : base("WrongDateInterval") { }
    public WrongDateInterval(string message) : base(message) { }
}

public class MeetingSchedule
{
    public Meeting[] Meetings = new Meeting[0];

    public void SetMeeting(string fullName, DateTime fromDate, DateTime toDate)
    {
        foreach (var item in Meetings)
        {
            if ((item.FromDate > fromDate && item.ToDate < fromDate) || (item.FromDate > toDate && item.ToDate < toDate))
            {
                throw new ReservedDateInterval();
            }
        }
        if (fromDate > toDate)
        {
            throw new WrongDateInterval();
        }

        Meeting newMeeting = new Meeting(fullName, fromDate, toDate);
        Meeting[] newArr = new Meeting[Meetings.Length + 1];
        for (int i = 0; i < Meetings.Length; i++)
        {
            newArr[i] = Meetings[i];
        }
        newArr[newArr.Length - 1] = newMeeting;
        Meetings = newArr;
    }
}