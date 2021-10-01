using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Models
{
    //gmail
    public class EmailDto
    {
        [DataType(DataType.EmailAddress)]
        public string ToEmail { get; set; }
        [DataType(DataType.EmailAddress)]
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
