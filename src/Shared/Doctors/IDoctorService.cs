namespace Project.Shared.Doctors
{
    public interface IDoctorService
    {
        Task<DoctorResponse.GetIndex> GetIndexAsync(DoctorRequest.GetIndex request);
        Task<DoctorResponse.GetDetail> GetDetailAsync(DoctorRequest.GetDetail request);

        Task DeleteAsync(DoctorRequest.Delete request);

        Task<DoctorResponse.Create> CreateAsync(DoctorRequest.Create request);

        Task<DoctorResponse.Edit> EditAsync(DoctorRequest.Edit request);
    }
}
