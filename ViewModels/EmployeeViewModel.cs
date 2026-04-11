using System.ComponentModel.DataAnnotations;

namespace TestingApp.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? MobileNo { get; set; }
        [Required]
        public string? Department { get; set; }
        [Required]
        public string? UnitId { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public bool IsActive { get; set; }
    }
}
