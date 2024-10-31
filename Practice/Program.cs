using Practice.Extensions;
using Practice.Modules;
using Practice.Services.Hospital;
using Practice.Services.People.Doctor;
using Practice.Services.People.Patient;

namespace Practice;

class Program
{
    static void Main()
    {
        Doctor Sabuhi = new Doctor("A15df84B", "Sabuhi", "Sultanli");
        Doctor Rick = new Doctor("UI54hf6d", "Rick", "Astley");

        Patient Eliqulu = new Patient("Qulaq infeksiyasi", false, "8FD684gh1", "Eliqulu", "Quluyev");
        Patient EbdulQasim = new Patient("KRX", false, "654gfd6sf", "EbdulQasim", "Daglaroglu");
        Patient Robert = new Patient("Perfection", true, "99999999", "Robert", "Perfect");

        Hospital Ab108 = new();
        List<Appointment> appos =
            [
            new Appointment(){
                No = 1,
                Doctor = Sabuhi,
                Patient = Eliqulu,
                StartDate = DateTime.Now.AddDays(-1).AddHours(5),
                EndDate = DateTime.Now.AddDays(1)
            },
            new Appointment(){
                No = 2,
                Doctor = Rick,
                Patient = EbdulQasim,
                StartDate = DateTime.Now.AddDays(-8),
                EndDate = DateTime.Now.AddDays(-1)
            },
            new Appointment(){
                No = 3,
                Doctor = Sabuhi,
                Patient = Robert,
                StartDate = DateTime.Now.AddDays(-6),
                EndDate = DateTime.Now.AddDays(-2)
            },
            ];

        foreach (Appointment appo in appos)
        {
            Ab108.AddAppointment(appo);
        }
        Ab108.GetAllAppointments().PrintInfo();
        Ab108.EndAppointment(3);
        Console.WriteLine(Ab108.GetAppointment(2).Patient.Name + " " + Ab108.GetAppointment(2).Patient.Surname);
        Ab108.GetAllAppointments().PrintInfo();
        Console.WriteLine("\n");
        Ab108.GetWeeklyAppointments().PrintInfo();
        Ab108.GetTodaysAppointments().PrintInfo();
        Console.WriteLine();
        Ab108.GetAllContinuingAppointments().PrintInfo();
    }
}