using AutoMapper;

namespace Elang.ApplicationCore.Tests.Common;

public class MapperBuilder<TProfile>
    where TProfile : Profile, new()
{
    public MapperBuilder()
    {
        Mapper = CreateMapper();
    }

    public IMapper Mapper { get; }

    private static IMapper CreateMapper()
    {
        var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new TProfile()));
        return mapperConfiguration.CreateMapper();
    }
}
