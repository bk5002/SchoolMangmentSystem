using System.ComponentModel.DataAnnotations;

namespace WebApplication10.DTO
{
    public class SetMarks
    {
        [Required(ErrorMessage = "Please Provide Id")]
        public int? AssignmentId { get; set; }

        [Required(ErrorMessage = "Please Provide Marks")]
        public int? AssignedId { get; set; }

        [Required(ErrorMessage = "Please Provide Marks")]
        [Range(minimum: 0, maximum: 100)]
        public int? ObtainMarks { get; set; }

        [Required(ErrorMessage = "Please Provide Marks")]
        [StringLength(350, ErrorMessage = "Remarks length Can't Be More Than 350")]
        public string Remarks { get; set; }
    }
}
