using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Threading.Tasks;
using global::Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using Project.Client;
using Project.Client.Layout;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using Radzen;
using Radzen.Blazor;
using Project.Shared.News;

namespace Project.Client.Pages.Home.Components
{
    public partial class CardNews
    {
        [Parameter]
        public NewsDto.Index News { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private void NavigateToNews()
        {
            NavigationManager.NavigateTo($"nieuws/{News.Id}");
        }
    }
}