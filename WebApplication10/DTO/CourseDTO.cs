using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication10.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course Title Required")]
        [MinLength(3, ErrorMessage = "Length Must Be 3 Char AtLeast")]
        [StringLength(100, ErrorMessage = "Please Provide Course Title Less Than 100 Char")]
        public string Title { get; set; }


        [Column(TypeName = "tinyint")]
        [ForeignKey("Credit")]
        public int CreditHourse { get; set; }
    }
}
