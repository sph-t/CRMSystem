using Microsoft.EntityFrameworkCore;

namespace CRMSystem.Models
{
    public class Appointment
    {
        public virtual int AppointmentId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Procedure Procedure { get; set; }
        public virtual DateTime DatetimeStart { get; set; }
        public virtual DateTime DatetimeEnd { get; set; }
        public virtual double? Price { get; set; }
        public virtual Patient? Patient { get; set; }
        public virtual bool IsMissed { get; set; }
        public virtual bool IsDeleted { get; set; }

        //protected CRMDbContext dbContext = new CRMDbContext(new DbContextOptionsBuilder().UseLazyLoadingProxies().UseSqlite("CRMDb").Options);
    }
}
