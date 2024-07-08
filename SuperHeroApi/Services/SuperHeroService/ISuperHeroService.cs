using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Dtos;
using SuperHeroApi.Entities;

namespace SuperHeroApi.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHeroDto>> GetAllHeroes();
        Task<SuperHeroDto?> GetHero(int id);
        Task<List<SuperHeroDto>?> AddHero(SuperHero hero);
        Task<List<SuperHeroDto>?> UpdateHero(int id,SuperHero updatehero);
        Task<List<SuperHeroDto>?> DeleteHero(int id);
    }
}
