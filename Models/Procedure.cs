namespace CRMSystem.Models
{
    public class Procedure
    {
        public virtual int ProcedureId { get; set; }
        public virtual string Name { get; set; }
        public virtual double BasePrice { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual List<Doctor> Doctors { get; set; }
    }
}
