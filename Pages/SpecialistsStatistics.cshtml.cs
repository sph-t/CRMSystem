using CRMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRMSystem.Pages
{
    public class SpecialistsStatisticsModel : PageModel
    {
        private readonly CRMDbContext _dbContext;
        public List<Appointment> Appointments { get; set; }
        public IEnumerable<IGrouping<Doctor, Appointment>> AppointmentGroups { get; set; }
        public SpecialistsStatisticsModel(CRMDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet()
        {
            Appointments = _dbContext.Appointments.ToList();
            AppointmentGroups = Appointments.Where(a => a.IsMissed == false).GroupBy(a => a.Doctor).OrderByDescending(g => g.Count() == 0 ? 0: g.Sum(a => a.Price is null ? 0 : (double)a.Price));
        }
    }
}
