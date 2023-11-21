using Microsoft.EntityFrameworkCore;
using Project.Domain.Company;
using Project.Domain.Conditions;
using Project.Domain.Doctors;
using Project.Domain.News;

namespace Project.Persistence.Data
{
    public class OogArtsDataInitializer
    {
        private readonly OogArtsDbContext dbContext;

        public OogArtsDataInitializer(OogArtsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SeedData()
        {
            dbContext.Database.EnsureDeleted();
            if (dbContext.Database.EnsureCreated())
            {
                SeedNewsArticles();
                SeedConditions();
                SeedCompany();
            }
        }

        private void SeedCompany()
        {
            Company company = new(
                "Test", 
                "Antwerpsesteenweg 1022, 9040 Gent", 
                "0468214155", 
                "0468214155", 
                "Eye.Vision@gmail.com");
            dbContext.Companies.Add(company);
            dbContext.SaveChanges();
        }

        private void SeedConditions()
        {
            var conditions = new List<Condition>()
            {
                new Condition(
                    "Staar",
                    "Een staar is een troebeling van de lens in het oog",
                    "Een staar is een troebeling van de lens in het oog. Dit kan leiden tot wazig zien, vervormd " +
                    "zien en lichtschuwheid. Staar komt vaker voor bij ouderen, maar kan ook bij jongere mensen voorkomen."
                ),

                new Condition
                (
                    "Rode Ogen",
                    "Rode ogen kunnen worden veroorzaakt door een verscheidenheid aan factoren",
                    "Rode ogen kunnen worden veroorzaakt door een verscheidenheid aan factoren, waaronder vermoeidheid, " +
                    "allergieën, infecties en oogirritatie. In de meeste gevallen zijn rode ogen onschadelijk en " +
                    "verdwijnen ze vanzelf"
                ),
                new Condition
                (
                    "Glaucoom",
                    "Glaucoom is een oogaandoening die het gezichtsvermogen kan beschadigen.",
                    "Glaucoom is een oogaandoening die het gezichtsvermogen kan beschadigen. " +
                    "Glaucoom wordt veroorzaakt door een verhoogde druk in het oog. Dit kan de zenuwen in het oog " +
                    "beschadigen, wat kan leiden tot blindheid."
                ),
                new Condition
                (
                    "Maculare degeneratie",
                    "Maculare degeneratie is een oogaandoering die het centrale deel.",
                    "Maculare degeneratie is een oogaandoering die het centrale deel van het netvlies, " +
                    "de macula, aantast. Dit kan leiden tot wazig zien, vervormd zien en " +
                    "moeite met lezen en autorijden."
                ),
            };
            dbContext.Conditions.AddRange(conditions);
            dbContext.SaveChanges();
        }

        private void SeedNewsArticles()
        {
            Doctor doctor = new("Ozlem", "Kose", "", "Oogarts - OogChirurg");
            Doctor doctor2 = new("Eline", "De Pauw", "", "Optometrist, technisch oogheelkundige assistent");
            Doctor doctor3 = new("Diete", "Paternoster", "", "Orthoptist");

            Category category = new("Informatie");
            Category category2 = new("Aandoeningen");

            string image = "https://picsum.photos/350/200";

            var news = new List<NewsArticle>()
            {
                new NewsArticle(
                    "Nieuw geneesmiddel ontdekt voor Staar",
                    "Onderzoekers hebben onlangs een doorbraak gemaakt in de behandeling van staar. " +
                    "Een nieuw geneesmiddel is ontdekt dat de troebeling van de lens in het oog effectief kan verminderen.",
                    image,
                    doctor,
                    category
                ),
                new NewsArticle
                (
                    "Rode Ogen",
                    "Rode ogen kunnen verschillende oorzaken hebben, van allergieën tot oogirritatie. In dit " +
                    "artikel bespreken we de mogelijke oorzaken en behandelingsopties voor rode ogen.",
                    image,
                    doctor2,
                    category
                ),
                new NewsArticle
                (
                    "Preventie en behandeling van Glaucoom",
                    "Glaucoom is een ernstige oogaandoening die het gezichtsvermogen kan bedreigen. " +
                    "Lees meer over de preventie en behandeling van glaucoom in dit informatieve artikel.",
                    image,
                    doctor3,
                    category
                ),
                new NewsArticle
                (
                    "Nieuwe hoop voor Retinoblastoma-patiënten",
                    "Voor kinderen die lijden aan retinoblastoma is er nieuwe hoop. Recente " +
                    "ontwikkelingen in de behandeling beloven betere overlevingskansen en een verbeterde kwaliteit van leven.",
                    image,
                    doctor,
                    category
                ),
                new NewsArticle
                (
                    "Leven met Maculare degeneratie: Tips en advies",
                    "Maculare degeneratie kan het dagelijks leven beïnvloeden. " +
                    "Dit artikel biedt nuttige tips en advies voor mensen die met deze aandoening leven.",
                    image,
                    doctor2,
                    category
                ),
                new NewsArticle
                (
                    "Nieuwe behandelingsopties voor Diabetische Retinopathie",
                    "Diabetische retinopathie is een oogcomplicatie bij diabetespatiënten." +
                    " Ontdek de nieuwste behandelingsopties en hoop voor mensen die hiermee te maken hebben.",
                    image,
                    doctor3,
                    category2
                ),
                new NewsArticle
                (
                    "Oogzorgtips voor de zomermaanden",
                    "De zomer kan uitdagend zijn voor ooggezondheid. Leer hoe je je ogen beschermt " +
                    "tegen de zon en andere zomerse risico's.",
                    image,
                    doctor,
                    category2
                ),
                new NewsArticle
                (
                    "Nieuwe inzichten in Droge Ogen Syndroom",
                    "Droge ogen kunnen hinderlijk zijn. Ontdek de nieuwste inzichten en " +
                    "behandelingen voor dit veelvoorkomende oogprobleem.",
                    image,
                    doctor2,
                    category2
                )
            };

            dbContext.News.AddRange(news);
            dbContext.SaveChanges();
        }
    }
}