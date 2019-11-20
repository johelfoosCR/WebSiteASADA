using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class InternalLog : BaseEntity
    {  
        public string Message { get; set; }
        public IdentityUser User { get; set; }
        public DateTime EntryLogDate { get; set; }
    }
}
