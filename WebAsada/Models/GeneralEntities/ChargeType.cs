using System.ComponentModel;
using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class ChargeType: GeneralEntity
    {
        private ChargeType()
        {

        }

        public ChargeType(string shortDesc, string longDesc, string officialId, string nemotecnico, string chargeTypeCode, bool isActive, 
                          double vatRate, bool isVATCharge, bool isWaterConsume, bool isBaseFare)
            : base(shortDesc, longDesc, officialId, nemotecnico, isActive)
        {
            VatRate = vatRate;
            IsVATCharge = isVATCharge;
            IsBaseFare = isBaseFare;
            IsWaterConsume = isWaterConsume;
            ChargeTypeCode = chargeTypeCode;
        }

        public string ChargeTypeCode { get; private set; }

        [DefaultValue(0)]
        public double VatRate { get; private set; }

        [DefaultValue(false)]
        public bool IsVATCharge { get; private set; }

        [DefaultValue(false)]
        public bool IsBaseFare { get; private set; }

        [DefaultValue(false)]
        public bool IsWaterConsume { get; private set; }

        internal static ChargeType SincronizeObject(ChargeType currentObject, ChargeType newObject)
        {
            currentObject.ChargeTypeCode = newObject.ChargeTypeCode;
            currentObject.VatRate = newObject.VatRate;
            currentObject.IsVATCharge = newObject.IsVATCharge;
            currentObject.IsWaterConsume = newObject.IsWaterConsume;
            currentObject.IsBaseFare = newObject.IsBaseFare;
            currentObject.Clone(currentObject);
            return currentObject;
        } 
    }
}
