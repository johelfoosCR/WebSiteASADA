using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAsada.Models;

namespace WebAsada.ViewModels
{
    public class ReceiptVM
    {
        public int Id { get; }

        public Measurement Measurement { get; set; }

        public Contract Contract { get; set; }

        public double NewRead { get; set; }
    }
}
