using AutoMapper;
using Whisky.Collection.BlazorUI.Contracts;
using Whisky.Collection.BlazorUI.Models.MyWhiskys;
using Whisky.Collection.BlazorUI.Services.Base;

namespace Whisky.Collection.BlazorUI.Services;

public class MyWhiskyService : BaseHttpService, IMyWhiskyService
{
    private readonly IMapper _mapper;

    public MyWhiskyService(IClient client, IMapper mapper) : base(client)
    {
        _mapper = mapper;
    }

    public async Task<Response<Guid>> CreateMyWhisky(MyWhiskyVM myWhisky)
    {
        try
        {
            var createMyWhiskyCommand = _mapper.Map<CreateMyWhiskyCommand>(myWhisky);
            await _client.MyWhiskyPOSTAsync(createMyWhiskyCommand);
            return new Response<Guid>()
            {
                Success = true,
            };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> DeleteMyWhisky(int id)
    {
        try
        {
            await _client.MyWhiskyDELETEAsync(id);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<MyWhiskyVM> GetMyWhiskyDetails(int id)
    {
        var myWhisky = await _client.MyWhiskyGETAsync(id);
        return _mapper.Map<MyWhiskyVM>(myWhisky);
    }

    public async Task<List<MyWhiskyVM>> GetMyWhiskys()
    {
        var myWhisky = await _client.MyWhiskyAllAsync();
        return _mapper.Map<List<MyWhiskyVM>>(myWhisky);
    }

    public async Task<Response<Guid>> UpdateMyWhisky(int id, MyWhiskyVM myWhisky)
    {
        try
        {
            var updateMyWhiskyCommand = _mapper.Map<UpdateMyWhiskyCommand>(myWhisky);
            await _client.MyWhiskyPUTAsync(id.ToString(), updateMyWhiskyCommand);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}
