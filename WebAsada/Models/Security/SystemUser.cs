using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAsada.Models
{
    public class SystemUser
    {
        private SystemUser()
        {
            
        }



        [Key]
        public string Id { get; set; }

        [Required]
        public UserName UserName { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [Column("Password")]
        public Password Password { get; set; }

        [Required]
        public DateTime RegisterDateTime { get; set; }

        public bool IsAdministrator { get; set; }

        public bool IsActive { get; set; }

        public bool IsOperational { get; set; }
        public static SystemUser Create(UserName userName, string fullName, Password password, bool isAdministrator)
        {
            return new SystemUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = userName,
                FullName = fullName,
                Password = password,
                IsAdministrator = isAdministrator,
                IsActive = true,
                IsOperational = false,
                RegisterDateTime = DateTime.Now
            };
        }

        public static SystemUser CreateOperational(UserName userName, string fullName, Password password, bool isAdministrator)
        {
            return new SystemUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = userName,
                FullName = fullName,
                Password = password,
                IsAdministrator = isAdministrator,
                IsActive = true,
                IsOperational = true,
                RegisterDateTime = DateTime.Now 
            };
        }

        public void ChangePassword(Password newPassword)
        {
            Password = newPassword;
        }

        internal static SystemUser SincronizeObject(SystemUser currentSystem, SystemUser newSystem)
        {
            currentSystem.FullName = newSystem.FullName;
            currentSystem.IsActive = newSystem.IsActive;
            currentSystem.IsAdministrator = newSystem.IsAdministrator;
            currentSystem.IsOperational = newSystem.IsOperational; 
            currentSystem.UserName = newSystem.UserName;
            return currentSystem;
        }
    }
}
