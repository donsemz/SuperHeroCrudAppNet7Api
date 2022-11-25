namespace SuperHeroCrudAppNet7Api.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero?> GetHero(int id);
        Task<List<SuperHero>> AddHero(SuperHero hero);
        Task<List<SuperHero>?> UpdateHero(SuperHero hero);
        Task<List<SuperHero>?> DeleteHero(int id);
    }
}
