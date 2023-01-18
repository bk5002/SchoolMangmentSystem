using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication10.DTO
{
    public class CreateAssignmentDTO
    {
        [Required(ErrorMessage = "Enrollment Id Is Required")]
        public int? EnrollmentId {get;set;}


        [Required(ErrorMessage = "Title Is Required")]
        [MinLength(3, ErrorMessage = "Length Must Be 3 Char AtLeast")]
        [StringLength(100, ErrorMessage = "Title length Can't Be More Than 100")]
        public string Title {get;set;}
        
        [Required(ErrorMessage = "Instruction Is Required")]
        [MinLength(3, ErrorMessage = "Length Must Be 3 Char AtLeast")]
        [StringLength(350, ErrorMessage = "Instruction length Can't Be More Than 350")]
        public string Instruction { get;set;}

        
        [Required(ErrorMessage = "TotalMarks Is Required")]
        [Range(minimum:0,maximum:100)]
        public int TotalMarks { get;set;}

        
        [Required(ErrorMessage = "Deadline Is Required")]
        public DateTime? Deadline { get;set;}
        
    }
}
