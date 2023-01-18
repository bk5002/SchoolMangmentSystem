using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10.Models
{
    public class Role
    {
        [Key]
        [Column(TypeName ="tinyint")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Please Enter User Role")]
        [StringLength(maximumLength: 100, ErrorMessage = "Please Provide Role Less Than 100 Char")]
        public string UserRole { get; set; }
    }
}
