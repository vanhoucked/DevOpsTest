namespace Project.Domain.News
{
    public class Category : Entity
    {
        private string name = default!;
        public string Name
        {
            get => name;
            set => name = Guard.Against.NullOrWhiteSpace(value, nameof(Name));
        }
        public List<NewsArticle> NewsArticles { get; set; }

        private Category() { }
        public Category(string name)
        {
            Name = name;
        }
    }
}
