using AutoMapper;
using BillingApi.DbContexts;
using BillingApi.Model;
using BillingApi.Model.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingApi.Repository
{
    public class BillingTransactionsRepository : IBillingTransactionsRepository
    {
        //call db and mapper using dependency injection
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public BillingTransactionsRepository(ApplicationDbContext db, IMapper mapper) { _db = db; _mapper = mapper; }

        public async Task<List<LedgerItemDto>> GetAllTransactions()
        {
            IEnumerable<LedgerItem> ledgerItems = await _db.LedgerItems.ToListAsync();
            return _mapper.Map<List<LedgerItemDto>>(ledgerItems);
        }

        public async Task<bool> DebitChargeApply(LedgerItemDto ledgerItemDto)
        {
            LedgerItem ledgerItem = _mapper.Map<LedgerItemDto, LedgerItem>(ledgerItemDto);

            try
            {
                _db.LedgerItems.Add(ledgerItem);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to add - Exception: " + e);
                return false;
            }
        }

        public Task<bool> CreditPaymentApply(LedgerItemDto ledgerItem)
        {
            throw new NotImplementedException();
        }

    }
}
