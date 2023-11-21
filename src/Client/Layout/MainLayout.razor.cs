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

namespace Project.Client.Layout
{
    public partial class MainLayout
    {
        bool _drawerOpen = true;
        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        private string currentPath;
        protected override void OnInitialized()
        {
            var uri = new Uri(NavigationManager.Uri);
            currentPath = uri.AbsolutePath.Trim('/');
            Console.WriteLine(currentPath);
        }

        MudTheme MyCustomTheme = new MudTheme()
        {
            Palette = new PaletteLight()
            {
                Primary = Colors.Cyan.Default,
                Secondary = Colors.Cyan.Accent4,
                Tertiary = Colors.Cyan.Lighten5,
                AppbarBackground = Colors.Cyan.Darken3,
            },
            PaletteDark = new PaletteDark()
            {
                Primary = Colors.Cyan.Lighten1
            },

            LayoutProperties = new LayoutProperties()
            {
                DrawerWidthLeft = "260px",
                DrawerWidthRight = "300px"
            }
        };
    }
}