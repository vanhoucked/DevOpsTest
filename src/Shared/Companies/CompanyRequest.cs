using Project.Shared.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared.Companies
{
    public abstract class CompanyRequest
    {
        public class GetIndex
        {
            public string? Name { get; set; }
        }
        public class GetDetail
        {
            public string? Name { get; set; }
        }
    }
}
