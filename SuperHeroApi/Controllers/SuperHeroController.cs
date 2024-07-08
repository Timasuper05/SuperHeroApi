using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Data;
using SuperHeroApi.Dtos;
using SuperHeroApi.Entities;
using SuperHeroApi.Services.SuperHeroService;

namespace SuperHeroApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
    private readonly ISuperHeroService _superheroservice;

    public SuperHeroController(ISuperHeroService superheroservice)
    {
        _superheroservice = superheroservice;
    }
    [HttpGet]
    public async Task<ActionResult<List<SuperHeroDto>>> GetAllHeroes()
    {
        var heroes =await _superheroservice.GetAllHeroes();
       
        return Ok(heroes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHeroDto>> GetHero(int id)
    {
        var hero = _superheroservice.GetHero(id);

        if (hero is null) return NotFound("Hero not found.");

        return Ok(await hero);
    }
    [HttpPost]
    public async Task<ActionResult<SuperHeroDto>> AddHero(SuperHero hero)
    {
        await _superheroservice.AddHero(hero);
        
        return Ok(await _superheroservice.GetAllHeroes());
    }
    [HttpPut]
    public async Task<ActionResult<SuperHeroDto>> UpdateHero(SuperHero updatehero)
    {
        var dbHero =await _superheroservice.UpdateHero(updatehero.Id,updatehero);

        if (dbHero is null) return NotFound("Hero not found.");


        return Ok(await _superheroservice.GetAllHeroes());
    }
    [HttpDelete]
    public async Task<ActionResult<SuperHeroDto>> DeleteHero(int id)
    {
        var result =await _superheroservice.DeleteHero(id);
        
        if (result is null) return NotFound("Hero not found");

        return Ok(result);
    }
}
