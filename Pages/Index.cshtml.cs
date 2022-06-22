using CRMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRMSystem.Pages
{
    public class IndexModel : PageModel
    {
        protected readonly CRMDbContext _dbContext;
        public List<Appointment> apps;
        public List<Doctor> doctors;
        public List<Procedure> procedures;
        public List<Patient> patients;

        public IndexModel(CRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            apps = _dbContext.Appointments.ToList();
            apps.Sort((x, y) => x.DatetimeStart.CompareTo(y.DatetimeStart));
            apps.Reverse();
            doctors = _dbContext.Doctors.ToList();
            procedures = _dbContext.Procedures.ToList();
            patients = _dbContext.Patients.ToList();
        }
    }
}
