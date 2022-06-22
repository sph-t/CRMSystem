using CRMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRMSystem.Pages
{
    public class PatientCardModel : PageModel
    {
        private readonly CRMDbContext _dbContext;
        public Patient Patient { get; set; }
        public List<Appointment> PatientAppointments { get; set; }

        public PatientCardModel(CRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet(int id)
        {
            Patient = _dbContext.Patients.ToList().Find(p => p.PatientId == id);
            PatientAppointments = _dbContext.Appointments.OrderByDescending(a => a.DatetimeStart).ToList().FindAll(a => a.Patient == Patient && a.IsDeleted == false);
            
        }
    }
}
