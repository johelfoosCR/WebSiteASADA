using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAsada.Models;

namespace WebAsada.BaseObjects
{
    public abstract class BaseEntity
    {
        public int Id { get; internal set; }

        [ForeignKey("RegisterUser")]
        public string RegisterUserId { get; internal set; }

        [Display(Name = "Usuario que registro")]
        public SystemUser RegisterUser { get; internal set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime RegisterDatime { get; internal set; }

        [ForeignKey("UpdateUser")]
        public string UpdateUserId { get; internal set; }

        [Display(Name = "Usuario que actualiza")]
        public SystemUser UpdateUser { get; internal set; }

        [Display(Name = "Fecha de actualización")]
        public DateTime UpdateDateTime { get; internal set; }
    }

}
