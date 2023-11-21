using Microsoft.EntityFrameworkCore;
using Project.Domain.News;
using Project.Persistence.Data;
using Project.Shared.Categories;

namespace Project.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly OogArtsDbContext _context;
        private readonly DbSet<Category> _categories;

        public CategoryService(OogArtsDbContext context)
        {
            _context = context;
            _categories = _context.Categories;
        }
        public async Task<CategoryResponse.GetIndex> GetIndexAsync(CategoryRequest.GetIndex request)
        {
            CategoryResponse.GetIndex response = new();
            var query = _categories.AsQueryable().AsNoTracking();

            response.Categories = await query.Select(x => new CategoryDTO.Index
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return response;
        }
    }
}