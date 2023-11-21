using Project.Domain.News;

namespace Project.Domain.Doctors;

public class Doctor : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Specialization { get; set; }
    public string Image { get; set; }
    public List<NewsArticle> NewsArticles { get; set; }

    public Doctor() { }
    public Doctor(string? firstName, string? lastName, string? specialization, string? image)
    {
        FirstName = firstName;
        LastName = lastName;
        Specialization = specialization;
        Image = image;
    }
}
