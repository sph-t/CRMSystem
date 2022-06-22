using CRMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace CRMSystem.Pages
{
    public class PatientsDatabaseModel : PageModel
    {
        private readonly CRMDbContext _dbContext;
        public List<Patient> Patients { get; set; }
        public List<Appointment> Appointments { get; set; }
        public Dictionary<Patient, double> Spent { get; set; }

        public PatientsDatabaseModel(CRMDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public void OnGet()
        {
            Patients = _dbContext.Patients.ToList();
            Appointments = _dbContext.Appointments.ToList();
            Spent = new Dictionary<Patient, double>();

            foreach (var patient in Patients)
            {
                Spent.Add(patient, Appointments.FindAll(a => a.Patient == patient && a.IsMissed == false && a.IsDeleted == false).Sum(a => a.Price is null ? 0 : (double)a.Price));
            
            }
            
            Patients.Sort((x, y) => Spent[y].CompareTo(Spent[x]));
        }
    }
}
