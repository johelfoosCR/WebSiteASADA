using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace WebAsada.Models
{
    [Owned]
    public class UserName : ValueObject<UserName>
    {
        [Required]
        [Column("UserName")]
        public string Value { get; private set; }

        private UserName()
        {
               
        }
        private UserName(string value): this()
        {
            Value = value;
        }

        public static Result<UserName> Create(string value)
        {
            if (string.IsNullOrEmpty(value)) return Result.Failure<UserName>("Debe informar un nombre de usuario");
            if (value.Length < 8 || value.Length > 15) return Result.Failure<UserName>("El nombre de usuario debe tener en 8 y 15 caracteres");
            if (!Regex.Match(value.ToLower(),"[a-z]").Success) return Result.Failure<UserName>("El nombre de usuario solo debe poseer letras");

            return Result.Ok(new UserName(value.ToLower()));
         }

        protected override bool EqualsCore(UserName other)
        {
            return Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return GetHashCode();
        }
    }
}