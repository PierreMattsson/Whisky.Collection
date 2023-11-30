using Microsoft.AspNetCore.Components;
using Whisky.Collection.BlazorUI.Contracts;
using Whisky.Collection.BlazorUI.Models.MyWhiskys;

namespace Whisky.Collection.BlazorUI.Pages.Whiskys;

public partial class Index
{
    [Inject]
    public NavigationManager ?NavigationManager { get; set; }

    [Inject] IMyWhiskyService ?MyWhiskyService { get; set;}

    public List<MyWhiskyVM> ?MyWhiskys {  get; private set; }
    public string Message { get; set; } = string.Empty;

    protected void CreateMyWhisky()
    {
        NavigationManager?.NavigateTo("/mywhiskys/create/");
    }

    protected void AllocateMyWhisky(int id)
    {
        // Use Whisky ALlocation Service here
    }

    protected void EditMyWhisky(int id)
    {
        NavigationManager?.NavigateTo($"/mywhiskys/edit/{id}");
    }

    protected void DetailsMyWhisky(int id)
    {
        NavigationManager?.NavigateTo($"/mywhiskys/details/{id}");
    }

    protected async Task DeleteMyWhisky(int id)
    {
        var response = await MyWhiskyService.DeleteMyWhisky(id);
        if (response.Success)
        {
            StateHasChanged();
        }
        else
        {
            Message = response.Message;
        }
    }

    protected override async Task OnInitializedAsync()
    {
        MyWhiskys = await MyWhiskyService.GetMyWhiskys();
    }
}