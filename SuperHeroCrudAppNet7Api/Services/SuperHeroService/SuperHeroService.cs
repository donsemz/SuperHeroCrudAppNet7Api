using Microsoft.EntityFrameworkCore;
using SuperHeroCrudAppNet7Api.Data;

namespace SuperHeroCrudAppNet7Api.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
/*        private static List<SuperHero> superHeroes = new List<SuperHero>
            {
                new SuperHero
                {
                    Id=1,
                    Name="SpiderMan",
                    FirstName="Peter",
                    LastName="Parker",
                    Place="New York City"
                },
                new SuperHero
                {
                    Id=2,
                    Name="BatMan",
                    FirstName="Bruce",
                    LastName="Wayne",
                    Place="Gotham City"
                }
            };*/
        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return null;

            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero?> GetHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return null;
            return hero;
        }

        public async Task<List<SuperHero>?> UpdateHero(SuperHero hero)
        {
            var dbhero = await _context.SuperHeroes.FindAsync(hero.Id);
            if (dbhero == null)
                return null;

            dbhero.Name = hero.Name;
            dbhero.FirstName = hero.FirstName;
            dbhero.LastName = hero.LastName;
            dbhero.Place = hero.Place;

            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
