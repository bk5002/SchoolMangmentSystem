

using System.ComponentModel.DataAnnotations;

namespace WebApplication10.DTO
{
    public class CourseIdDTO
    {
        [Required(ErrorMessage ="CourseId Is Required")]
        public int? CourseId { get; set; }
    }
}
