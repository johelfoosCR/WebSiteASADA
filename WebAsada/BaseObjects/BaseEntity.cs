using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebAsada.BaseObjects
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
         
        public string RegisterUserId { get; set; }

        [Display(Name = "Usuario que registro")]
        public IdentityUser RegisterUser { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime RegisterDatime { get; set; }
         
        public string UpdateUserId { get; set; }

        [Display(Name = "Usuario que actualiza")]
        public IdentityUser UpdateUser { get; set; }

        [Display(Name = "Fecha de actualización")]
        public DateTime UpdateDateTime { get; set; }
    }

}
