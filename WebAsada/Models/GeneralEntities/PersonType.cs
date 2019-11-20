using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class PersonType : GeneralEntity
    {
        private PersonType()
        {

        }

        public PersonType(string shortDesc, string longDesc, string officialId, string nemotecnico, string personTypeCode, bool isActive)
            : base(shortDesc, longDesc, officialId, nemotecnico, isActive)
        {
            PersonTypeCode = personTypeCode;
        }

        public string PersonTypeCode { get; private set; }

        public static PersonType SincronizeObject(PersonType currentCustomerType, PersonType newCustomerType)
        {
            currentCustomerType.PersonTypeCode = newCustomerType.PersonTypeCode;
            currentCustomerType.Clone(newCustomerType);
            return currentCustomerType; 
        }
    }
}