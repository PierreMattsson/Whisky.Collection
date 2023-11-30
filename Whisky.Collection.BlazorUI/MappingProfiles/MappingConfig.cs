using AutoMapper;
using Whisky.Collection.BlazorUI.Models.MyWhiskys;
using Whisky.Collection.BlazorUI.Services.Base;

namespace Whisky.Collection.BlazorUI.MappingProfiles;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<MyWhiskyDTO, MyWhiskyVM>().ReverseMap();
        CreateMap<CreateMyWhiskyCommand, MyWhiskyVM>().ReverseMap();
        CreateMap<UpdateMyWhiskyCommand, MyWhiskyVM>().ReverseMap();
    }
}
