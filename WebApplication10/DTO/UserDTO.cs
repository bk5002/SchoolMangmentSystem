using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication10.DTO
{
    public class UserDTO
    { 

        [Required(ErrorMessage = "Name Is Required")]
        [MinLength(3,ErrorMessage ="Length Must Be 3 Char AtLeast")]
        [StringLength(maximumLength: 50, ErrorMessage = "Please Provide Name Less Than 50 Char")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password Is Required")]
        [MinLength(8,ErrorMessage ="Invalid Password")]
        //[RegularExpression("/^(?=.*?[A - Z])(?=.*?[a - z])(?=.*?[0 - 9])(?=.*?[#?!@$%^&*-]).{8,}$/", ErrorMessage = "Invalid Password")]
        public string Password { get; set; }


        [ForeignKey("UserRole")]
        [Column(TypeName = "tinyint")]
        public int RoleId { get; set; }

    }
}
