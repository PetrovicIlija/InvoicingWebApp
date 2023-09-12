using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.EntityFrameworkCore;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using API.DTOs;

namespace API.Controllers
{
    public class InvoiceHeaderController : BaseApiController
    {
        private readonly InvoiceHeaderService _invoiceHeaderService;

        public InvoiceHeaderController(InvoiceHeaderService invoiceHeaderService)
        {
            _invoiceHeaderService = invoiceHeaderService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<InvoiceHeader>>> GetInvoiceHeaders()
        {
            var username = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var invoiceHeaders = await _invoiceHeaderService.GetInvoiceHeaders(username);
            return Ok(invoiceHeaders);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<InvoiceHeader>> GetInvoiceHeader(int id)
        {
            var username = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var invoiceHeader = await _invoiceHeaderService.GetInvoiceHeaderById(id, username);
            if (invoiceHeader == null) return NotFound();
            return Ok(invoiceHeader);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<InvoiceHeaderDTO>> CreateInvoiceHeader([FromBody]InvoiceHeaderDTO invoiceHeader)
        {
            var username = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var createdInvoiceHeader = await _invoiceHeaderService.CreateInvoiceHeader(invoiceHeader, username);
            return Ok(createdInvoiceHeader);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<InvoiceHeader>> UpdateInvoiceHeader(int id, InvoiceHeaderDTO invoiceHeader)
        {
            var username = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var updatedInvoiceHeader = await _invoiceHeaderService.UpdateInvoiceHeader(id, invoiceHeader, username);
            if (updatedInvoiceHeader == null) return NotFound();
            return Ok(updatedInvoiceHeader);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteInvoiceHeader(int id)
        {
            var username = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _invoiceHeaderService.DeleteInvoiceHeader(id, username);
            if (!result) return NotFound();
            return Ok();
        }
    }
}