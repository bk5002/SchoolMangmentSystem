using System.ComponentModel.DataAnnotations;



namespace WebApplication10.DTO
{
    public class Parameter
    {
        [Required(ErrorMessage = "Please Provide Id")]
        public int Id { get; set; }
        public int Role { get; set; }
    }
}
