using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Data;
using SuperHeroApi.Dtos;
using SuperHeroApi.Entities;

namespace SuperHeroApi.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public SuperHeroService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<SuperHeroDto>?> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            var allheroes = await _context.SuperHeroes.ToListAsync();
            var mapdto = _mapper.Map<List<SuperHeroDto>>(allheroes);
            return mapdto;
        }

        public async Task<List<SuperHeroDto>?> DeleteHero(int id)
        {
            var dbhero =  _context.SuperHeroes.Find(id);

            if (dbhero is null) return null;
            _context.SuperHeroes.Remove(dbhero);
            await _context.SaveChangesAsync();
            var allheroes = await _context.SuperHeroes.ToListAsync();
            var mapdto = _mapper.Map<List<SuperHeroDto>>(allheroes);
            return mapdto;
        }

        public async Task<List<SuperHeroDto>> GetAllHeroes()
        {
            var heroes =await  _context.SuperHeroes.ToListAsync();
            var dtomap = _mapper.Map<List<SuperHeroDto>>(heroes);
            return dtomap;
        }

        public async Task<SuperHeroDto?> GetHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null) return null;
            var dtomap = _mapper.Map<SuperHeroDto>(hero);

            return dtomap;
        }

        public async Task<List<SuperHeroDto>?> UpdateHero(int id, SuperHero updatehero)
        {
            var dbHero =  _context.SuperHeroes.Find(updatehero.Id);
            
            if (dbHero is null) return null;
            
            dbHero.Name = updatehero.Name;
            dbHero.FirstName = updatehero.FirstName;
            dbHero.LastName = updatehero.LastName;
            dbHero.Place = updatehero.Place;

            await _context.SaveChangesAsync();
            var allheroes = await _context.SuperHeroes.ToListAsync();
            var mapdto = _mapper.Map<List<SuperHeroDto>>(allheroes);
            return mapdto;
        }
    }
}
