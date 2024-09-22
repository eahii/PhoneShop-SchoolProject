using System.ComponentModel.DataAnnotations;

namespace UsedPhonesShop.Shared
{
    // Tämä malli edustaa käyttäjän kirjautumistietoja
    public class LoginModel
    {
        // Pakollinen kenttä, joka tarkistaa, että käyttäjän syöttämä sähköposti on kelvollinen
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Pakollinen kenttä, joka vaatii vähintään 6 merkin pituisen salasanan
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}

// Phone-luokka on yksinkertainen malli, joka sisältää perustiedot puhelimesta.
// Näitä tietoja käytetään verkkokaupan tuotteiden esittämiseen sekä tallentamiseen tietokantaan.