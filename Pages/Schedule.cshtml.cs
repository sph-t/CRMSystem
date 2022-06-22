using CRMSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace CRMSystem.Pages
{
    public class ScheduleModel : PageModel
    {
        private readonly CRMDbContext _dbContext;
        public List<Appointment> Appointments { get; set; }
        [BindProperty]
        public DateTime NewDate { get; set; }
        public DateTime Date { get; set; }
        public ScheduleModel(CRMDbContext dbContext)
        {
            _dbContext = dbContext;
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
            //Date = DateTime.ParseExact(date, format: "dd.MM.yyyy h:mm:ss", CultureInfo.InvariantCulture);
            Appointments = _dbContext.Appointments.ToList();
            Appointments.Sort((x, y) => x.DatetimeStart.CompareTo(y.DatetimeStart));
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("./Schedule", new { date = NewDate });
        }
    }
}
