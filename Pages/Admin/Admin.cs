using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text;

namespace SINNI_Football.Pages.Admin
{
    public class Admin : ComponentBase
    {
        string? authString;
        [Inject]
        ISessionStorageService sessionStorageService { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }
        [Inject]
        IJSRuntime JSRuntime { get; set; }

        public bool loggedIn = false;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var auth = await sessionStorageService.GetItemAsStringAsync("auth");
            if (auth != null)
            {
                authString = Encoding.UTF8.GetString(Convert.FromBase64String(auth));
            }
            else
            {
                navigationManager.NavigateTo("/admin/login");
            }

            var admin = DB.Accounts.Find("sinnofc");
            var adminString = $"{admin.Username.ToMD5()}-{admin.Password.ToMD5()}";

            if (authString == adminString)
            {
                loggedIn = true;
            }
            else
            {
                navigationManager.NavigateTo("/admin/login");
            }
            StateHasChanged();
        }
    }
}
