using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Models
{
    public class LedgerItemDto
    {
        [Key]
        public int LedgerItemId { get; set; }
        public DateTime Posted { get; set; }
        public string Description { get; set; }
        //[Range(0, -1000000)]
        public double Debit { get; set; } = 0;
        //[Range(0, 1000000)]
        public double Credit { get; set; } = 0;
        public string Remarks { get; set; }
        public string User { get; set; }

    }
}
