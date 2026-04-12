using System.ComponentModel.DataAnnotations;

namespace TestingApp.ViewModels
{
    public class ToDoViewModel
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Status { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
