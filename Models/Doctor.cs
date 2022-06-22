namespace CRMSystem.Models
{
    public class Doctor
    {
        public virtual int DoctorId { get; set; }
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string? PaternalName { get; set; }
        public virtual DateTime? DateOfBirth { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string? Email { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual List<Procedure>? Procedures { get; set; }
    }
}
