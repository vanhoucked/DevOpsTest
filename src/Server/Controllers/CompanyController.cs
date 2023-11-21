using Microsoft.AspNetCore.Mvc;
using Project.Domain.Company;
using Project.Services.Conditions;
using Project.Shared.Companies;
using Project.Shared.Conditions;
//using Swashbuckle.AspNetCore.Annotations;

namespace Project.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        //[SwaggerOperation("Returns the company info")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Company>))]
        public Task<CompanyResponse.GetDetail> GetCompany()
        {
            return _companyService.GetDetailAsync();
        }

    }
}
