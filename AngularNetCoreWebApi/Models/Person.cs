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
        [RegularExpression("^[0-9]+$")]
        [Required]
        public string IdNum { get; set; } // it's for saving leading zero
    }
}
