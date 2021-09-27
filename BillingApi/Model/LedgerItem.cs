using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BillingApi.Model
{
    public class LedgerItem
    {
        [Key]
        public int LedgerItemId { get; set; }
        public DateTime Posted { get; set; }
        public string Description { get; set; }
        [Range(-1000000, -0.01)]
        public double Debit { get; set; } = 0;
        [Range(0.01, 1000000)]
        public double Credit { get; set; } = 0;
        public string Remarks { get; set; }
        public string User { get; set; }
    }
}
