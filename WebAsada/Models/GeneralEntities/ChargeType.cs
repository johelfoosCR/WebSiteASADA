using System.ComponentModel;
using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class ChargeType: GeneralEntity
    {
        private ChargeType()
        {

        }

        public ChargeType(string shortDesc, string longDesc, string officialId, string nemotecnico, string chargeTypeCode, bool isActive)
            : base(shortDesc, longDesc, officialId, nemotecnico, isActive)
        {
            ChargeTypeCode = chargeTypeCode;
        }

        public string ChargeTypeCode { get; private set; }

        [DefaultValue(0)]
        public double VatRate { get; private set; }

        [DefaultValue(false)]
        public bool IsVATCharge { get; private set; }

        internal static ChargeType SincronizeObject(ChargeType currentObject, ChargeType newObject)
        {
            currentObject.ChargeTypeCode = newObject.ChargeTypeCode;
            currentObject.VatRate = newObject.VatRate;
            currentObject.IsVATCharge = newObject.IsVATCharge;
            currentObject.Clone(currentObject);
            return currentObject;
        } 
    }
}
