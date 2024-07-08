using AutoMapper;
using SuperHeroApi.Dtos;
using SuperHeroApi.Entities;

namespace SuperHeroApi.Mapping
{
    public class SuperHeroProfile : Profile
    {
        public SuperHeroProfile()
        {
            CreateMap<SuperHero, SuperHeroDto>();
            CreateMap<SuperHeroDto,SuperHero>();
            CreateMap<List<SuperHeroDto>,List<SuperHero>>();
            CreateMap<List<SuperHero>, List<SuperHeroDto>>();
        }
    }
}
