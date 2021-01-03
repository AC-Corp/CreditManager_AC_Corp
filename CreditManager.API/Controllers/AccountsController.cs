using AutoMapper;
using CreditManager.API.Domain.Models;
using CreditManager.API.Domain.Services;
using CreditManager.API.Extensions;
using CreditManager.API.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountsController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AccountResource>> GetAllAsync()
        {
            var accounts = await _accountService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Account>, IEnumerable<AccountResource>>(accounts);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAccountResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var order = _mapper.Map<SaveAccountResource, Account>(resource);
            var result = await _accountService.SaveAsync(order);
            if (!result.Success)
                return BadRequest(result.Message);
            var orderResource = _mapper
                .Map<Account, AccountResource>(result.Resource);
            return Ok(orderResource);
        }



        // TODO: Aumentar Linea de Credito
        [HttpPut("credit-{id}")]
        public async Task<IActionResult> PutCreditAsync(string id, [FromBody] SaveAccountResource resource)
        {
            //var order = _mapper.Map<SaveAccountResource, Account>(resource);
            //var result = await _accountService.UpdateAsync(id, order);

            /*if (!result.Success)
                return BadRequest(result.Message);
            var orderResource = _mapper
                .Map<Account, AccountResource>(result.Resource);*/
            return Ok(/*orderResource*/);
        }

        // TODO: Modificar Tasa y Tipo de Interes
        [HttpPut("interest-{id}")]
        public async Task<IActionResult> PutInterestAsync(string id, [FromBody] SaveAccountResource resource)
        {
            //var order = _mapper.Map<SaveAccountResource, Account>(resource);
            //var result = await _accountService.UpdateAsync(id, order);

            /*if (!result.Success)
                return BadRequest(result.Message);
            var orderResource = _mapper
                .Map<Account, AccountResource>(result.Resource);*/
            return Ok(/*orderResource*/);
        }
    }
}
