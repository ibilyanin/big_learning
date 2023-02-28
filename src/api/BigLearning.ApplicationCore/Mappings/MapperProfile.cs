using AutoMapper;
using Elang.ApplicationCore.Cards.Dto;
using Elang.ApplicationCore.Topics.Dto;
using Elang.Domain.Entities;
using Elang.Domain.Specifications.Filters;

namespace Elang.ApplicationCore.Mappings;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        AllowNullCollections = true;
        AllowNullDestinationValues = true;

        CreateMap<TopicDto, Topic>();
        CreateMap<CreateTopicDto, Topic>();

        CreateMap<CardDto, Card>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(s => s.Type.ParseCardType()))
            .ForMember(dest => dest.Topics, opt => opt.Ignore());

        CreateMap<CreateCardDto, Card>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(s => s.Type.ParseCardType()))
            .ForMember(dest => dest.Topics, opt => opt.Ignore());

        CreateMap<Card, CardDto>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(s => s.Type.ToString()));

        CreateMap<CardFilterDto, CardFilter>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(s => s.Type.ParseCardType()));
    }
}
