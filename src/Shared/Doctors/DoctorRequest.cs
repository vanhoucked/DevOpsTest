namespace Project.Shared.Doctors
{ 
    public class DoctorRequest
    {
        public class GetIndex
        {
            public string? SearchTerm { get; set; }
            public int Page { get; set; }
            public int Amount { get; set; } = 25;
        }
        public class GetDetail
        {
            public int DoctorId { get; set; }
        }
        public class Delete
        {
            public int DoctorId { get; set; }

        }
        public class Create
        {
            public DoctorDTO.Mutate Doctor { get; set; }
        }
        public class Edit
        {
            public int DoctorId { get; set; }
            public DoctorDTO.Mutate Doctor { get; set; }

        }
    }
}