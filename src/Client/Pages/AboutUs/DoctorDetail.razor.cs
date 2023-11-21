using Microsoft.AspNetCore.Components;
using Project.Shared.Doctors;

namespace Project.Client.Pages.AboutUs
{
    public partial class DoctorDetail
    {
        [Inject] public IDoctorService DoctorService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        [Parameter] public int Id { get; set; }

        private DoctorDTO.Detail Doctor;

        protected override async Task OnParametersSetAsync()
        {
            await GetDoctorAsync();
        }

        private async Task GetDoctorAsync()
        {
            DoctorRequest.GetDetail request_detail = new() { DoctorId = Id };
            var response = await DoctorService.GetDetailAsync(request_detail);
            Console.WriteLine($"Doctor Id: {response.Doctor.Id}");
            Console.WriteLine($"Doctor FirstName: {response.Doctor.FirstName}");
            Console.WriteLine($"Doctor LastName: {response.Doctor.LastName}");
            Console.WriteLine($"Doctor Specialization: {response.Doctor.Specialization}");
            Console.WriteLine($"Doctor Image: {response.Doctor.Image}");
            Doctor = response.Doctor;
            Console.WriteLine($"Doctor:::: {response.Doctor}");

            StateHasChanged();

        }

        private void NavigateToDoctor()
        {
            NavigationManager.NavigateTo($"overons", forceLoad: true);
        }
    }
}
