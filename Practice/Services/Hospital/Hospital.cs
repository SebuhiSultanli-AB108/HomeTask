using Practice.Modules;
using static Practice.Exceptions.NotInTheList;

namespace Practice.Services.Hospital;

class Hospital
{
    List<Appointment> appointments = new();

    public void AddAppointment(Appointment appos)
    {
        appointments.Add(appos);
    }

    public void EndAppointment(int no)
    {
        Appointment? appo = appointments.Find(x => x.No == no);
        if (appo == null)
            throw new CustomNotInTheListException();
        else
            appo.EndDate = DateTime.Now;
    }
    public Appointment GetAppointment(int no)
    {
        Appointment? appo = appointments.Find(x => x.No == no);
        if (appo == null)
            throw new CustomNotInTheListException();

        return appo;
    }
    public List<Appointment> GetAllAppointments()
    {
        return appointments;
    }
    public List<Appointment>? GetWeeklyAppointments()
    {
        return GetAppointmentsByDays(7);
    }
    public List<Appointment> GetTodaysAppointments()
    {
        return GetAppointmentsByDays(1);
    }

    public List<Appointment> GetAllContinuingAppointments()
    {
        List<Appointment> appos = new();
        appos = appointments.FindAll(x => x.EndDate >= DateTime.Now);
        return appos; ;
    }

    private List<Appointment> GetAppointmentsByDays(int day)
    {
        List<Appointment> appos = new();
        appos = appointments.FindAll(x => x.StartDate >= DateTime.Now.AddDays(-day));
        return appos;
    }
}