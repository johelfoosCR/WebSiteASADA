using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class IdentificationType: GeneralEntity
    {
        private IdentificationType()
        {

        }

        public IdentificationType(string shortDesc, string longDesc, string officialId, string nemotecnico, string identificationTypeCode,bool isActive)
            : base(shortDesc, longDesc, officialId, nemotecnico, isActive)
        {
           IdentificationTypeCode = identificationTypeCode;
        }

        public string IdentificationTypeCode { get; private set; }

        public static IdentificationType SincronizeObject(IdentificationType currentIdentificationType, IdentificationType newIdentificationType)
        {
            currentIdentificationType.IdentificationTypeCode = newIdentificationType.IdentificationTypeCode;  
            currentIdentificationType.Clone(newIdentificationType);
            return currentIdentificationType;
        } 
    }
}
