using System;
using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class Contract: BaseEntity
    {
        public Estate Estate { get; }

        public WaterMeter Meter { get; }

        public Person Person { get; }

        public DateTime EmissionDate  { get; }

        public int InitialMeterRead { get; }
         
        public bool DoubleBasicCharge { get; }
    }
}
