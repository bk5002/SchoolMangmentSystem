using System.ComponentModel.DataAnnotations;

namespace WebApplication10.DTO
{
    public class SubmitAssignmentDTO
    {
        [Required(ErrorMessage = "Enrollment Id Is Required")]
        public int? AssignedId { get; set; }

        [Required(ErrorMessage = "Instruction Is Required")]
        [StringLength(350, ErrorMessage = "Instruction length Can't Be More Than 350")]
        public string CommentORAnswer { get; set; }

    }

}
