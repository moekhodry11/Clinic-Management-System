namespace Clinic.Domain.Entities;
    public class Subscription
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ClinicId { get; set; }
        public virtual MyClinic MyClinic { get; set; }
    }

