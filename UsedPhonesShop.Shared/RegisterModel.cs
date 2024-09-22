using System.ComponentModel.DataAnnotations;  // Tarvitaan validointia varten, kuten [Required] ja [EmailAddress] attribuutit

namespace UsedPhonesShop.Shared
{
    // Tämä malli sisältää käyttäjän rekisteröintiin tarvittavat tiedot
    public class RegisterModel
    {
        // Sähköpostin on oltava täytetty (Required) ja sen on oltava validi sähköpostiosoite (EmailAddress)
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Salasanan on oltava täytetty (Required) ja vähintään 6 merkkiä pitkä (MinLength)
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}