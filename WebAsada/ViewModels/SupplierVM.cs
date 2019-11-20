using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebAsada.BaseObjects;
using WebAsada.Models;

namespace WebAsada.ViewModels
{  
    public class SupplierVM : BaseEntity
    {
        [Required]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [DisplayName("Nombre Contacto")]
        public string ContactName { get; set; }

        [DisplayName("Teléfono")]
        public string PhoneNumber { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Dirección")]
        public string Address { get; set; }

        [DisplayName("Horario")]
        public string Schedule { get; set; }

        [DisplayName("Tipo de Producto")]
        public int ProductTypeId { get; set; } 
        public ProductType ProductType { get; set; }

        [Required]
        [DisplayName("Activo?")]
        public bool IsActive { get; set; }

        [DisplayName("Comentarios")]
        public string Comments { get; set; }
    }
}
