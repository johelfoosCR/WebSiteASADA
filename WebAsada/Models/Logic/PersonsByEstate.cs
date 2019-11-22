using System;
using System.ComponentModel.DataAnnotations;

namespace WebAsada.Models
{  
    public class PersonsByEstate
    {
        private PersonsByEstate()
        {
                
        }

        public static PersonsByEstate Create(Person person, Estate estate) {

            person = person ?? throw new ArgumentException("Debe indicar una persona");
            estate = estate ?? throw new ArgumentException("Debe indicar una propiedad");

            return new PersonsByEstate()
            {
                Estate = estate,
                EstateId = estate.Id,
                Person = person,
                PersonId = person.Id,
            };
        }
         
        public int PersonId { get; private set; }
        public Person Person { get; private set; } 
        public int EstateId { get; private set; }
        public Estate Estate { get; private set; }
    }
}
