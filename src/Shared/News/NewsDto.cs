using FluentValidation;
using Project.Shared.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Shared.News;

public static class NewsDto
{

    public class Index
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public DoctorDTO.Index? Author { get; set; }
        public string? DatePosted { get; set; }
    }
    public class Detail
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? NewsText { get; set; }
        public string? Image { get; set; }
        public DoctorDTO.Detail? Author { get; set; }
        public string Category { get; set; }
        public string? DatePosted { get; set; }
    }

    public class Mutate
    {
        public string? Title { get; set; }
        public string? NewsText { get; set; }
        public string? Image { get; set; }
        public string Category { get; set; }

        public class Validator : AbstractValidator<Mutate>
        {
            public Validator()
            {
                RuleFor(x => x.Title).NotEmpty().MaximumLength(128);
                RuleFor(x => x.NewsText).NotEmpty().MaximumLength(2048);
                RuleFor(x => x.Image).NotEmpty();
                RuleFor(x => x.Category).NotEmpty();
            }
        }
    }
}
