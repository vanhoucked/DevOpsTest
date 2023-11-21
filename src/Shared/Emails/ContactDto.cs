using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project.Shared.Emails
{
    public static class ContactDto
    {
        public class Index
        {
            public string? Voornaam { get; set; }

            public string? Naam { get; set; }

            public string? Email { get; set; }

            public string? Message { get; set; }
        }

        public class Detail
        {
            public string? Voornaam { get; set; }

            public string? Naam { get; set; }

            public string? Email { get; set; }

            public string? Message { get; set; }
        }

    }
}
