using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using WebAsada.Global;
using WebAsada.Helpers;

namespace WebAsada.Models
{
    [Owned]
    public class Password
    {
        [Required]
        [Column("Password")]
        public string Value { get; private set; }

        private Password()
        {

        }

        private Password(string value) : this()
        {
            Value = value;
        }

        public static Result<Password> Create(string value)
        {
            if (string.IsNullOrEmpty(value)) return Result.Failure<Password>("Debe informar la contraseña");
            
            if (!Regex.Match(value, Constants.PASSWORD_VALIDATION_REGEX).Success)
            {
                return Result.Failure<Password>("La contraseña debe poseer de 8 a 15 carateres, de los cuales al menos uno debe ser un caracter especial y uno debe ser un número");
            }

            return Result.Ok(new Password(SecurityHelper.ComputeSha256Hash(value)));
        }
    }
}