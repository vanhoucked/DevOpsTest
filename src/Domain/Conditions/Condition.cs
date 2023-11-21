namespace Project.Domain.Conditions;

public class Condition : Entity
{


    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    //public IList<News> NewsArticles { get; set; }

    public Condition() { }

    public Condition(string? name, string? shortDescription, string? longDescription)
    {
        Name = name;
        ShortDescription = shortDescription;
        LongDescription = longDescription;
    }
}
