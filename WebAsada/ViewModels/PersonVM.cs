using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebAsada.BaseObjects;
using WebAsada.Models;

namespace WebAsada.ViewModels
{
    public class PersonVM:BaseEntity
    {
        [Required]
        [DisplayName("Nombre")] 
        public string Name { get; set; }

        [Required]
        [DisplayName("Primer Apellido")]
        public string FirstLastName { get; set; }

        [DisplayName("Segundo Apellido")]
        public string SecondLastName { get; set; }

        [Required]
        [DisplayName("Tipo de Persona")]
        public int PersonTypeId { get; set; }

        public PersonType PersonType { get; set; }
         
        public IdentificationType IdentificationType { get; set; }

        [Required]
        [DisplayName("Tipo de identificación")]
        public int IdentificationTypeId { get; set; }

        [DisplayName("Nombre Completo")]
        public string FullName => $"{Name} {FirstLastName} {SecondLastName}";

        [Required]
        [DisplayName("Número de identificación")]
        public string IdentificationNumber { get; set; }

        [DisplayName("Número de Telefono")]
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "Debe ingresar un teléfono en formato ####-####.")]
        public string TelephoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Correo Electrónico")]
        public string EmailAddress { get; set; }

        [Required]
        [DisplayName("Activo")]
        public bool IsActive { get; set; }
    }
}
