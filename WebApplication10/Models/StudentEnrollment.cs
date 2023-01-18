using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10.Models
{
    public class StudentEnrollment
    {
        [Key]
        public int Id { get; set; }
        
       
        [Column(TypeName = "tinyint")]
        public int? Marks { get; set; }


        [Column(TypeName = "tinyint")]
        [ForeignKey("Grade")]
        public int? GradeId { get; set; }
        public Grade? Grade { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }


        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
