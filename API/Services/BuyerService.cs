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
    public class BuyerService
{
    private readonly DataContext _dbContext;
    private readonly IUserRepository _userRepository;

    public BuyerService(DataContext dbContext, IUserRepository userRepository)
    {
        _dbContext = dbContext;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<BuyerDTO>> GetBuyers(string username)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        var buyers = await _dbContext.Buyers
            .Where(x => x.AppUserId == user.Id)
            .ToListAsync();

        return buyers.Select(buyer => MapToDTO(buyer));
    }

    public async Task<BuyerDTO> GetBuyerById(int id, string username)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        var buyer = await _dbContext.Buyers
            .FirstOrDefaultAsync(x => x.Id == id && x.AppUserId == user.Id);

        return buyer != null ? MapToDTO(buyer) : null;
    }

    public async Task<BuyerDTO> CreateBuyer(BuyerDTO buyerDTO, string username)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        var buyer = new Buyer
        {
            Name = buyerDTO.Name,
            Address = buyerDTO.Address,
            City = buyerDTO.City,
            Country = buyerDTO.Country,
            PostalCode = buyerDTO.PostalCode,
            IdentificationNumber = buyerDTO.IdentificationNumber,
            TaxNumber = buyerDTO.TaxNumber,
            BankAccount1 = buyerDTO.BankAccount1,
            BankAccount2 = buyerDTO.BankAccount2,
            BankAccount3 = buyerDTO.BankAccount3,
            Swift = buyerDTO.Swift,
            IsDomestic = buyerDTO.IsDomestic,
            AppUserId = user.Id
        };
        _dbContext.Buyers.Add(buyer);
        await _dbContext.SaveChangesAsync();

        return MapToDTO(buyer);
    }

    public async Task<BuyerDTO> UpdateBuyer(int id, BuyerDTO buyerDTO, string username)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        var existingBuyer = await _dbContext.Buyers
            .FirstOrDefaultAsync(x => x.Id == id && x.AppUserId == user.Id);

        if (existingBuyer == null)
        {
            return null; // Return null if the buyer doesn't exist or doesn't belong to the user.
        }

        existingBuyer.Name = buyerDTO.Name;
        existingBuyer.Address = buyerDTO.Address;
        existingBuyer.City = buyerDTO.City;
        existingBuyer.Country = buyerDTO.Country;
        existingBuyer.PostalCode = buyerDTO.PostalCode;
        existingBuyer.IdentificationNumber = buyerDTO.IdentificationNumber;
        existingBuyer.TaxNumber = buyerDTO.TaxNumber;
        existingBuyer.BankAccount1 = buyerDTO.BankAccount1;
        existingBuyer.BankAccount2 = buyerDTO.BankAccount2;
        existingBuyer.BankAccount3 = buyerDTO.BankAccount3;
        existingBuyer.Swift = buyerDTO.Swift;
        existingBuyer.IsDomestic = buyerDTO.IsDomestic;

        await _dbContext.SaveChangesAsync();
        return MapToDTO(existingBuyer);
    }

    public async Task<bool> DeleteBuyer(int id, string username)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        var buyer = await _dbContext.Buyers
            .FirstOrDefaultAsync(x => x.Id == id && x.AppUserId == user.Id);

        if (buyer == null)
        {
            return false; // Return false if the buyer doesn't exist or doesn't belong to the user.
        }

        _dbContext.Buyers.Remove(buyer);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    // Helper method to map Buyer entity to BuyerDTO
    private BuyerDTO MapToDTO(Buyer buyer)
    {
        return new BuyerDTO
        {
            Id = buyer.Id,
            Name = buyer.Name,
            Address = buyer.Address,
            City = buyer.City,
            Country = buyer.Country,
            PostalCode = buyer.PostalCode,
            IdentificationNumber = buyer.IdentificationNumber,
            TaxNumber = buyer.TaxNumber,
            BankAccount1 = buyer.BankAccount1,
            BankAccount2 = buyer.BankAccount2,
            BankAccount3 = buyer.BankAccount3,
            Swift = buyer.Swift,
            IsDomestic = buyer.IsDomestic
        };
    }
}


}