using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared.Companies
{
    public class CompanyDTO
    {
        public class Index
        {
            public string? Name { get; set; }

        }

        public class Detail
        {
            public string? Name { get; set; }
            public string? Adress { get; set; }
            public string? PhoneNumber { get; set; }
            public string? Fax { get; set; }
            public string? Email { get; set; }
        }
        }

    public class Mutate
    {
        public string? Name { get; set; }
        public string? Adress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
    

        public class Validator : AbstractValidator<Mutate>
        {
                public Validator()
                {
                    RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(128);
                    RuleFor(x => x.Adress).NotEmpty().MaximumLength(128);
                    RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(128);
                    RuleFor(x => x.Fax).NotEmpty().MaximumLength(128);
                    RuleFor(x => x.Email).NotEmpty().MaximumLength(128);
                }
            
        }
    }
}

