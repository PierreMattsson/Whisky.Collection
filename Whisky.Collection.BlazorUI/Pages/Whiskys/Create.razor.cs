using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Whisky.Collection.BlazorUI.Contracts;
using Whisky.Collection.BlazorUI.Models.MyWhiskys;

namespace Whisky.Collection.BlazorUI.Pages.Whiskys;

public partial class Create
{
    [Inject]
    NavigationManager _navManager { get; set; }
    [Inject]
    IMyWhiskyService _client { get; set; }
    //[Inject]
    //IToastService toastService { get; set; }
    public string Message { get; private set; }

    MyWhiskyVM myWhisky = new();

    async Task CreateMyWhisky()
    {
        var repsonse = await _client.CreateMyWhisky(myWhisky);
        if (repsonse.Success)
        {
            //toastService.ShowSuccess("Whisky created successfully");
            //toastService.ShowToast(ToastLevel.Info, "Test");
            _navManager.NavigateTo("/mywhiskys/");
        }
        Message = repsonse.Message;
    }
}