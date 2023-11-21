using Microsoft.AspNetCore.Mvc;
using Project.Domain.Doctors;
using Project.Shared.Doctors;
using Swashbuckle.AspNetCore.Annotations;

namespace Project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [SwaggerOperation("returns all doctos")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Doctor>))]
        public Task<DoctorResponse.GetIndex> GetIndexAsync([FromQuery] DoctorRequest.GetIndex request)
        {
            return _doctorService.GetIndexAsync(request);
        }
        [SwaggerOperation("returns the doctor with given id")]
        [HttpGet("{DoctorId}")]
        [ProducesResponseType(200, Type = typeof(Doctor))]
        public Task<DoctorResponse.GetDetail> GetDetailAsync([FromRoute] DoctorRequest.GetDetail request)
        {
            return _doctorService.GetDetailAsync(request);
        }

        [SwaggerOperation("deletes the doctor")]
        [HttpDelete]
        public Task DeleteAsync([FromRoute] DoctorRequest.Delete request)
        {
            return _doctorService.DeleteAsync(request);
        }
        [SwaggerOperation("Creates doctor")]
        [HttpPost]
        public Task<DoctorResponse.Create> CreateAsync([FromBody] DoctorRequest.Create request)
        {
            return _doctorService.CreateAsync(request);
        }
        [SwaggerOperation("updates doctor with given id")]
        [HttpPut]
        public Task<DoctorResponse.Edit> EditAsync([FromBody] DoctorRequest.Edit request)
        {
            return _doctorService.EditAsync(request);
        }
    }
}
