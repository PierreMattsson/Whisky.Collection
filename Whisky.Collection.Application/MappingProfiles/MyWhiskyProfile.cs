using AutoMapper;
using Whisky.Collection.Application.Features.MyWhisky.Queries.GetAllMyWhisky;
using Whisky.Collection.Domain;

namespace Whisky.Collection.Application.MappingProfiles;

public class MyWhiskyProfile : Profile
{
    public MyWhiskyProfile()
    {
        // This mapping will look at the shared datatypes and map those
        CreateMap<MyWhiskyDTO, MyWhisky>().ReverseMap();
    }
}
