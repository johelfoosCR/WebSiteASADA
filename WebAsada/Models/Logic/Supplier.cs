using System.ComponentModel.DataAnnotations;
using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class Supplier : BaseEntity
    {
        [Required]
        public string Name { get; private set; }

        public string ContactName { get; private set; }

        public string PhoneNumber { get; private set; }

        public string Email { get; private set; }

        public string Address { get; private set; }

        public string Schedule { get; private set; }

        public int ProductTypeId { get; private set; }

        public ProductType ProductType { get; private set; }

        [Required]
        public bool IsActive { get; private set; }

        public string Comments { get; private set; }

        internal static Supplier SincronizeObject(Supplier currentObject, Supplier newObject)
        { 
            currentObject.Name = newObject.Name;
            currentObject.ContactName = newObject.ContactName;
            currentObject.PhoneNumber = newObject.PhoneNumber;
            currentObject.Email = newObject.Email; 
            currentObject.Address = newObject.Address;
            currentObject.Schedule = newObject.Schedule;
            currentObject.ProductTypeId = newObject.ProductTypeId;
            currentObject.IsActive = newObject.IsActive;
            currentObject.Comments = newObject.Comments; 
            return currentObject;
        }

    }
}
