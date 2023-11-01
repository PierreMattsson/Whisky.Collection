using AutoMapper;
using Whisky.Collection.Application.Features.MyWhisky.Queries.GetMyWhiskyAll;
using Whisky.Collection.Domain;

namespace Whisky.Collection.Application.MappingProfiles;

public class MyWhiskyProfile : Profile
{
    public MyWhiskyProfile()
    {
        // This mapping will look at the shared datatypes and map those
        // So this will make it possible to convert from one type to another (Domain to DTO or other way aournd, thanks to reversemap)

        CreateMap<MyWhiskyDTO, MyWhisky>().ReverseMap();
    }
}
