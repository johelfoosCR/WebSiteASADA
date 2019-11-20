using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class ContractType : GeneralEntity
    {
        private ContractType()
        {

        }

        public ContractType(string shortDesc, string longDesc, string officialId, string nemotecnico, string contractTypeCode, bool isActive)
            : base(shortDesc, longDesc, officialId, nemotecnico, isActive)
        {
            ContractTypeCode = contractTypeCode;
        }

        public string ContractTypeCode { get; private set; }

        public static ContractType SincronizeObject(ContractType currentObject, ContractType newObject)
        {
            currentObject.ContractTypeCode = newObject.ContractTypeCode;
            currentObject.Clone(newObject);
            return currentObject; 
        }
    }
}