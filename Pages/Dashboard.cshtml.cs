using CRMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace CRMSystem.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly CRMDbContext _dbcontext;
        public List<Appointment> Appointments { get; set; }
        public DateTime Date { get; set; }
        [BindProperty]
        public DateTime NewDate { get; set; }
        public Patient MostLoyalPatient { get; set; }
        public Doctor MostPopularDoctor { get; set; }
        public Doctor MostProfitDoctor { get; set; }
        public DashboardModel(CRMDbContext context)
        {
            _dbcontext = context;
            Appointments = _dbcontext.Appointments.ToList();
        }
        public void OnGet(string date)
        {
            date = date.Replace("%2F", ".");
            DateTime result;
            DateTime.TryParse(date, out result);
            if (result == DateTime.MinValue)
            {
                Date = DateTime.ParseExact(date, format: "MM.dd.yyyy hh:mm:ss", CultureInfo.InvariantCulture);
            }
            else
            {
                Date = result;
            }

            Appointments = Appointments.FindAll(a => a.DatetimeStart.Date == Date && a.IsDeleted == false);
            if (Appointments.GroupBy(a => a.Patient).Select(group => new { patient = group.Key, count = group.Count() }).OrderByDescending(g => g.count).Count() == 0)
            {
                MostLoyalPatient = null;
            }
            else {
                MostLoyalPatient = Appointments.GroupBy(a => a.Patient).Select(group => new { patient = group.Key, count = group.Count() }).OrderByDescending(g => g.count).First().patient;
            }
            //MostLoyalPatient = Appointments.GroupBy(a => a.Patient).Select(group => new { patient = group.Key, count = group.Count() }).OrderByDescending(g => g.count).First().patient;
            if (Appointments.GroupBy(a => a.Doctor).Select(group => new { doctor = group.Key, count = group.Count() }).OrderByDescending(g => g.count).Count() == 0)
            {
                MostPopularDoctor = null;
            }
            else { MostPopularDoctor = Appointments.GroupBy(a => a.Doctor).Select(group => new { doctor = group.Key, count = group.Count() }).OrderByDescending(g => g.count).First().doctor; }

            if (Appointments.GroupBy(a => a.Doctor).Select(group => new { doctor = group.Key, sum = group.Sum(g => g.Price) }).OrderByDescending(g => g.sum).Count() == 0)
            {
                MostProfitDoctor = null;
            }
            else
            {
                MostProfitDoctor = Appointments.GroupBy(a => a.Doctor).Select(group => new { doctor = group.Key, sum = group.Sum(g => g.Price) }).OrderByDescending(g => g.sum).First().doctor;
            }

        }
        public IActionResult OnPost()
        {
            return RedirectToPage("./Dashboard", new { date = NewDate });
        }
    }
}
