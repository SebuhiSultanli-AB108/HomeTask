namespace Practice.Services.People.Patient;

public class Patient : People
{
    string _diseases { get; set; }
    bool _hasInsurance { get; set; }
    public Patient(string diseases, bool hasInsurance, string id, string name, string surname) : base(id, name, surname)
    {
        _diseases = diseases;
        _hasInsurance = hasInsurance;
    }
}
