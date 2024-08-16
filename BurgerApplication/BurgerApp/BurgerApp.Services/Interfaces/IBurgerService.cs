using BurgerApp.Dtos.Dto;

namespace BurgerApp.Services.Interfaces
{
    public interface IBurgerService
    {
        List<BurgerDto> GetAllBurgers();
        BurgerDto GetBurgerById(int id);
        void AddBurger(BurgerDto burger);
        void UpdateBurger(BurgerDto burger);
        void DeleteBurger(int id);
    }
}
