using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class ProductType : GeneralEntity
    {
        private ProductType()
        {

        }

        public ProductType(string shortDesc, string longDesc, string officialId, string nemotecnico, string productTypeCode, bool isActive)
            : base(shortDesc, longDesc, officialId, nemotecnico, isActive)
        {
            ProductTypeCode = productTypeCode;
        }

        public string ProductTypeCode { get; private set; }

        public static ProductType SincronizeObject(ProductType currentObject, ProductType newObject)
        {
            currentObject.ProductTypeCode = newObject.ProductTypeCode;
            currentObject.Clone(newObject);
            return currentObject;
        }
    }
}
