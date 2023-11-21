using Project.Domain.Doctors;

namespace Project.Domain.News;

public class NewsArticle : Entity
{
    private string title = default!;
    public string Title
    {
        get => title;
        set => title = Guard.Against.NullOrWhiteSpace(value, nameof(Title));
    }
    private string newsText = default!;
    public string NewsText
    {
        get => newsText;
        set => newsText = Guard.Against.NullOrWhiteSpace(value, nameof(NewsText));
    }
    private string image = default!;
    public string Image
    {
        get => image;
        set => image = Guard.Against.NullOrWhiteSpace(value, nameof(Image));
    }
    public Doctor Author { get; set; } = default!;
    public Category Category { get; set; } = default!;

    public NewsArticle() { }

    public NewsArticle(string title, string newsText, string image, Doctor author, Category category)
    {
        Title = title;
        NewsText = newsText;
        Image = image;
        Author = Guard.Against.Null(author, nameof(Author));
        Category = Guard.Against.Null(category, nameof(Category));
    }
}
