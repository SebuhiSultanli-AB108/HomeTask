using Practice.Services.People.Doctor;
using Practice.Services.People.Patient;

namespace Practice.Modules;

class Appointment
{
    public int No { get; set; }
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}