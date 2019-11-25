using System.ComponentModel;
using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class Charge : GeneralEntity
    {
        private Charge()
        {

        }

        public Charge(string shortDesc, string longDesc, string officialId, string nemotecnico, string chargeCode, bool isActive, double price, ChargeType chargeType)
            : base(shortDesc, longDesc, officialId, nemotecnico, isActive)
        {
            ChargeCode = chargeCode;
            Price = price;
            ChargeType = chargeType;
        }

        public string ChargeCode { get; private set; }

        public double Price { get; private set; }

        public int ChargeTypeId { get; private set; }

        public ChargeType ChargeType { get; private set; }

        [DefaultValue(0)]
        public double CubicMeterFrom { get; private set; }

        [DefaultValue(0)]
        public double CubicMeterTo { get; private set; }
         

        public static Charge SincronizeObject(Charge currentCharge, Charge newCharge)
        {
            currentCharge.ChargeCode = newCharge.ChargeCode;
            currentCharge.ChargeType = newCharge.ChargeType;
            currentCharge.CubicMeterFrom = newCharge.CubicMeterFrom;
            currentCharge.CubicMeterTo = newCharge.CubicMeterTo; 
            currentCharge.Price = newCharge.Price;
            currentCharge.Clone(newCharge);
            return currentCharge;
        }

    }
}
