﻿using AutoMapper;
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
    public class TransactionsController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public TransactionsController(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TransactionResource>> GetAllAsync()
        {
            var transactions = await _transactionService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Transaction>, IEnumerable<TransactionResource>>(transactions);
            return resources;
        }
    }
}
