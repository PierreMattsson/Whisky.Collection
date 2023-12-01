using Microsoft.AspNetCore.Components;
using Whisky.Collection.BlazorUI.Models.MyWhiskys;

namespace Whisky.Collection.BlazorUI.Pages.Whiskys;

public partial class FormComponent
{
    [Parameter] public bool Disabled { get; set; } = false;
    [Parameter] public MyWhiskyVM? MyWhisky { get; set; }
    [Parameter] public string ButtonText { get; set; } = "Save";
    [Parameter] public EventCallback OnValidSubmit { get; set; }
}