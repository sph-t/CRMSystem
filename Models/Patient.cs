namespace CRMSystem.Models
{
    public class Patient
    {
        public virtual int PatientId { get; set; }
        public virtual string? Login { get; set; }
        public virtual string? Password { get; set; }
        public virtual string? LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string? PaternalName { get; set; }
        public virtual DateTime? DateOfBirth { get; set; }
        public virtual string? Sex { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string? Email { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}
