using Microsoft.AspNetCore.Mvc; // Tarvitaan API-kontrollerin luomiseen, kuten ControllerBase ja IActionResult
using Microsoft.AspNetCore.Identity; // ASP.NET Identity -kirjasto, joka hallitsee käyttäjiä, rooleja ja kirjautumisia
using System.Threading.Tasks; // Tarvitaan asynkronisiin kutsuihin kuten Task<IActionResult>

[ApiController]  // Määrittelee tämän luokan API-kontrolleriksi
[Route("api/[controller]")]  // Asettaa reitityksen URL-mallin "api/Account"
public class AccountController : ControllerBase
{
    // Käyttäjän ja roolien hallinta Identityn kautta
    private readonly UserManager<IdentityUser> _userManager;  
    private readonly SignInManager<IdentityUser> _signInManager;

    // Konstruktori, joka injektoi UserManagerin ja SignInManagerin riippuvuudet
    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // POST-pyyntö rekisteröitymiseen, joka luo uuden käyttäjän
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        // Luo uusi käyttäjä käyttäjän sähköpostin perusteella
        var user = new IdentityUser { UserName = model.Email, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);  // Käyttäjän luonti

        if (result.Succeeded)
        {
            // Jos käyttäjän luonti onnistui, kirjaudu sisään ja palaa OK
            await _signInManager.SignInAsync(user, isPersistent: false);
            return Ok();
        }

        // Palauttaa virheet, jos käyttäjän luonti epäonnistuu
        return BadRequest(result.Errors);
    }

    // POST-pyyntö kirjautumiseen, jossa käytetään käyttäjän sähköpostia ja salasanaa
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        // Yrittää kirjautua sisään käyttäjän antamilla tunnuksilla
        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

        if (result.Succeeded)
        {
            return Ok();  // Kirjautuminen onnistui
        }

        return BadRequest("Invalid login attempt.");  // Kirjautuminen epäonnistui
    }
}

// RegisterModel: Käytetään käyttäjän rekisteröintiin tarvittavat tiedot
public class RegisterModel
{
    public string Email { get; set; }  // Käyttäjän sähköpostiosoite
    public string Password { get; set; }  // Käyttäjän salasana
}

// LoginModel: Käytetään kirjautumisessa tarvittavat tiedot
public class LoginModel
{
    public string Email { get; set; }  // Käyttäjän sähköpostiosoite
    public string Password { get; set; }  // Käyttäjän salasana
}
