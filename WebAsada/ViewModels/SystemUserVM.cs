using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAsada.ViewModels
{
    public class SystemUserVM
    {
        public string Id { get; set; }

        [Required]
        [DisplayName("Nombre Usuario")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Nombre Completo")]
        public string FullName { get; set; }

        [Required]
        [DisplayName("Contraseña")]
        public string Password { get; set; }
         
        [Required]
        [DisplayName("Confirmar Contraseña")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("Es administrador?")]
        public bool IsAdministrator { get; set; }

        [Required]
        [DisplayName("Activo?")]
        public bool IsActive { get; set; }

        [Required]
        [DisplayName("Es operacional?")]
        public bool IsOperational { get; set; }

    }
}
