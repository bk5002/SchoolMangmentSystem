using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Instruction Field Can't Be Empty")]
        [StringLength(100,ErrorMessage ="Title length Can't Be More Than 100")]
        public string Title { get; set; }

        [StringLength(250,ErrorMessage ="FileUrl length Can't Be More Than 250")]
        public string FileUrl { get; set; }


        [Required(ErrorMessage ="Instruction Field Can't Be Empty")]
        [StringLength(350,ErrorMessage ="Instruction length Can't Be More Than 350")]
        public string Instruction { get; set; }

        [Column(TypeName = "tinyint")]
        public int TotalMarks { get; set; }


        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage ="DeadLine Date Is Required")]
        public DateTime Deadline { get; set; }

    }
}
