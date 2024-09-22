using Microsoft.AspNetCore.Identity;  // Identity-käyttäjien hallintaan
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;  // Entity Framework Core -integraatio Identityä varten
using Microsoft.EntityFrameworkCore;  // Entity Framework Core -tietokantakonteksti
using UsedPhonesShop.Shared;  // Viitataan jaettuun luokkaan "Phone"

namespace UsedPhonesShopAPI.Data
{
    // Sovelluksen tietokantakonteksti, joka laajentaa IdentityDbContextiä.
    // IdentityDbContext tarjoaa valmiit taulut käyttäjille ja rooleille
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        // Konstruktori, joka perii perustiedot käytettävästä tietokantayhteydestä
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet määrittelee entiteetin "Phone", joka luodaan tietokantaan taulukoksi.
        // Tämä tallentaa puhelinten tiedot.
        public DbSet<Phone> Phones { get; set; }
    }
}