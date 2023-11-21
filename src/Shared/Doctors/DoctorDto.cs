using FluentValidation;

namespace Project.Shared.Doctors;

public static class DoctorDTO
{
    public class Index
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Image {  get; set; }

        public string? Specialization { get; set; }
    }

    public class Detail
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Specialization { get; set; }
        public string? Image { get; set; }
    }

    public class Mutate
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Specialization { get; set; }
        public string? Image { get; set; }
        public class Validator : AbstractValidator<Mutate>
        {
            public Validator()
            {
                RuleFor(x => x.FirstName).NotEmpty().MaximumLength(128);
                RuleFor(x => x.LastName).NotEmpty().MaximumLength(128);
                RuleFor(x => x.Specialization).NotEmpty().MaximumLength(128);
                RuleFor(x => x.Image).NotEmpty();
            }
        }
    }
}
