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
    public class InvoiceHeaderService
{
    private readonly DataContext _dbContext;
    private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;

        public InvoiceHeaderService(DataContext dbContext, IUserRepository userRepository, TokenService tokenService)
    {
        _dbContext = dbContext;
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<IEnumerable<InvoiceHeaderDTO>> GetInvoiceHeaders(string username)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        var invoiceHeaders = await _dbContext.InvoiceHeaders
            .Include(x => x.Buyer)
            .Include(x => x.AppUser)
            .Include(x => x.InvoiceItems)
            .Where(x => x.AppUserId == user.Id)
            .ToListAsync();

        return invoiceHeaders.Select(header => MapToDTO(header));
    }

    public async Task<InvoiceHeaderDTO> GetInvoiceHeaderById(int id, string username)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        var invoiceHeader = await _dbContext.InvoiceHeaders
            .Include(x => x.Buyer)
            .Include(x => x.AppUser)
            .Include(x => x.InvoiceItems)
            .Where(x => x.AppUserId == user.Id)
            .FirstOrDefaultAsync(x => x.Id == id);

        return invoiceHeader != null ? MapToDTO(invoiceHeader) : null;
    }

    public async Task<InvoiceHeaderDTO> CreateInvoiceHeader(InvoiceHeaderDTO invoiceHeaderDTO, string username)
{
    var user = await _userRepository.GetUserByUsernameAsync(username);


    var buyer = await _dbContext.Buyers.FirstOrDefaultAsync(x => x.Id == invoiceHeaderDTO.Buyer.Id);

    var invoiceHeader = new InvoiceHeader
    {
        InvoiceNumber = invoiceHeaderDTO.InvoiceNumber,
        ShippingDate = invoiceHeaderDTO.ShippingDate,
        DocumentDate = invoiceHeaderDTO.DocumentDate,
        ArrivalDate = invoiceHeaderDTO.ArrivalDate,
        Description = invoiceHeaderDTO.Description,
        Remark = invoiceHeaderDTO.Remark,
        PlaceOfIssuance = invoiceHeaderDTO.PlaceOfIssuance,
        DateOfIssuance = invoiceHeaderDTO.DateOfIssuance,
        FiscalNumber = invoiceHeaderDTO.FiscalNumber,
        Buyer = buyer, // Assign the Buyer instance
        NumberOfItems = invoiceHeaderDTO.NumberOfItems,
        IsCharged = invoiceHeaderDTO.IsCharged,
        AppUserId = user.Id,
        InvoiceItems = invoiceHeaderDTO.InvoiceItems.Select(item => new InvoiceItem
        {
            Description = item.Description,
            Quantity = item.Quantity,
            PriceOfService = item.PriceOfService,
            PriceOfServiceInEuros = item.PriceOfServiceInEuros,
            Discount = item.Discount,
            Tax = item.Tax,
            TotalPrice = item.TotalPrice,
            InvoiceHeaderId = invoiceHeaderDTO.Id,
            ServiceId = item.ServiceId
        }).ToList()
    };

    _dbContext.InvoiceHeaders.Add(invoiceHeader);
    await _dbContext.SaveChangesAsync();

    return MapToDTO(invoiceHeader);
}

public async Task<InvoiceHeaderDTO> UpdateInvoiceHeader(int id, InvoiceHeaderDTO invoiceHeaderDTO, string username)
{
    var user = await _userRepository.GetUserByUsernameAsync(username);
    var existingInvoiceHeader = await _dbContext.InvoiceHeaders
        .Include(x => x.Buyer)
        .Include(x => x.AppUser)
        .Include(x => x.InvoiceItems)
        .FirstOrDefaultAsync(x => x.Id == id && x.AppUserId == user.Id);

    if (existingInvoiceHeader == null)
    {
        return null; // Return null if the invoice header doesn't exist or doesn't belong to the user.
    }

    // Manually update the Buyer property
    existingInvoiceHeader.Buyer.Id = invoiceHeaderDTO.Buyer.Id;
    existingInvoiceHeader.Buyer.Name = invoiceHeaderDTO.Buyer.Name;
    existingInvoiceHeader.Buyer.Address = invoiceHeaderDTO.Buyer.Address;
    existingInvoiceHeader.Buyer.City = invoiceHeaderDTO.Buyer.City;
    existingInvoiceHeader.Buyer.Country = invoiceHeaderDTO.Buyer.Country;
    existingInvoiceHeader.Buyer.PostalCode = invoiceHeaderDTO.Buyer.PostalCode;
    existingInvoiceHeader.Buyer.IdentificationNumber = invoiceHeaderDTO.Buyer.IdentificationNumber;
    existingInvoiceHeader.Buyer.TaxNumber = invoiceHeaderDTO.Buyer.TaxNumber;
    existingInvoiceHeader.Buyer.BankAccount1 = invoiceHeaderDTO.Buyer.BankAccount1;
    existingInvoiceHeader.Buyer.BankAccount2 = invoiceHeaderDTO.Buyer.BankAccount2;
    existingInvoiceHeader.Buyer.BankAccount3 = invoiceHeaderDTO.Buyer.BankAccount3;
    existingInvoiceHeader.Buyer.Swift = invoiceHeaderDTO.Buyer.Swift;
    existingInvoiceHeader.Buyer.IsDomestic = invoiceHeaderDTO.Buyer.IsDomestic;

    // Update other properties
    existingInvoiceHeader.InvoiceNumber = invoiceHeaderDTO.InvoiceNumber;
    existingInvoiceHeader.ShippingDate = invoiceHeaderDTO.ShippingDate;
    existingInvoiceHeader.DocumentDate = invoiceHeaderDTO.DocumentDate;
    existingInvoiceHeader.ArrivalDate = invoiceHeaderDTO.ArrivalDate;
    existingInvoiceHeader.Description = invoiceHeaderDTO.Description;
    existingInvoiceHeader.Remark = invoiceHeaderDTO.Remark;
    existingInvoiceHeader.PlaceOfIssuance = invoiceHeaderDTO.PlaceOfIssuance;
    existingInvoiceHeader.DateOfIssuance = invoiceHeaderDTO.DateOfIssuance;
    existingInvoiceHeader.FiscalNumber = invoiceHeaderDTO.FiscalNumber;
    existingInvoiceHeader.NumberOfItems = invoiceHeaderDTO.NumberOfItems;
    existingInvoiceHeader.IsCharged = invoiceHeaderDTO.IsCharged;

    existingInvoiceHeader.InvoiceItems = invoiceHeaderDTO.InvoiceItems.Select(item => new InvoiceItem
    {
        Id = item.Id,
        Description = item.Description,
        Quantity = item.Quantity,
        PriceOfService = item.PriceOfService,
        PriceOfServiceInEuros = item.PriceOfServiceInEuros,
        Discount = item.Discount,
        Tax = item.Tax,
        TotalPrice = item.TotalPrice,
        InvoiceHeaderId = invoiceHeaderDTO.Id,
        ServiceId = item.ServiceId
    }).ToList();

    await _dbContext.SaveChangesAsync();
    return MapToDTO(existingInvoiceHeader);
}


    public async Task<bool> DeleteInvoiceHeader(int id, string username)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        var invoiceHeader = await _dbContext.InvoiceHeaders
            .Include(x => x.Buyer)
            .Include(x => x.AppUser)
            .FirstOrDefaultAsync(x => x.Id == id && x.AppUserId == user.Id);

        if (invoiceHeader == null)
        {
            return false; // Return false if the invoice header doesn't exist or doesn't belong to the user.
        }

        _dbContext.InvoiceHeaders.Remove(invoiceHeader);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    // Helper method to map InvoiceHeader entity to InvoiceHeaderDTO
    private InvoiceHeaderDTO MapToDTO(InvoiceHeader invoiceHeader)
{
    return new InvoiceHeaderDTO
    {
        Id = invoiceHeader.Id,
        InvoiceNumber = invoiceHeader.InvoiceNumber,
        ShippingDate = invoiceHeader.ShippingDate,
        DocumentDate = invoiceHeader.DocumentDate,
        ArrivalDate = invoiceHeader.ArrivalDate,
        Description = invoiceHeader.Description,
        Remark = invoiceHeader.Remark,
        PlaceOfIssuance = invoiceHeader.PlaceOfIssuance,
        DateOfIssuance = invoiceHeader.DateOfIssuance,
        FiscalNumber = invoiceHeader.FiscalNumber,
        Buyer = MapToBuyerDTO(invoiceHeader.Buyer),
        NumberOfItems = invoiceHeader.NumberOfItems,
        TotalPrice = invoiceHeader.TotalPrice,
        IsCharged = invoiceHeader.IsCharged,
        AppUserId = invoiceHeader.AppUserId,
        AppUser = MapToUserDTO(invoiceHeader.AppUser),
        InvoiceItems = invoiceHeader.InvoiceItems.Select(MapToDTO).ToList()
    };
}

private InvoiceItemDTO MapToDTO(InvoiceItem invoiceItem)
{
    return new InvoiceItemDTO
    {
        Id = invoiceItem.Id,
        Description = invoiceItem.Description,
        Quantity = invoiceItem.Quantity,
        PriceOfService = invoiceItem.PriceOfService,
        PriceOfServiceInEuros = invoiceItem.PriceOfServiceInEuros,
        Discount = invoiceItem.Discount,
        Tax = invoiceItem.Tax,
        TotalPrice = invoiceItem.TotalPrice,
        InvoiceHeaderId = invoiceItem.InvoiceHeaderId,
        ServiceId = invoiceItem.ServiceId
    };
}


    // Helper method to map BuyerDTO to Buyer entity
    private BuyerDTO MapToBuyerDTO(Buyer buyer)
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

    // Helper method to map AppUser to UserDTO
    private UserDTO MapToUserDTO(AppUser appUser)
    {
        return new UserDTO
        {
            Username = appUser.UserName,
            Token = _tokenService.CreateToken(appUser)
        };
    }
    
}


}