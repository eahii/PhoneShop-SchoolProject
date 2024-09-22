namespace UsedPhonesShop.Shared
{
    // Tämä luokka edustaa tietokantaan tallennettavaa puhelinmallia
    public class Phone
    {
        // Puhelimen yksilöivä tunniste (Primary Key)
        public int Id { get; set; }

        // Puhelimen merkki, kuten "Apple" tai "Samsung"
        public string Brand { get; set; }

        // Puhelimen malli, kuten "iPhone 12" tai "Galaxy S21"
        public string Model { get; set; }

        // Puhelimen hinta desimaalimuodossa
        public decimal Price { get; set; }

        // Puhelimen kunto, esimerkiksi "Uusi" tai "Käytetty"
        public string Condition { get; set; }
    }
}