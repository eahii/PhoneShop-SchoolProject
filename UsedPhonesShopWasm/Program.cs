using Microsoft.AspNetCore.Components.Web; // Importoidaan Blazorin komponentteja käyttöliittymän luomiseen
using Microsoft.AspNetCore.Components.WebAssembly.Hosting; // Importoidaan Blazorin WebAssembly-hosting-palvelut
using UsedPhonesShopWasm; // Käytetään ohjelman omaa namespacea

// Luodaan oletus WebAssemblyHostBuilder, joka hoitaa Blazor-sovelluksen pystytyksen
var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Lisätään sovelluksen pääkomponentti (App) DOM-puuhun "#app"-elementin sisään index.html:ssä
builder.RootComponents.Add<App>("#app");

// Lisätään HeadOutlet-komponentti, joka mahdollistaa dynaamisen head-elementin hallinnan sivulla, kuten otsikot ja metatiedot
builder.RootComponents.Add<HeadOutlet>("head::after");

// Määritetään HTTP-asiakaspalvelu (HttpClient), joka käytetään API-kutsuihin.
// Aikaisempi oletusasetus oli käyttää sovelluksen host-ympäristön osoitetta, mutta se on nyt kovakoodattu viittaamaan paikalliseen API-osoitteeseen (localhost:5218).
// Tämä mahdollistaa viestinnän API:n kanssa (UsedPhonesShopAPI).
// Osoite http://localhost:5218/ viittaa paikalliseen kehitysympäristöön, jossa API on käynnissä.
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5218/") });

// Luodaan ja käynnistetään WebAssembly-isäntä
await builder.Build().RunAsync();