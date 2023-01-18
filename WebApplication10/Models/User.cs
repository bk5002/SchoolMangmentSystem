using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10.Models
{
    
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Is Required")]
        [StringLength(maximumLength:50,ErrorMessage = "Please Provide Name Less Than 50 Char")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(maximumLength:50,ErrorMessage = "Please Provide Email Less Than 50 Char")]
        public string Email { get; set; }


        [Required(ErrorMessage ="Password Is Required")]
        //[RegularExpression("/^(?=.*?[A - Z])(?=.*?[a - z])(?=.*?[0 - 9])(?=.*?[#?!@$%^&*-]).{8,}$/", ErrorMessage ="Invalid Password")]
        [MinLength(8, ErrorMessage = "Invalid Password")]
        [StringLength(maximumLength:50,ErrorMessage = "Please Provide Password Less Than 50 Char")]
        public string Password { get; set; }


        [ForeignKey("UserRole")]
        [Column(TypeName = "tinyint")]
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public DateTime EnrolmentDate { get; set; }

        public IEnumerable<StudentEnrollment> StudentEnrollment { get; set; }
        public IEnumerable<TeacherEnrollement> TeacherEnrollement { get; set; }
    }
}

//Has minimum 8 characters in length. Adjust it by modifying {8,}
//At least one uppercase English letter. You can remove this condition by removing (?=.*?[A-Z])
//At least one lowercase English letter.  You can remove this condition by removing (?=.*?[a-z])
//At least one digit. You can remove this condition by removing (?=.*?[0-9])
//At least one special character, You can remove this condition by removing (?=.*?[#?!@$%^&*-])