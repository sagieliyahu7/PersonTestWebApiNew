using PersonTestWebApi.Utils;
using System.ComponentModel.DataAnnotations;

namespace PersonTestWebApi.Models
{
    public class Person
    {
        [RegularExpression("^[A-Za-z\u0590-\u05fe ]+$")]
        [MaxLength(20)]
        [Required]
        public string FullName { get; set; }
        [NotFutureDateValidation]
        [Required]
        public DateTime? BirthDate { get; set; }
        [IsraeliIdValidation]
        [Required]
        public int? IdNum { get; set; }
    }
}
