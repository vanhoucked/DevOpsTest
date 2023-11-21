using Project.Shared.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared.Companies
{
    public abstract class CompanyResponse
    {
        public class GetIndex
        {
            public List<CompanyDTO.Index> Company { get; set; } = new();
        }
        public class GetDetail
        {
            public CompanyDTO.Detail Company { get; set; } = new();
        }

    }
}
