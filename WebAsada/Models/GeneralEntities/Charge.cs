using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class Charge : GeneralEntity
    { 
        private Charge()
        {
             
        }

        public Charge(string shortDesc, string longDesc, string officialId, string nemotecnico, string chargeCode,bool isActive, double price)
            : base(shortDesc,longDesc,officialId,nemotecnico, isActive)
        { 
            ChargeCode = chargeCode;
            Price = price;
        }

        public string ChargeCode { get; private set; }

        public double Price { get; private set; }

        public static Charge SincronizeObject(Charge currentCharge, Charge newCharge)
        {
            currentCharge.ChargeCode = newCharge.ChargeCode;
            currentCharge.Price = newCharge.Price;
            currentCharge.Clone(newCharge);
            return currentCharge;
        }

    }
}
