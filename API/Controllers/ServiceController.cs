using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.EntityFrameworkCore;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using API.DTOs;
using API.Services;

namespace API.Controllers
{
    public class ServiceController : BaseApiController
    {
        private readonly ServiceService _serviceService;
        private readonly IUserRepository _userRepository;

        public ServiceController(ServiceService serviceService, IUserRepository userRepository)
        {
            _serviceService = serviceService;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ServiceDTO>>> GetServices()
        {
            var username = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var services = await _serviceService.GetServices(username);
            return Ok(services);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ServiceDTO>> GetService(int id)
        {
            var username = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var service = await _serviceService.GetServiceById(id, username);
            if (service == null) return NotFound();
            return Ok(service);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ServiceDTO>> CreateService(ServiceDTO serviceDTO)
        {
            var username = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (username == null) return Unauthorized();
            var service = await _serviceService.CreateService(serviceDTO, username);
            return Ok(service);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<ServiceDTO>> UpdateService(int id, ServiceDTO serviceDTO)
        {
            var username = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var updatedService = await _serviceService.UpdateService(id, serviceDTO, username);
            if (updatedService == null) return NotFound();
            return Ok(updatedService);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteService(int id)
        {
            var username = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _serviceService.DeleteService(id, username);
            if (!result) return NotFound();
            return Ok();
        }
    }



}