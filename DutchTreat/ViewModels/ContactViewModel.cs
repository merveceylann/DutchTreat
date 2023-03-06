using System.ComponentModel.DataAnnotations;

namespace DutchTreat.ViewModels
{
    public class ContactViewModel
    {
        //burada bu data annotationslari ekledik fakat submit etmeden once hata mesaji verse kullanici deneyimi acisindan daha iyi olacagi icin viewde validation summaryde modelonly secegini kullandik ve spanler ile validation ekledik.
        [Required]
        [MinLength(2, ErrorMessage = "Too Short")]
        [MaxLength(50)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
