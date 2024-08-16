using BurgerApp.DataAccess.Interfaces;
using BurgerApp.Domain;
using BurgerApp.Dtos.Dto;
using BurgerApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services
{
    public class LocationService : ILocationService
    {
        private readonly IRepository<Location> _locationRepository;

        public LocationService(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        
        }
        public List<LocationDto> GetAllLocations()
        {
            return _locationRepository.GetAll().Select(b => new LocationDto
            {
                Id = b.Id,
                LocationName = b.LocationName,
                Address = b.Address,
                OpensAt = b.OpensAt,
                ClosesAt = b.ClosesAt,

            }).ToList();
        }

        public LocationDto GetLocationById(int id)
        {
            var location = _locationRepository.GetById(id);
            if (location == null) return null;
            return new LocationDto
            {
                Id = location.Id,
                LocationName = location.LocationName,
                Address = location.Address,
                OpensAt = location.OpensAt,
                ClosesAt = location.ClosesAt
                
            };
        }

        public void AddLocation(LocationDto locationDto)
        {
            var location = new Location
            {
                Id = locationDto.Id,
                LocationName = locationDto.LocationName,
                Address = locationDto.Address,
                OpensAt = locationDto.OpensAt,
                ClosesAt = locationDto.ClosesAt,
            };
            _locationRepository.Add(location);
        }


        public void UpdateLocation(LocationDto locationDto)
        {
            var location= new Location
            {
                Id = locationDto.Id,
                LocationName = locationDto.LocationName,
                Address = locationDto.Address,
                OpensAt = locationDto.OpensAt,
                ClosesAt = locationDto.ClosesAt,
            };
            _locationRepository.Update(location);
        }
        public void DeleteLocation(int id)
        {
            _locationRepository.Delete(id);

        }
    }
}
