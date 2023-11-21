using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project.Domain.Email
{
    public class Contact
    {
        [JsonPropertyName("name")]
        public string Voornaam { get; set; }

        [JsonPropertyName("name")]
        public string Naam { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
