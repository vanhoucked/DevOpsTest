using Microsoft.AspNetCore.Mvc;
using Project.Domain.Conditions;
using Project.Shared.Conditions;
//using Swashbuckle.AspNetCore.Annotations;

namespace Project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConditionController : Controller
    {
        private readonly IConditionService _conditionService;

        public ConditionController(IConditionService conditionService)
        {
            _conditionService = conditionService;
        }

        //[SwaggerOperation("Returns the conditions")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Condition>))]
        public Task<ConditionResponse.GetIndex> GetIndexAsync([FromQuery] ConditionRequest.GetIndex request) {
           
            return _conditionService.GetIndexAsync(request);
        }


        //[SwaggerOperation("Returns a condition with given id")]
        [HttpGet("{id}")]
        public Task<ConditionResponse.GetDetail> GetDetailAsync([FromRoute] ConditionRequest.GetDetail request)
        {
            return _conditionService.GetDetailAsync(request);
        }


        //[SwaggerOperation("delete condition with given id")]
        [HttpDelete("{id}")]
        public Task DeleteAsync([FromRoute] ConditionRequest.Delete request)
        {
            return _conditionService.DeleteAsync(request);
        }

        //[SwaggerOperation("Creates a new condition")]
        [HttpPost]
        public  Task<ConditionResponse.Create> CreateAsync([FromBody] ConditionRequest.Create request)
        {
            return  _conditionService.CreateAsync(request);
        }

        //[SwaggerOperation("Updates condition with given id")]
        [HttpPut]
        public  Task<ConditionResponse.Edit> EditAsync([FromBody] ConditionRequest.Edit request)
        {
            return _conditionService.EditAsync(request);
        }
    }
}
