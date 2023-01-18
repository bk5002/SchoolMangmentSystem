using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10.Models
{
    public class Assigned
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int StudentId { get; set; }
        public User Student { get; set; }

        [ForeignKey("Assignment")]
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }


        [StringLength(250, ErrorMessage = "FileUrl length Can't Be More Than 250")]
        public string? FileUrl { get; set; }

        [StringLength(350, ErrorMessage = "Comment OR Answer length Can't Be More Than 350")]
        public string? CommentOrAnswer { get; set; }

        [Column(TypeName = "tinyint")]
        public int? ObtainMarks { get; set; }

        [StringLength(350, ErrorMessage = "Remarks length Can't Be More Than 350")]
        public string? Remarks { get; set; }
       
        public DateTime? SubmitDate { get; set; }
    }
}
