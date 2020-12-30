using AutoMapper;
using CreditManager.API.Domain.Models;
using CreditManager.API.Domain.Services;
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
    public class TransactionsDetailsController : Controller
    {
        private readonly ITransactionDetailsService _transactionDetailsService; 
        private readonly IMapper _mapper;

        public TransactionsDetailsController(ITransactionDetailsService transactionDetailsService, IMapper mapper)
        {
            _transactionDetailsService = transactionDetailsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TransactionDetailsResource>> GetAllAsync()
        {
            var transactionDetails = await _transactionDetailsService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<TransactionDetails>, IEnumerable<TransactionDetailsResource>>(transactionDetails);
            return resources;
        }
    }
}
