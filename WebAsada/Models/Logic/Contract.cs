using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class Contract : BaseEntity
    {
        public static Contract Create(PersonsByEstate personsByEstate,
                                      ContractType contractType,
                                      WaterMeter waterMeter,
                                      int initialMeterRead = 0,
                                      bool doubleBasicCharge = false,
                                      bool isActive = true) {
            return new Contract()
            {
                PersonsByEstate = personsByEstate,
                ContractTypeId = contractType.Id,
                MeterId = waterMeter.Id,
                InitialMeterRead = initialMeterRead,
                DoubleBasicCharge = doubleBasicCharge,
                IsActive = isActive,
                EmissionDate = DateTime.Now
            };
        }

        public PersonsByEstate PersonsByEstate { get; private set; }

        public int PersonsId { get; private set; }

        public int EstateId { get; private set; }

        public ContractType ContractType { get; private set; }

        public int ContractTypeId { get; private set; }

        public WaterMeter Meter { get; private set; }
         
        public int MeterId { get; private set; }

        public DateTime EmissionDate  { get; private set; }

        public int InitialMeterRead { get; private set; }
         
        public bool DoubleBasicCharge { get; private set; }

        public bool IsActive { get; private set; }

        [NotMapped]
        public string Identifier => string.Format("ACV-SJS-{0}", Id.ToString().PadLeft(5,'0'));

        internal static Contract SincronizeObject(Contract currentObject, Contract newObject)
        { 
            currentObject.PersonsByEstate = newObject.PersonsByEstate;
            currentObject.PersonsId = newObject.PersonsId;
            currentObject.EstateId = newObject.EstateId;
            currentObject.ContractTypeId = newObject.ContractTypeId;
            currentObject.IsActive = newObject.IsActive;
            currentObject.DoubleBasicCharge = newObject.DoubleBasicCharge;
            currentObject.MeterId = newObject.MeterId;
            currentObject.InitialMeterRead = newObject.InitialMeterRead;
            return currentObject;
        }
    }
}
