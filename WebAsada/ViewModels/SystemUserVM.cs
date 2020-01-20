using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebAsada.Global;

namespace WebAsada.ViewModels
{
    public class SystemUserVM
    {
        public string Id { get; set; }

        [Required]
        [DisplayName("Nombre Usuario")]
        [RegularExpression(@"^[a-z]{6,15}$", 
            ErrorMessage = "El nombre de usuario debe tener entre 6 y 15 letras minusculas")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Nombre Completo")]
        public string FullName { get; set; }

        [Required]
        [DisplayName("Contraseña")]
        [RegularExpression(Constants.PASSWORD_VALIDATION_REGEX,
                ErrorMessage = "La contraseña debe poseer de 8 a 15 carateres, de los cuales al menos uno debe ser un caracter especial y uno debe ser un número")]
        public string Password { get; set; }
         
        [Required]
        [DisplayName("Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y su confirmación no coinciden")]
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
