namespace MedbaseHybrid.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public double Amount { get; set; }
    }
}
