using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using UsedPhonesShopAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Palveluiden lisääminen konttiin:
// Swaggerin käyttöönotto API-dokumentaatiota varten
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Swagger-dokumentin määritys API:n nimellä ja versiolla
    c.SwaggerDoc("v1", new() { Title = "UsedPhonesShopAPI", Version = "v1" });
});

// Identity-palveluiden konfigurointi käyttäjien hallintaa ja autentikointia varten
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    // Käytetään Entity Frameworkin SQLite-tietokantaa käyttäjätilien tallentamiseen
    .AddEntityFrameworkStores<ApplicationDbContext>()
    // Token-palveluiden oletusarvoinen konfiguraatio, esimerkiksi salasanan resetointi
    .AddDefaultTokenProviders();

// Authorization-palveluiden lisääminen
builder.Services.AddAuthorization();

// Tietokantakontekstin määrittäminen käyttämään SQLite-tietokantaa
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Lisätään kontrolleripalvelut ja määritetään JSON:n sarjallistaminen (poistetaan oletusnimi-käytäntö)
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

var app = builder.Build();

// HTTP-pyyntöjen käsittelyn määrittäminen:
if (app.Environment.IsDevelopment())
{
    // Swaggerin käyttöönotto kehitysympäristössä
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();  // Reititys tulee suorittaa ennen autentikointia ja autorisointia

app.UseAuthentication();  // Otetaan käyttöön autentikointi (kirjautuminen)
app.UseAuthorization();   // Otetaan käyttöön autorisointi (pääsynvalvonta)

// Määritetään, että kontrollerit hoitavat tietyn URL-osoitteen mukaiset pyynnöt
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHttpsRedirection();  // HTTPS:n pakottaminen suojatun liikenteen varmistamiseksi

app.Run();  // Käynnistetään sovellus