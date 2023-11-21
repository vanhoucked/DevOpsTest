using FluentValidation;

namespace Project.Shared.Conditions
{
    public class ConditionDTO
    {
        public class Index
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? ShortDescription { get; set; }
        }

        public class Detail
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? ShortDescription { get; set; }
            public string? LongDescription { get; set; }
        }

        public class Mutate
        {
            public string? Name { get; set; }
            public string? ShortDescription { get; set; }
            public string? LongDescription { get; set; }
            public List<string> Photos { get; set; }
            public List<string> Symptoms { get; set; }

            public class Validator : AbstractValidator<Mutate>
            {
                public Validator()
                {
                    RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(128);
                    RuleFor(x => x.ShortDescription).NotEmpty().MaximumLength(128);
                    RuleFor(x => x.LongDescription).NotEmpty().MaximumLength(2048);
                }
            }
        }
    }
}
