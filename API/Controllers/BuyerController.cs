using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using API.Entities;
using API.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using API.DTOs;

namespace API.Controllers
{
    public class BuyerController : BaseApiController
{
    private readonly BuyerService _buyerService;
    private readonly IUserRepository _userRepository;

    public BuyerController(BuyerService buyerService, IUserRepository userRepository)
    {
        _buyerService = buyerService;
        _userRepository = userRepository;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<BuyerDTO>>> GetBuyers()
    {
        var username = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var buyers = await _buyerService.GetBuyers(username);
        return Ok(buyers);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<BuyerDTO>> GetBuyer(int id)
    {
        var username = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var buyer = await _buyerService.GetBuyerById(id, username);
        if (buyer == null) return NotFound();
        return Ok(buyer);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<BuyerDTO>> CreateBuyer(BuyerDTO buyerDTO)
    {
        var username = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (username == null) return Unauthorized();
        var buyer = await _buyerService.CreateBuyer(buyerDTO, username);
        return Ok(buyer);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<BuyerDTO>> UpdateBuyer(int id, BuyerDTO buyerDTO)
    {
        var username = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var updatedBuyer = await _buyerService.UpdateBuyer(id, buyerDTO, username);
        if (updatedBuyer == null) return NotFound();
        return Ok(updatedBuyer);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult> DeleteBuyer(int id)
    {
        var username = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await _buyerService.DeleteBuyer(id, username);
        if (!result) return NotFound();
        return Ok();
    }
}


}
