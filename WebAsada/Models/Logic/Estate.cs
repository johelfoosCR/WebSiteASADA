using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using WebAsada.BaseObjects;

namespace WebAsada.Models
{
    public class Estate:BaseEntity
    {
        private readonly List<PersonsByEstate> personsByEstatesList;

        private Estate()
        {
            personsByEstatesList = new List<PersonsByEstate>();
        }

        private Estate(IEnumerable<Person> Owners) : this()
        {
            personsByEstatesList = Owners.Select(x => PersonsByEstate.Create(x, this)).ToList();
        }

        public static Estate Create(string realFolio, 
                                    string cadastralPlans, 
                                    string exactAddress,
                                    string alias, 
                                    string comments,
                                    double area, 
                                    IEnumerable<Person> Owners ) {
            return new Estate(Owners)
            {
                RealFolio = realFolio,
                CadastralPlans = cadastralPlans,
                Comments = comments,
                ExactAddress = exactAddress,
                Alias = alias,
                Area = area
            };
        } 

        public string RealFolio { get; private set; }

        public string CadastralPlans { get; private set; }

        public double Area { get; private set; }
         
        public string Comments { get; private set; }

        public string Alias { get; private set; }

        public string ExactAddress { get; private set; }

        public IEnumerable<PersonsByEstate> PersonsByEstateCollection { get { return personsByEstatesList; } } 

        internal static Estate SincronizeObject(Estate currentState, Estate newState)
        {
            currentState.RealFolio = newState.RealFolio;
            currentState.CadastralPlans = newState.CadastralPlans;
            currentState.Area = newState.Area;
            currentState.Comments = newState.Comments;
            currentState.Alias = newState.Alias;
            currentState.ExactAddress = newState.ExactAddress;
            return currentState;
        }

        internal void AddPerson(Person person, Estate estate) {
            personsByEstatesList.Add(PersonsByEstate.Create(person,estate));
        }
    }
}
