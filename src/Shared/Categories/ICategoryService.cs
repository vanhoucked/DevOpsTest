namespace Project.Shared.Categories
{
    public interface ICategoryService
    {
        Task<CategoryResponse.GetIndex> GetIndexAsync(CategoryRequest.GetIndex request);
    }
}
