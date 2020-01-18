using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
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
          if (!Regex.Match(value, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$").Success) return Result.Failure<Password>("El nombre de usuario solo debe poseer letras");

            return Result.Ok(new Password(SecurityHelper.ComputeSha256Hash(value)));
        }
    }
}