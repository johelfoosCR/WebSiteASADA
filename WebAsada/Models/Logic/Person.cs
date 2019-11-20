using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebAsada.BaseObjects; 

namespace WebAsada.Models
{
    public class Person : BaseEntity
    {
        private Person()
        {

        } 
     
        public Person(string name, string firstLastName, string secondLastName, PersonType personType, string identificationNumber, string telephoneNumber, string emailAddress) : this()
        {
            Name = name;
            FirstLastName = firstLastName;
            SecondLastName = secondLastName;
            PersonType = personType;
            IdentificationNumber = identificationNumber;
            TelephoneNumber = telephoneNumber;
            EmailAddress = emailAddress;
        } 

        public string Name { get; private set; }

        public string FirstLastName { get; private set; }

        public string SecondLastName { get; private set; }

        public int PersonTypeId { get; private set; }

        public PersonType PersonType { get; private set; }

        public IdentificationType IdentificationType { get; protected set; }

        public int IdentificationTypeId { get; private set; }

        [NotMapped]
        public string FullName => $"{Name} {FirstLastName} {SecondLastName}"; 

        public string IdentificationNumber { get; private set; }
        
        public string TelephoneNumber { get; private set; }

        public string EmailAddress { get; private set; }

        public bool IsActive { get; private set; }

        public IList<PersonsByEstate> PersonsByEstate { get; set; }

        internal static Person SincronizeObject(Person currentPerson, Person newPerson)
        {
            currentPerson.EmailAddress = newPerson.EmailAddress;
            currentPerson.FirstLastName = newPerson.FirstLastName;
            currentPerson.IdentificationNumber = newPerson.IdentificationNumber;
            currentPerson.IdentificationTypeId = newPerson.IdentificationTypeId; 
            currentPerson.Name = newPerson.Name;
            currentPerson.PersonTypeId = newPerson.PersonTypeId;
            currentPerson.SecondLastName = newPerson.SecondLastName;
            currentPerson.TelephoneNumber = newPerson.TelephoneNumber;
            currentPerson.IsActive = newPerson.IsActive;
            return currentPerson;
        }

        public override string ToString()
        {
            return $"{FullName} / {IdentificationNumber}";
        }

    }
}
