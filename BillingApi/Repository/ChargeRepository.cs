using BillingApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingApi.Repository
{
    public class ChargeRepository : IChargeRepository
    {
        public Task<bool> ChargeToLedger(LedgerItem ledgerItem)
        {
            throw new NotImplementedException();
        }
    }
}
