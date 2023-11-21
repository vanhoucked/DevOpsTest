using Microsoft.EntityFrameworkCore;
using Project.Domain.Doctors;
using Project.Shared.News;
using Project.Shared.Doctors;
using Project.Persistence.Data;
using Project.Domain.News;

namespace Project.Services.News
{
    public class NewsService : INewsService
    {
        private readonly OogArtsDbContext _context;
        private readonly DbSet<NewsArticle> _news;
        private readonly DbSet<Doctor> _doctors;
        private readonly DbSet<Category> _categories;

        public NewsService(OogArtsDbContext dataContext)
        {
            _context = dataContext;
            _news = dataContext.News;
            _doctors = dataContext.Doctors;
            _categories = dataContext.Categories;
        }
        private IQueryable<NewsArticle> GetNewsById(int id)
        {
            return _news.AsNoTracking().Where(x => x.Id == id);
        }

        public async Task<NewsResponse.Create> CreateAsync(NewsRequest.Create request)
        {
            NewsResponse.Create response = new();
            var categoryName = "Information";
            var doctor = _doctors.Where(d => d.Id == 1).FirstOrDefault();
            var category = _categories.Where(c => c.Name.ToLower().Equals(categoryName.ToLower())).FirstOrDefault();
            if (doctor is not null)
            {
                var news = new NewsArticle(request.News.Title, request.News.NewsText,
                    request.News.Image, doctor, category);
                _news.Add(news);

                await _context.SaveChangesAsync();
                response.NewsId = news.Id;
                return response;
            }
            throw new Exception("Doctor not found");
        }

        public async Task DeleteAsync(NewsRequest.Delete request)
        {
            var News = await _news.SingleAsync(n => n.Id == request.NewsId);
            _news.Remove(News);
            _context.SaveChanges();
        }

        public async Task<NewsResponse.Edit> EditAsync(NewsRequest.Edit request)
        {
            NewsResponse.Edit response = new();
            var news = await GetNewsById(request.NewsId).SingleOrDefaultAsync();
            if (news is not null)
            {
                var doctor = _doctors.Where(d => d.Id == 1).FirstOrDefault();
                var model = request.News;
                news.Title = model.Title ?? news.Title;
                news.NewsText = model.NewsText ?? news.NewsText;
                news.Image = model.Image ?? news.Image;
                news.Author = doctor ?? news.Author;

                _context.Entry(news).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                response.NewsId = news.Id;
            }
            return response;
        }

        public async Task<NewsResponse.GetDetail> GetDetailAsync(NewsRequest.GetDetail request)
        {
            NewsResponse.GetDetail response = new();

            var news = await GetNewsById(request.NewsId)
                .Include(n => n.Author)
                .Include(n => n.Category)
                .SingleOrDefaultAsync();

            if (news is not null)
            {
                response.News = new NewsDto.Detail
                {
                    Id = news.Id,
                    Title = news.Title,
                    NewsText = news.NewsText,
                    Image = news.Image,
                    Author = news.Author is not null
                        ? new DoctorDTO.Detail
                        {
                            FirstName = news.Author.FirstName,
                            LastName = news.Author.LastName,
                            Specialization = news.Author.Specialization,
                            Image = news.Author.Image
                        }
                        : null, // Handle the case when Author is null
                    Category = news.Category.Name,
                    DatePosted = news.CreatedAt.ToString("dd/MM/yyyy")
                };
                return response;
            }
            throw new Exception("News not found");
        }


        public async Task<NewsResponse.GetIndex> GetIndexAsync(NewsRequest.GetIndex request)
        {
            var response = new NewsResponse.GetIndex();
            var query = _context.News
                .Include(news => news.Author) // Include the related Doctor entity
                .Include(news => news.Category)
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(news => news.Title.Contains(request.SearchTerm));
            }

            query = query.Skip(request.Amount * request.Page)
                         .Take(request.Amount)
                         .OrderBy(news => news.Title);

            var newsList = await query.Select(news => new NewsDto.Index
            {
                Id = news.Id,
                Title = news.Title,
                Image = news.Image,
                Author = new DoctorDTO.Index
                {
                    Id = news.Author.Id,
                    FirstName = news.Author.FirstName,
                    LastName = news.Author.LastName
                },
                DatePosted = news.CreatedAt.ToString("dd/MM/yyyy")
            }).ToListAsync();

            response.News = newsList;
            return response;
        }
    }
}
