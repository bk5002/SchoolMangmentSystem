using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication10.Models;

namespace WebApplication10.DTO
{
    public class UserListDTO
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        public string Role  { get; set; }
        public DateTime? EnrolmentDate { get; set; }
    }
}
