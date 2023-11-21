namespace Project.Domain.Company
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }

        public Company() { }

        public Company(string? name, string? adress, string? phoneNumber, string? fax, string? email) 
        {
            this.Name = name;
            this.Adress = adress;
            this.PhoneNumber = phoneNumber;
            this.Fax = fax;
            this.Email = email;
        }
    }
}
