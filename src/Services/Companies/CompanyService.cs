using Microsoft.EntityFrameworkCore;
using Project.Shared.Companies;
using Project.Shared.Conditions;
using Project.Domain.Company;
using Project.Persistence.Data;

namespace Project.Services.Companies
{
    public class CompanyService : ICompanyService
    {

        private readonly OogArtsDbContext _context;
        private readonly DbSet<Company> _company;

        public CompanyService(OogArtsDbContext dataContext)
        {
            _context = dataContext;
            _company = _context.Companies;
        }



        public async Task<CompanyResponse.GetDetail> GetDetailAsync()
        {
            CompanyResponse.GetDetail response = new();
            response.Company = await _company
                .Select(x => new CompanyDTO.Detail
                {
                    Name = x.Name,
                    Adress = x.Adress,
                    PhoneNumber = x.PhoneNumber,
                    Fax = x.Fax,
                    Email = x.Email,

                }).SingleOrDefaultAsync();
            return response;
        }
    }
}
