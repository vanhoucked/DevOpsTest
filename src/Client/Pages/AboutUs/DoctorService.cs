using Project.Client.Extensions;
using Project.Client.Infrastructure;
using Project.Shared.Doctors;
using System.Net.Http.Json;

namespace Project.Client.Pages.AboutUs
{
    public class DoctorService : IDoctorService
    {

        private readonly PublicClient publicClient;
        private const string endpoint = "/api/Doctor";

        public DoctorService(PublicClient client)
        {
            publicClient = client;
        }

        public async Task<DoctorResponse.GetIndex> GetIndexAsync(DoctorRequest.GetIndex request)
        {
            var queryParameters = request.GetQueryString();
            var response = await publicClient.Client.GetFromJsonAsync<DoctorResponse.GetIndex>($"{endpoint}?{queryParameters}");
            return response;
        }

        public Task<DoctorResponse.Create> CreateAsync(DoctorRequest.Create request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(DoctorRequest.Delete request)
        {
            throw new NotImplementedException();
        }

        public Task<DoctorResponse.Edit> EditAsync(DoctorRequest.Edit request)
        {
            throw new NotImplementedException();
        }

        public async Task<DoctorResponse.GetDetail> GetDetailAsync(DoctorRequest.GetDetail request)
        {
            var response = await publicClient.Client.GetFromJsonAsync<DoctorResponse.GetDetail>($"{endpoint}/{request.DoctorId}");
            return response;
        }


    }
}
