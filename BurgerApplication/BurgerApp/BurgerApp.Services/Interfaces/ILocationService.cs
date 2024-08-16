
using BurgerApp.Domain;
using BurgerApp.Dtos.Dto;

namespace BurgerApp.Services.Interfaces
{
    public interface ILocationService
    {
        List<LocationDto> GetAllLocations();
        LocationDto GetLocationById(int id);
        void AddLocation(LocationDto location);
        void UpdateLocation(LocationDto location);
        void DeleteLocation(int id);
    }
}
