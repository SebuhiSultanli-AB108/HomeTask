using Practice.Modules;

namespace Practice.Extensions;

static class AppointmentExtension
{
    public static void PrintInfo(this List<Appointment> appos)
    {
        Console.WriteLine("======================================================================================================");
        Console.WriteLine("No".PadRight(5, ' ') +
                "Id".PadRight(12, ' ') +
                "Name".PadRight(12, ' ') +
                "Surname".PadRight(12, ' ') +
                "Doctor".PadRight(15, ' ') +
                "StartDate".PadRight(25, ' ') + " " +
                "EndDate".PadRight(25, ' ') +
                "\n"
                );
        foreach (Appointment a in appos)
        {
            Console.WriteLine(
                a.No.ToString().PadRight(5, ' ') +
                a.Patient.Id.PadRight(12, ' ') +
                a.Patient.Name.PadRight(12, ' ') +
                a.Patient.Surname.PadRight(12, ' ') +
                (a.Doctor.Name + '.' + a.Doctor.Surname[0]).PadRight(15, ' ') +
                a.StartDate.ToString().PadRight(25, ' ') + " " +
                a.EndDate.ToString().PadRight(25, ' ')
                );
        }
        Console.WriteLine("======================================================================================================");
    }
}
