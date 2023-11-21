namespace Project.Shared.News;

public abstract class NewsRequest
{

    public class GetIndex
    {

        public string? SearchTerm { get; set; }
        public int Page { get; set; } = 0;
        public int Amount { get; set; } = 25;
    }
    public class GetDetail
    {
        public int NewsId { get; set; }
    }
    public class Delete
    {
        public int NewsId { get; set;}
    }
    public class Create
    {
        public NewsDto.Mutate News { get; set; }
    }
    public class Edit
    {
        public int NewsId { get; set; }
        public NewsDto.Mutate News { get; set; }
    }
}
