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
    public string Message { get; private set; }

    MyWhiskyVM myWhisky = new();

    async Task CreateMyWhisky()
    {
        var response = await _client.CreateMyWhisky(myWhisky);
        if (response.Success)
        {
            _navManager.NavigateTo("/mywhiskys/");
        }
        Message = response.Message;
    }

}