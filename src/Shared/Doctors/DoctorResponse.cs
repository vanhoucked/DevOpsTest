namespace Project.Shared.Doctors;

public class DoctorResponse
{
    public class GetIndex
    {
        public List<DoctorDTO.Index> Doctors { get; set; } = new();
    }
    public class GetDetail
    {
        public DoctorDTO.Detail Doctor { get; set; } = new();
    }
    public class Delete
    {

    }
    public class Create
    {
        public int DoctorId { get; set; }
    }
    public class Edit
    {
        public int DoctorId { get; set; }
    }
}
