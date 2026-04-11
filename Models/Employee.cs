namespace TestingApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MobileNo { get; set; }
        public string? Department { get; set; }
        public string? UnitId { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
