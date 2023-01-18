using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10.Models
{
    public class TeacherEnrollement
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }


        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
