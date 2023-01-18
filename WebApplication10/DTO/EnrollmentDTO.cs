using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication10.Models;

namespace WebApplication10.DTO
{
    public class EnrollmentDTO
    {
        public int UserId { get; set; }

        public int CourseId { get; set; }
    }
}
