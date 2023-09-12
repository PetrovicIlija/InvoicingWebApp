using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
public class ServiceService
    {
        private readonly DataContext _dbContext;
        private readonly IUserRepository _userRepository;

        public ServiceService(DataContext dbContext, IUserRepository userRepository)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ServiceDTO>> GetServices(string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            var services = await _dbContext.Services
                .Where(x => x.AppUserId == user.Id)
                .ToListAsync();

            return services.Select(service => MapToDTO(service));
        }

        public async Task<ServiceDTO> GetServiceById(int id, string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            var service = await _dbContext.Services
                .FirstOrDefaultAsync(x => x.Id == id && x.AppUserId == user.Id);

            return service != null ? MapToDTO(service) : null;
        }

        public async Task<ServiceDTO> CreateService(ServiceDTO serviceDTO, string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            var service = new Service
            {
                Name = serviceDTO.Name,
                Price = serviceDTO.Price,
                PriceInEuros = serviceDTO.PriceInEuros,
                AppUserId = user.Id
            };
            _dbContext.Services.Add(service);
            await _dbContext.SaveChangesAsync();

            return MapToDTO(service);
        }

        public async Task<ServiceDTO> UpdateService(int id, ServiceDTO serviceDTO, string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            var existingService = await _dbContext.Services
                .FirstOrDefaultAsync(x => x.Id == id && x.AppUserId == user.Id);

            if (existingService == null)
            {
                return null; // Return null if the service doesn't exist or doesn't belong to the user.
            }

            existingService.Name = serviceDTO.Name;
            existingService.Price = serviceDTO.Price;
            existingService.PriceInEuros = serviceDTO.PriceInEuros;

            await _dbContext.SaveChangesAsync();
            return MapToDTO(existingService);
        }

        public async Task<bool> DeleteService(int id, string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            var service = await _dbContext.Services
                .FirstOrDefaultAsync(x => x.Id == id && x.AppUserId == user.Id);

            if (service == null)
            {
                return false; // Return false if the service doesn't exist or doesn't belong to the user.
            }

            _dbContext.Services.Remove(service);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        // Helper method to map Service entity to ServiceDTO
        private ServiceDTO MapToDTO(Service service)
        {
            return new ServiceDTO
            {
                Id = service.Id,
                Name = service.Name,
                Price = service.Price,
                PriceInEuros = service.PriceInEuros
            };
        }
    }



}