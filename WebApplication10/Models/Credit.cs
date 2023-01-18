using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10.Models
{
    public class Credit
    {
        [Key]
        [Column(TypeName = "tinyint")]
        public int Id { get; set; }


        [Column(TypeName = "tinyint")]
        public int CreditHour { get; set; }

    }
}
