using Microsoft.AspNetCore.Mvc;
using Project.Domain.News;
//using Project.Client.News.Components;
using Project.Shared.News;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        // GET: api/<NewsController>
        [SwaggerOperation("returns all news objects")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NewsArticle>))]
        public  Task<NewsResponse.GetIndex> GetIndexAsync([FromQuery] NewsRequest.GetIndex request)
        {
            return _newsService.GetIndexAsync(request);
        }
        [SwaggerOperation("returns news with given id")]
        [HttpGet("{newsId}")]
        public Task<NewsResponse.GetDetail> GetDetailAsync([FromRoute] int newsId)
        {
            var request = new NewsRequest.GetDetail { NewsId = newsId };
            return _newsService.GetDetailAsync(request);
        }
        [HttpDelete("{newsId}")]
        public Task DeleteAsync([FromRoute] int newsId)
        {
            var request = new NewsRequest.Delete { NewsId = newsId };
            return _newsService.DeleteAsync(request);
        }

        [SwaggerOperation("creates news object")]
        [HttpPost]
        public Task<NewsResponse.Create> CreateAsync([FromBody] NewsRequest.Create request)
        {
            return _newsService.CreateAsync(request);
        }
        [SwaggerOperation("updates news object")]
        [HttpPut]
        public Task<NewsResponse.Edit> EditAsync([FromBody] NewsRequest.Edit request)
        {
            return _newsService.EditAsync(request);
        }
    }
}
