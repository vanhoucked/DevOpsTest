using Microsoft.AspNetCore.Components;
using Project.Shared.Doctors;


namespace Project.Client.Pages.AboutUs.Components
{
    public partial class DoctorCard
    {
        [Parameter] public DoctorDTO.Index Doctor { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

    }
}
