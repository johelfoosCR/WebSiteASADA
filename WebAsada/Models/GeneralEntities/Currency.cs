using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class Currency : GeneralEntity
    {
        private Currency()
        {

        }

        public Currency(string shortDesc, string longDesc, string officialId, string nemotecnico, string currencyCode, string acronym, bool isActive)
            : base(shortDesc, longDesc, officialId, nemotecnico, isActive)
        {
            CurrencyCode = currencyCode;
            Acronym = acronym;
        }

        public string CurrencyCode { get; private set; }
        public string Acronym { get; private set; }

        public static Currency SincronizeObject(Currency currentObject, Currency newObject)
        {
            currentObject.CurrencyCode = newObject.CurrencyCode;
            currentObject.Acronym = newObject.Acronym;
            currentObject.Clone(newObject);
            return currentObject; 
        }
    }
}