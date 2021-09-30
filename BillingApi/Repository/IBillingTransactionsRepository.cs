using BillingApi.Model;
using BillingApi.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingApi.Repository
{
    public interface IBillingTransactionsRepository
    {
        Task<bool> ApplyToLedger(LedgerItemDto ledgerItem);
        Task<List<LedgerItemDto>> GetAllTransactions();
        Task<bool> DeleteAllInLedger();
    }
}
