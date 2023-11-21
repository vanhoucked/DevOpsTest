using Project.Shared.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared.Companies
{
    public interface ICompanyService
    {
        Task<CompanyResponse.GetDetail> GetDetailAsync();

    }
}
