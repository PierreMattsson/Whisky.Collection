using Whisky.Collection.BlazorUI.Models.MyWhiskys;
using Whisky.Collection.BlazorUI.Services.Base;

namespace Whisky.Collection.BlazorUI.Contracts;

public interface IMyWhiskyService
{
    Task<List<MyWhiskyVM>> GetMyWhiskys();
    Task<MyWhiskyVM> GetMyWhiskyDetails(int id);
    Task<Response<Guid>> CreateMyWhisky(MyWhiskyVM myWhisky);
    Task<Response<Guid>> UpdateMyWhisky(int id, MyWhiskyVM myWhisky);
    Task<Response<Guid>> DeleteMyWhisky(int id);
}
