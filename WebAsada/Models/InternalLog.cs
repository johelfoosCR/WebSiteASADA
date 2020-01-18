using System;
using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class InternalLog : BaseEntity
    {  
        public string Message { get; set; }
        public SystemUser User { get; set; }
        public DateTime EntryLogDate { get; set; }
    }
}
