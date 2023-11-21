namespace Project.Shared.News;

public static class NewsResponse
{
    public class GetIndex
    {
        public List<NewsDto.Index> News { get; set; } = new();
    }
    public class GetDetail
    {
        public NewsDto.Detail News { get; set; } = new();
    }
    public class Delete 
    { 
    
    }
    public class Create
    {
        public int NewsId { get; set; }
        public string UploadUri { get; set; } = default!;
    }
    public class Edit
    {
        public int NewsId { get; set; }
    }


}
