using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class Receipt : BaseEntity
    {
        private Receipt()
        { 
        }

        public Receipt(Measurement measurement, Contract contract, double newRead) {
            Measurement = measurement;
            Contract = contract;
            NewRead = newRead;
        }

        public Measurement Measurement { get; private set; }

        public Contract Contract { get; private set; }  

        public double NewRead { get; private set; }
         
        public double TotalAmount { get; private set; } 
    }
}