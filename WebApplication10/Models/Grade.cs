using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10.Models
{
    public class Grade
    {
        [Key]
        [Column(TypeName ="tinyint")]
        public int Id { get; set; }


        [Column(TypeName = "tinyint")]
        public int Min { get; set; }


        [Column(TypeName = "tinyint")]
        public int Max { get; set; }


      
        [StringLength(2)]
        public string GradeValue { get; set; }


        [Column(TypeName ="smallmoney")]
        public int GPA { get; set; }
    }
}
