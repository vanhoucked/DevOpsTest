using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared.News
{
    public interface INewsService
    {
        Task<NewsResponse.GetIndex> GetIndexAsync(NewsRequest.GetIndex request);

        Task<NewsResponse.GetDetail> GetDetailAsync(NewsRequest.GetDetail request);

        Task DeleteAsync(NewsRequest.Delete request);

        Task<NewsResponse.Create> CreateAsync(NewsRequest.Create request);

        Task<NewsResponse.Edit> EditAsync(NewsRequest.Edit request);
        
    }
}
