using CRMSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMSystem;

public sealed class CRMDbContext: DbContext
{
    public CRMDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
    {
        Database.Migrate();
       // Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=CRM.sqlite");
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Procedure> Procedures { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>().HasAlternateKey(u => u.PhoneNumber);
        modelBuilder.Entity<Patient>().HasAlternateKey(u => u.Login);
        modelBuilder.Entity<Doctor>().HasAlternateKey(u => u.PhoneNumber);
    }
}