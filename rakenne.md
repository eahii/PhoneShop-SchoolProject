# Projektin Rakenne: UsedPhonesShop

Tässä dokumentissa esitellään projektin kansiorakenne ja selitetään, mitä tapahtuu kussakin osiossa. Tämä auttaa tiimin jäseniä ymmärtämään projektin kokonaisuutta ja eri osien tehtäviä.

## UsedPhonesShop-Blazor.sln
- **Ratkaisun tiedosto**, joka kokoaa yhteen projektin kaikki osat. Tämä tiedosto mahdollistaa koko projektin hallinnan Visual Studio -ympäristössä.

## UsedPhonesShop.Shared
Tämä kansio sisältää yhteisiä malleja ja logiikkaa, joita käytetään sekä asiakas- että palvelinpuolella.

- **LoginModel.cs**: Tietomalli, joka sisältää käyttäjän kirjautumistiedot (sähköpostin ja salasanan).
- **Phone.cs**: Tietomalli, joka edustaa käytettyjen puhelinten tietoja (merkki, malli, hinta).
- **RegisterModel.cs**: Tietomalli, joka sisältää käyttäjän rekisteröintitiedot (sähköposti ja salasana).

## UsedPhonesShopAPI
Tämä on projektin palvelinpuoli, joka käsittelee API-pyynnöt ja tietokantaoperaatiot.

### Controllers
- **AccountController.cs**: Käsittelee käyttäjän rekisteröinti- ja kirjautumistoimintoja. API-pyyntöjen käsittely tapahtuu täällä.

### Data
- **ApplicationDbContext.cs**: Määrittelee tietokannan yhteydet ja sisältää taulut, kuten käyttäjätiedot ja puhelintiedot.

### Migrations
Tämä kansio sisältää tietokannan migraatiotiedostot, jotka hallinnoivat tietokantarakenteen muutoksia.

### appsettings.json & appsettings.Development.json
Sisältävät sovelluksen konfiguraatiot, kuten tietokantayhteyden ja kehitysympäristön asetukset.

### Program.cs
Tämä tiedosto sisältää ohjelman käynnistyslogiikan ja palveluiden konfiguraation, kuten Swagger-dokumentoinnin ja käyttäjänhallinnan.

## UsedPhonesShopWasm
Tämä on Blazor WebAssembly -sovelluksen asiakaspuoli, joka toimii käyttöliittymänä.

### Layout
- **MainLayout.razor**: Pääasiallinen ulkoasukomponentti, joka määrittää sivun rakenteen.
- **NavMenu.razor**: Navigointivalikko, jonka avulla käyttäjä voi siirtyä eri sivujen välillä.

### Pages
- **Home.razor**: Etusivun komponentti, joka näyttää ensimmäisen näkymän, jonka käyttäjä näkee.
- **Login.razor**: Komponentti, joka käsittelee käyttäjän kirjautumisen ja lähettää kirjautumistiedot API:lle.

### wwwroot
Sisältää staattiset tiedostot, kuten kuvat, tyylitiedostot ja JavaScript-tiedostot.

### Program.cs
Tämä tiedosto sisältää Blazor WebAssembly -sovelluksen käynnistyslogiikan, ja se määrittelee sovelluksen komponentit ja palvelut.

## Yhteenveto
- **UsedPhonesShop.Shared**: Jaettuja malleja ja logiikkaa sekä asiakas- että palvelinpuolelle.
- **UsedPhonesShopAPI**: Palvelinpuoli, joka hallinnoi API-pyynnöt ja tietokantaoperaatiot.
- **UsedPhonesShopWasm**: Blazor WebAssembly -asiakaspuoli, joka toimii käyttöliittymänä ja kommunikoi API:n kanssa.

Tämä rakenne selkeyttää käyttöliittymän, palvelimen ja tietokantamallien välistä kommunikaatiota.
