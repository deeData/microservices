using BillingApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingApi.Repository
{
    interface IChargeRepository
    {
        Task<bool> ChargeToLedger(LedgerItem ledgerItem);
    }
}
