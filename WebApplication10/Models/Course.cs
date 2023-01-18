using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

       
        [Required(ErrorMessage ="Course Title Required")]
        [StringLength(100, ErrorMessage = "Please Provide Course Title Less Than 100 Char")]
        public string Title { get; set; }


        [Column(TypeName = "tinyint")]
        [ForeignKey("Credit")]
        public int CreditId { get; set; }
        public Credit Credit { get; set; }

        public IEnumerable<StudentEnrollment> StudentEnrollment { get; set; }
        public IEnumerable<TeacherEnrollement> TeacherEnrollement { get; set; }

    }
}
